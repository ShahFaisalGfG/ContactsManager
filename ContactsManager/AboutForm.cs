using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace ContactsManager
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            this.lblProductName.Text = "Contacts Manager";
            this.lblCompany.Text = "Shah Faisal GfG";
            this.lblVersion.Text = $"Version {Application.ProductVersion}";
            this.linkWebsite.Text = "https://shahfaisalgfg.github.io/shahfaisalgfg";
            this.linkWebsite.Links.Clear();
            this.linkWebsite.Links.Add(0, this.linkWebsite.Text.Length, this.linkWebsite.Text);
        }

        private void linkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = e.Link.LinkData as string ?? linkWebsite.Text;
            try
            {
                Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
            }
            catch
            {
                MessageBox.Show("Unable to open link.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
