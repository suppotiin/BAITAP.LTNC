﻿namespace Manning.PhotoControl
{
    partial class AlbumEditDialog
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAlbumFile = new System.Windows.Forms.TextBox();
            this.txtTile = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnFileName = new System.Windows.Forms.RadioButton();
            this.rbtnCaption = new System.Windows.Forms.RadioButton();
            this.rbtnDateTaken = new System.Windows.Forms.RadioButton();
            this.cbxPassword = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTile);
            this.panel1.Controls.Add(this.txtAlbumFile);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Size = new System.Drawing.Size(260, 80);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Album &File";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "&Tiltle";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAlbumFile
            // 
            this.txtAlbumFile.Location = new System.Drawing.Point(99, 12);
            this.txtAlbumFile.Name = "txtAlbumFile";
            this.txtAlbumFile.ReadOnly = true;
            this.txtAlbumFile.Size = new System.Drawing.Size(157, 20);
            this.txtAlbumFile.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtAlbumFile, "Album file name");
            // 
            // txtTile
            // 
            this.txtTile.Location = new System.Drawing.Point(99, 46);
            this.txtTile.Name = "txtTile";
            this.txtTile.Size = new System.Drawing.Size(156, 20);
            this.txtTile.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtTile, "Title for the album");
            this.txtTile.TextChanged += new System.EventHandler(this.txtTile_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnDateTaken);
            this.groupBox1.Controls.Add(this.rbtnCaption);
            this.groupBox1.Controls.Add(this.rbtnFileName);
            this.groupBox1.Location = new System.Drawing.Point(13, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 49);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phot&o Description";
            // 
            // rbtnFileName
            // 
            this.rbtnFileName.AutoSize = true;
            this.rbtnFileName.Location = new System.Drawing.Point(4, 19);
            this.rbtnFileName.Name = "rbtnFileName";
            this.rbtnFileName.Size = new System.Drawing.Size(70, 17);
            this.rbtnFileName.TabIndex = 0;
            this.rbtnFileName.TabStop = true;
            this.rbtnFileName.Text = "File &name";
            this.rbtnFileName.UseVisualStyleBackColor = true;
            // 
            // rbtnCaption
            // 
            this.rbtnCaption.AutoSize = true;
            this.rbtnCaption.Location = new System.Drawing.Point(85, 19);
            this.rbtnCaption.Name = "rbtnCaption";
            this.rbtnCaption.Size = new System.Drawing.Size(61, 17);
            this.rbtnCaption.TabIndex = 0;
            this.rbtnCaption.TabStop = true;
            this.rbtnCaption.Text = "Ca&ption";
            this.toolTip1.SetToolTip(this.rbtnCaption, "When set, describes each photo using its caption");
            this.rbtnCaption.UseVisualStyleBackColor = true;
            // 
            // rbtnDateTaken
            // 
            this.rbtnDateTaken.AutoSize = true;
            this.rbtnDateTaken.Location = new System.Drawing.Point(174, 19);
            this.rbtnDateTaken.Name = "rbtnDateTaken";
            this.rbtnDateTaken.Size = new System.Drawing.Size(82, 17);
            this.rbtnDateTaken.TabIndex = 0;
            this.rbtnDateTaken.TabStop = true;
            this.rbtnDateTaken.Text = "&Date Taken";
            this.toolTip1.SetToolTip(this.rbtnDateTaken, "When set, describes each photo using its caption");
            this.rbtnDateTaken.UseVisualStyleBackColor = true;
            // 
            // cbxPassword
            // 
            this.cbxPassword.AutoSize = true;
            this.cbxPassword.Location = new System.Drawing.Point(17, 155);
            this.cbxPassword.Name = "cbxPassword";
            this.cbxPassword.Size = new System.Drawing.Size(121, 17);
            this.cbxPassword.TabIndex = 5;
            this.cbxPassword.Text = "Pass&word Protected";
            this.toolTip1.SetToolTip(this.cbxPassword, "When set, describes each photo using its caption");
            this.cbxPassword.UseVisualStyleBackColor = true;
            this.cbxPassword.CheckedChanged += new System.EventHandler(this.cbxPassword_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(144, 153);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(125, 20);
            this.txtPassword.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtPassword, "Password for album");
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Enabled = false;
            this.lblConfirm.Location = new System.Drawing.Point(34, 179);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(91, 13);
            this.lblConfirm.TabIndex = 7;
            this.lblConfirm.Text = "Confir&m Password";
            this.lblConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConfirm
            // 
            this.txtConfirm.Enabled = false;
            this.txtConfirm.Location = new System.Drawing.Point(144, 171);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Size = new System.Drawing.Size(125, 20);
            this.txtConfirm.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txtConfirm, "Confirms password for ");
            this.txtConfirm.UseSystemPasswordChar = true;
            this.txtConfirm.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirm_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AlbumEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.cbxPassword);
            this.Controls.Add(this.groupBox1);
            this.Name = "AlbumEditDialog";
            this.Text = "Album Properties";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cbxPassword, 0);
            this.Controls.SetChildIndex(this.txtPassword, 0);
            this.Controls.SetChildIndex(this.lblConfirm, 0);
            this.Controls.SetChildIndex(this.txtConfirm, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTile;
        private System.Windows.Forms.TextBox txtAlbumFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnDateTaken;
        private System.Windows.Forms.RadioButton rbtnCaption;
        private System.Windows.Forms.RadioButton rbtnFileName;
        private System.Windows.Forms.CheckBox cbxPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
