namespace ContactsManager
{
    partial class ContactsManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactsManager));
            this.lblFilePath = new System.Windows.Forms.Label();
            this.btnLoadContacts = new System.Windows.Forms.Button();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.btnCSV = new System.Windows.Forms.Button();
            this.btnSaveAllExcel = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.chkIgnoreLessThan = new System.Windows.Forms.CheckBox();
            this.txtIgnoreLessThan = new System.Windows.Forms.TextBox();
            this.lblIgnoreLess = new System.Windows.Forms.Label();
            this.chkIgnoreGreaterThan = new System.Windows.Forms.CheckBox();
            this.txtIgnoreGreaterThan = new System.Windows.Forms.TextBox();
            this.lblIgnoreGreater = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControlContacts = new System.Windows.Forms.TabControl();
            this.chkIgnoreCountryCode = new System.Windows.Forms.CheckBox();
            this.lblLessError = new System.Windows.Forms.Label();
            this.lblGreaterError = new System.Windows.Forms.Label();
            this.tabControlContacts.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(24, 15);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(89, 17);
            this.lblFilePath.TabIndex = 1;
            this.lblFilePath.Text = "Selected File";
            // 
            // btnLoadContacts
            // 
            this.btnLoadContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadContacts.Location = new System.Drawing.Point(700, 8);
            this.btnLoadContacts.Name = "btnLoadContacts";
            this.btnLoadContacts.Size = new System.Drawing.Size(161, 33);
            this.btnLoadContacts.TabIndex = 2;
            this.btnLoadContacts.Text = "Load Contacts File";
            this.btnLoadContacts.UseVisualStyleBackColor = true;
            this.btnLoadContacts.Click += new System.EventHandler(this.btnLoadContacts_Click);
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAll.Location = new System.Drawing.Point(450, 517);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(115, 44);
            this.btnSaveAll.TabIndex = 4;
            this.btnSaveAll.Text = "Save As Text";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            this.btnSaveAll.Visible = false;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // btnCSV
            // 
            this.btnCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCSV.Location = new System.Drawing.Point(575, 517);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(150, 44);
            this.btnCSV.TabIndex = 5;
            this.btnCSV.Text = "Save Importable CSV";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Visible = false;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // btnSaveAllExcel
            // 
            this.btnSaveAllExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAllExcel.Location = new System.Drawing.Point(735, 517);
            this.btnSaveAllExcel.Name = "btnSaveAllExcel";
            this.btnSaveAllExcel.Size = new System.Drawing.Size(130, 44);
            this.btnSaveAllExcel.TabIndex = 6;
            this.btnSaveAllExcel.Text = "Save As Excel";
            this.btnSaveAllExcel.UseVisualStyleBackColor = true;
            this.btnSaveAllExcel.Visible = false;
            this.btnSaveAllExcel.Click += new System.EventHandler(this.btnSaveAllExcel_Click);
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReload.Location = new System.Drawing.Point(700, 58);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(161, 33);
            this.btnReload.TabIndex = 13;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Visible = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // chkIgnoreLessThan
            // 
            this.chkIgnoreLessThan.AutoSize = true;
            this.chkIgnoreLessThan.Checked = true;
            this.chkIgnoreLessThan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnoreLessThan.Location = new System.Drawing.Point(24, 44);
            this.chkIgnoreLessThan.Name = "chkIgnoreLessThan";
            this.chkIgnoreLessThan.Size = new System.Drawing.Size(131, 21);
            this.chkIgnoreLessThan.TabIndex = 7;
            this.chkIgnoreLessThan.Text = "Ignore less than";
            this.chkIgnoreLessThan.UseVisualStyleBackColor = true;
            this.chkIgnoreLessThan.CheckedChanged += new System.EventHandler(this.chkIgnoreLessThan_CheckedChanged);
            // 
            // txtIgnoreLessThan
            // 
            this.txtIgnoreLessThan.Location = new System.Drawing.Point(182, 42);
            this.txtIgnoreLessThan.Name = "txtIgnoreLessThan";
            this.txtIgnoreLessThan.Size = new System.Drawing.Size(61, 22);
            this.txtIgnoreLessThan.TabIndex = 8;
            this.txtIgnoreLessThan.Text = "2";
            this.txtIgnoreLessThan.TextChanged += new System.EventHandler(this.txtIgnoreLessThan_TextChanged);
            this.txtIgnoreLessThan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblIgnoreLess
            // 
            this.lblIgnoreLess.AutoSize = true;
            this.lblIgnoreLess.Location = new System.Drawing.Point(249, 42);
            this.lblIgnoreLess.Name = "lblIgnoreLess";
            this.lblIgnoreLess.Size = new System.Drawing.Size(91, 17);
            this.lblIgnoreLess.TabIndex = 9;
            this.lblIgnoreLess.Text = "digits (e.g. 5)";
            // 
            // chkIgnoreGreaterThan
            // 
            this.chkIgnoreGreaterThan.AutoSize = true;
            this.chkIgnoreGreaterThan.Checked = true;
            this.chkIgnoreGreaterThan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnoreGreaterThan.Location = new System.Drawing.Point(24, 71);
            this.chkIgnoreGreaterThan.Name = "chkIgnoreGreaterThan";
            this.chkIgnoreGreaterThan.Size = new System.Drawing.Size(152, 21);
            this.chkIgnoreGreaterThan.TabIndex = 10;
            this.chkIgnoreGreaterThan.Text = "Ignore greater than";
            this.chkIgnoreGreaterThan.UseVisualStyleBackColor = true;
            this.chkIgnoreGreaterThan.CheckedChanged += new System.EventHandler(this.chkIgnoreGreaterThan_CheckedChanged);
            // 
            // txtIgnoreGreaterThan
            // 
            this.txtIgnoreGreaterThan.Location = new System.Drawing.Point(182, 69);
            this.txtIgnoreGreaterThan.Name = "txtIgnoreGreaterThan";
            this.txtIgnoreGreaterThan.Size = new System.Drawing.Size(61, 22);
            this.txtIgnoreGreaterThan.TabIndex = 11;
            this.txtIgnoreGreaterThan.Text = "13";
            this.txtIgnoreGreaterThan.TextChanged += new System.EventHandler(this.txtIgnoreGreaterThan_TextChanged);
            this.txtIgnoreGreaterThan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblIgnoreGreater
            // 
            this.lblIgnoreGreater.AutoSize = true;
            this.lblIgnoreGreater.Location = new System.Drawing.Point(249, 69);
            this.lblIgnoreGreater.Name = "lblIgnoreGreater";
            this.lblIgnoreGreater.Size = new System.Drawing.Size(91, 17);
            this.lblIgnoreGreater.TabIndex = 12;
            this.lblIgnoreGreater.Text = "digits (e.g. 5)";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(830, 343);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(830, 343);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControlContacts
            // 
            this.tabControlContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlContacts.Controls.Add(this.tabPage1);
            this.tabControlContacts.Controls.Add(this.tabPage2);
            this.tabControlContacts.Location = new System.Drawing.Point(27, 139);
            this.tabControlContacts.Name = "tabControlContacts";
            this.tabControlContacts.SelectedIndex = 0;
            this.tabControlContacts.Size = new System.Drawing.Size(838, 372);
            this.tabControlContacts.TabIndex = 3;
            // 
            // chkIgnoreCountryCode
            // 
            this.chkIgnoreCountryCode.AutoSize = true;
            this.chkIgnoreCountryCode.Location = new System.Drawing.Point(24, 98);
            this.chkIgnoreCountryCode.Name = "chkIgnoreCountryCode";
            this.chkIgnoreCountryCode.Size = new System.Drawing.Size(249, 21);
            this.chkIgnoreCountryCode.TabIndex = 14;
            this.chkIgnoreCountryCode.Text = "Ignore country code while counting";
            this.chkIgnoreCountryCode.UseVisualStyleBackColor = true;
            // 
            // lblLessError
            // 
            this.lblLessError.AutoSize = true;
            this.lblLessError.ForeColor = System.Drawing.Color.Red;
            this.lblLessError.Location = new System.Drawing.Point(249, 45);
            this.lblLessError.Name = "lblLessError";
            this.lblLessError.Size = new System.Drawing.Size(0, 17);
            this.lblLessError.TabIndex = 15;
            // 
            // lblGreaterError
            // 
            this.lblGreaterError.AutoSize = true;
            this.lblGreaterError.ForeColor = System.Drawing.Color.Red;
            this.lblGreaterError.Location = new System.Drawing.Point(249, 72);
            this.lblGreaterError.Name = "lblGreaterError";
            this.lblGreaterError.Size = new System.Drawing.Size(0, 17);
            this.lblGreaterError.TabIndex = 16;
            // 
            // ContactsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 570);
            this.Controls.Add(this.chkIgnoreCountryCode);
            this.Controls.Add(this.lblLessError);
            this.Controls.Add(this.lblGreaterError);
            this.Controls.Add(this.btnSaveAllExcel);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnCSV);
            this.Controls.Add(this.btnSaveAll);
            this.Controls.Add(this.tabControlContacts);
            this.Controls.Add(this.chkIgnoreLessThan);
            this.Controls.Add(this.txtIgnoreLessThan);
            this.Controls.Add(this.lblIgnoreLess);
            this.Controls.Add(this.chkIgnoreGreaterThan);
            this.Controls.Add(this.txtIgnoreGreaterThan);
            this.Controls.Add(this.lblIgnoreGreater);
            this.Controls.Add(this.btnLoadContacts);
            this.Controls.Add(this.lblFilePath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 520);
            this.Name = "ContactsManager";
            this.Text = "Contacts Manager";
            this.Load += new System.EventHandler(this.ContactsManager_Load);
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

    // Controls added for ignore-length feature
    private System.Windows.Forms.CheckBox chkIgnoreLessThan;
    private System.Windows.Forms.TextBox txtIgnoreLessThan;
    private System.Windows.Forms.Label lblIgnoreLess;
    private System.Windows.Forms.CheckBox chkIgnoreGreaterThan;
    private System.Windows.Forms.TextBox txtIgnoreGreaterThan;
    private System.Windows.Forms.Label lblIgnoreGreater;
    private System.Windows.Forms.Button btnReload;
    private System.Windows.Forms.CheckBox chkIgnoreCountryCode;
    private System.Windows.Forms.Label lblLessError;
    private System.Windows.Forms.Label lblGreaterError;
    }
}

