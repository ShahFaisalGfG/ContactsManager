namespace ContactsManager
{
    partial class UpdateForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.LinkLabel linkRepo;
    private System.Windows.Forms.Label lblVisitRepo;
        private System.Windows.Forms.Button btnCheck;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.linkRepo = new System.Windows.Forms.LinkLabel();
            this.lblVisitRepo = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // linkRepo
            // 
            this.linkRepo.AutoSize = true;
            this.linkRepo.Location = new System.Drawing.Point(24, 35);
            this.linkRepo.Name = "linkRepo";
            this.linkRepo.Size = new System.Drawing.Size(63, 17);
            this.linkRepo.TabIndex = 1;
            this.linkRepo.TabStop = true;
            this.linkRepo.Text = "linkRepo";
            this.linkRepo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRepo_LinkClicked);
            // 
            // lblVisitRepo
            // 
            this.lblVisitRepo.AutoSize = true;
            this.lblVisitRepo.Location = new System.Drawing.Point(24, 18);
            this.lblVisitRepo.Name = "lblVisitRepo";
            this.lblVisitRepo.Size = new System.Drawing.Size(122, 17);
            this.lblVisitRepo.TabIndex = 0;
            this.lblVisitRepo.Text = "Visit Github Repo:";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(24, 72);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(140, 30);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Check For Updates";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // UpdateForm
            // 
            this.ClientSize = new System.Drawing.Size(457, 121);
            this.Controls.Add(this.lblVisitRepo);
            this.Controls.Add(this.linkRepo);
            this.Controls.Add(this.btnCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
