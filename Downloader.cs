using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditSharp;
using System.Net;
using System.Text.RegularExpressions;

namespace RedUDL
{
    class Downloader
    {
        public static void downloadFiles(IProgress<string> progress, String _user, String _subreddit, String outputDir){
            var reddit = new Reddit();
            RedditUser user = null;
            String requestedSubreddit = _subreddit;
            String finalOutputDir = outputDir + "\\" + _user;

            // Check user exists
            try { user = reddit.GetUser(_user); }
            catch (WebException e) {
                progress.Report("User doesn't exist");
                return; 
            }

            // Check user has posts
            if (user.Posts.Count() == 0){
                progress.Report(_user + " has no posts.");
                return;
            }


            // Create users directory if it doesn't exist
            bool userDirExists = System.IO.Directory.Exists(finalOutputDir);
            if (!userDirExists){
                System.IO.Directory.CreateDirectory(finalOutputDir);
                progress.Report("Creating directory for " + _user);
            }

            // Iterate through posts and download
            foreach (var post in user.Posts)
            {
                if (checkSubreddit(post.Subreddit, requestedSubreddit))
                {
                    bool downloaded;
                    if (isAlbum(post.Url.ToString()))
                        downloaded = downloadAlbum(post.Url.ToString(), finalOutputDir);
                    else 
                        downloaded = downloadImage(post.Url.ToString(), finalOutputDir);

                    // Record downloaded
                    String success = downloaded == true ? "successful" : "failed";
                    String progressString = post.Url.ToString() + " downloading: " + success; 
                    progress.Report(progressString);
                }
            }

            // Notify completion
            progress.Report("Downloading complete");
        }

        // Ensure the post found matches the subreddit specified
        public static bool checkSubreddit(String subreddit, String requestedSubreddit)
        {
            if (subreddit != requestedSubreddit)
                return false;
            else return true;
        }

        // Download the image to the specified output directory
        public static bool downloadImage(String downloadURL, String outputDir)
        {
            try
            {
                Match match = Regex.Match(downloadURL, @".com/([A-Za-z0-9\-]+)\.(?:jpg|gif|png)$",
                        RegexOptions.IgnoreCase);

                if (!match.Success)
                    if (!tryWithExtension(downloadURL))
                        return false;
                    else
                        downloadURL += ".jpg";

                string localFilename = outputDir + "\\"+ match.Groups[1].Value + ".jpg";
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(downloadURL, localFilename);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        // Download an album by scraping the Imgur source
        public static bool downloadAlbum(String downloadURL, string outputDir)
        {
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                String[] htmlCode;
                try
                {
                    htmlCode = client.DownloadString(downloadURL).Split('\n');
                    foreach (var line in htmlCode)
                    {
                        if (imageLinkFound(line) != "NONEFOUND")
                        {
                            String imageString = "http://i.imgur.com/" + imageLinkFound(line) + ".jpg";
                            downloadImage(imageString, outputDir);
                        }
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }
        }

        // Use regex to verify imgur album
        public static bool isAlbum(String url)
        {
            Regex rgx = new Regex(@"imgur.com/a/([A-Za-z0-9\-]+)$", RegexOptions.IgnoreCase);
            if (rgx.IsMatch(url)) return true;
            return false;
        }

        // Verify image link found
        public static String imageLinkFound(String html)
        {
            Match match = Regex.Match(html, "<meta property=\"og:image\" content=\"(http|https)://i.imgur.com/([A-Za-z0-9-]+).(?:jpg|gif|png)\" />", RegexOptions.IgnoreCase);
            if (match.Success){
                return match.Groups[2].Value;
            }
            return "NONEFOUND";
        }

        // Some images don't contain extensions in the URL but require them to be downloaded. 
        private static bool tryWithExtension(String downloadURL)
        {
            Match match = Regex.Match(downloadURL + ".jpg", @".com/([A-Za-z0-9\-]+)\.(?:jpg|gif|png)$",
                       RegexOptions.IgnoreCase);

            if (!match.Success)
                return false;

            return true;
        }

    }
}
