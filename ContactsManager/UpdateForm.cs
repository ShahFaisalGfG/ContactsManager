using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ContactsManager
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
            this.linkRepo.Text = "github.com/ShahFaisalGfG/ContactsManager";
            this.linkRepo.Links.Clear();
            this.linkRepo.Links.Add(0, this.linkRepo.Text.Length, this.linkRepo.Text);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            var url = "https://github.com/ShahFaisalGfG/ContactsManager";
            try
            {
                Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
            }
            catch
            {
                MessageBox.Show("Unable to open updates page.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkRepo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = e.Link.LinkData as string ?? linkRepo.Text;
            try
            {
                Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
            }
            catch
            {
                MessageBox.Show("Unable to open link.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
