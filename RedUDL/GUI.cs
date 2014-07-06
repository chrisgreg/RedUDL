using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedUDL
{
    public partial class MainForm : Form
    {

        String saveDir;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Verify fields are not empty
            if (!checkEmptyFields(new Control[] { userBox, subredditBox, fileDirBox }))
                return;

            // Progress bar
            var progress = new Progress<string>(s => statusBox.AppendText(s + "\n")); // Progress delegate
            this.Enabled = false; // Disable UI

            // Begin task
            await Task.Factory.StartNew(() => Downloader.downloadFiles(progress, userBox.Text, subredditBox.Text, fileDirBox.Text),
                                TaskCreationOptions.LongRunning);
            // Re-enable UI
            this.Enabled = true;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dirDialog = new FolderBrowserDialog();
            DialogResult result = dirDialog.ShowDialog(); 
            if (result == DialogResult.OK) 
            {
                saveDir = dirDialog.SelectedPath;
                fileDirBox.Text = saveDir;
                fileDirBox.Enabled = false;
            }
        }

        private bool checkEmptyFields(Control[] fields)
        {
            foreach (Control field in fields)
                if (field.Text == String.Empty){
                    MessageBox.Show("Fill in all fields");
                    return false;
                }
            return true;
        }
    }
}
