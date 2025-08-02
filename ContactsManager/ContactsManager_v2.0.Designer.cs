namespace ContactsManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblFilePath = new System.Windows.Forms.Label();
            this.btnLoadContacts = new System.Windows.Forms.Button();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.btnCSV = new System.Windows.Forms.Button();
            this.btnSaveAllExcel = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControlContacts = new System.Windows.Forms.TabControl();
            this.tabControlContacts.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(24, 15);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(86, 16);
            this.lblFilePath.TabIndex = 1;
            this.lblFilePath.Text = "Selected File";
            // 
            // btnLoadContacts
            // 
            this.btnLoadContacts.Location = new System.Drawing.Point(541, 8);
            this.btnLoadContacts.Name = "btnLoadContacts";
            this.btnLoadContacts.Size = new System.Drawing.Size(161, 33);
            this.btnLoadContacts.TabIndex = 2;
            this.btnLoadContacts.Text = "Load Contacts File";
            this.btnLoadContacts.UseVisualStyleBackColor = true;
            this.btnLoadContacts.Click += new System.EventHandler(this.btnLoadContacts_Click);
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Location = new System.Drawing.Point(708, 322);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(84, 78);
            this.btnSaveAll.TabIndex = 4;
            this.btnSaveAll.Text = "Save All As Text";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            this.btnSaveAll.Visible = false;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // btnCSV
            // 
            this.btnCSV.Location = new System.Drawing.Point(708, 238);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(84, 78);
            this.btnCSV.TabIndex = 5;
            this.btnCSV.Text = "Save As Importable CSV";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Visible = false;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // btnSaveAllExcel
            // 
            this.btnSaveAllExcel.Location = new System.Drawing.Point(708, 154);
            this.btnSaveAllExcel.Name = "btnSaveAllExcel";
            this.btnSaveAllExcel.Size = new System.Drawing.Size(84, 78);
            this.btnSaveAllExcel.TabIndex = 6;
            this.btnSaveAllExcel.Text = "Save All As Excel";
            this.btnSaveAllExcel.UseVisualStyleBackColor = true;
            this.btnSaveAllExcel.Visible = false;
            this.btnSaveAllExcel.Click += new System.EventHandler(this.btnSaveAllExcel_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(667, 337);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(667, 337);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControlContacts
            // 
            this.tabControlContacts.Controls.Add(this.tabPage1);
            this.tabControlContacts.Controls.Add(this.tabPage2);
            this.tabControlContacts.Location = new System.Drawing.Point(27, 47);
            this.tabControlContacts.Name = "tabControlContacts";
            this.tabControlContacts.SelectedIndex = 0;
            this.tabControlContacts.Size = new System.Drawing.Size(675, 366);
            this.tabControlContacts.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSaveAllExcel);
            this.Controls.Add(this.btnCSV);
            this.Controls.Add(this.btnSaveAll);
            this.Controls.Add(this.tabControlContacts);
            this.Controls.Add(this.btnLoadContacts);
            this.Controls.Add(this.lblFilePath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ContactsManager_v2.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlContacts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Button btnLoadContacts;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.Button btnCSV;
        private System.Windows.Forms.Button btnSaveAllExcel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControlContacts;
    }
}

