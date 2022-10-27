﻿namespace EasyPlanner.Forms
{
    partial class SettingsForm
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
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.GroupBox();
            this.lblPasswordResult = new System.Windows.Forms.Label();
            this.btnPasswordReset = new System.Windows.Forms.Button();
            this.btnPasswordChange = new System.Windows.Forms.Button();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAccessMode = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblHeaderResult = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnHeaderSave = new System.Windows.Forms.Button();
            this.txtHeader = new System.Windows.Forms.TextBox();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.Password.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Location = new System.Drawing.Point(6, 18);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(118, 15);
            this.lblOldPassword.TabIndex = 0;
            this.lblOldPassword.Text = "PASSWORD ATTUALE";
            // 
            // Password
            // 
            this.Password.Controls.Add(this.lblPasswordResult);
            this.Password.Controls.Add(this.btnPasswordReset);
            this.Password.Controls.Add(this.btnPasswordChange);
            this.Password.Controls.Add(this.txtNewPassword);
            this.Password.Controls.Add(this.lblNewPassword);
            this.Password.Controls.Add(this.txtOldPassword);
            this.Password.Controls.Add(this.lblOldPassword);
            this.Password.Location = new System.Drawing.Point(10, 26);
            this.Password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Password.Name = "Password";
            this.Password.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Password.Size = new System.Drawing.Size(200, 241);
            this.Password.TabIndex = 0;
            this.Password.TabStop = false;
            this.Password.Text = "CAMBIO PASSWORD";
            // 
            // lblPasswordResult
            // 
            this.lblPasswordResult.Location = new System.Drawing.Point(6, 137);
            this.lblPasswordResult.Name = "lblPasswordResult";
            this.lblPasswordResult.Size = new System.Drawing.Size(188, 24);
            this.lblPasswordResult.TabIndex = 0;
            this.lblPasswordResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPasswordReset
            // 
            this.btnPasswordReset.Location = new System.Drawing.Point(6, 202);
            this.btnPasswordReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPasswordReset.Name = "btnPasswordReset";
            this.btnPasswordReset.Size = new System.Drawing.Size(188, 35);
            this.btnPasswordReset.TabIndex = 3;
            this.btnPasswordReset.Text = "RESET";
            this.btnPasswordReset.UseVisualStyleBackColor = true;
            this.btnPasswordReset.Click += new System.EventHandler(this.btnPasswordReset_Click);
            // 
            // btnPasswordChange
            // 
            this.btnPasswordChange.Location = new System.Drawing.Point(6, 163);
            this.btnPasswordChange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPasswordChange.Name = "btnPasswordChange";
            this.btnPasswordChange.Size = new System.Drawing.Size(188, 35);
            this.btnPasswordChange.TabIndex = 2;
            this.btnPasswordChange.Text = "CAMBIA PASSWORD";
            this.btnPasswordChange.UseVisualStyleBackColor = true;
            this.btnPasswordChange.Click += new System.EventHandler(this.btnPasswordChange_Click);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(6, 77);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(188, 23);
            this.txtNewPassword.TabIndex = 1;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(6, 60);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(111, 15);
            this.lblNewPassword.TabIndex = 0;
            this.lblNewPassword.Text = "NUOVA PASSWORD";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(6, 35);
            this.txtOldPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(188, 23);
            this.txtOldPassword.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAccessMode);
            this.groupBox1.Location = new System.Drawing.Point(10, 271);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(200, 48);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accesso";
            // 
            // chkAccessMode
            // 
            this.chkAccessMode.AutoSize = true;
            this.chkAccessMode.Checked = true;
            this.chkAccessMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAccessMode.Location = new System.Drawing.Point(6, 20);
            this.chkAccessMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkAccessMode.Name = "chkAccessMode";
            this.chkAccessMode.Size = new System.Drawing.Size(154, 19);
            this.chkAccessMode.TabIndex = 0;
            this.chkAccessMode.Text = "ABILITA INS. PASSWORD";
            this.chkAccessMode.UseVisualStyleBackColor = true;
            this.chkAccessMode.CheckedChanged += new System.EventHandler(this.chkAccessMode_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblHeaderResult);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnHeaderSave);
            this.groupBox2.Controls.Add(this.txtHeader);
            this.groupBox2.Location = new System.Drawing.Point(215, 26);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(200, 241);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "INTESTAZIONE DI STAMPA";
            // 
            // lblHeaderResult
            // 
            this.lblHeaderResult.Location = new System.Drawing.Point(6, 137);
            this.lblHeaderResult.Name = "lblHeaderResult";
            this.lblHeaderResult.Size = new System.Drawing.Size(188, 24);
            this.lblHeaderResult.TabIndex = 2;
            this.lblHeaderResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 202);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "RESET";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnHeaderReset_Click);
            // 
            // btnHeaderSave
            // 
            this.btnHeaderSave.Location = new System.Drawing.Point(6, 163);
            this.btnHeaderSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHeaderSave.Name = "btnHeaderSave";
            this.btnHeaderSave.Size = new System.Drawing.Size(188, 35);
            this.btnHeaderSave.TabIndex = 1;
            this.btnHeaderSave.Text = "SALVA INTESTAZIONE";
            this.btnHeaderSave.UseVisualStyleBackColor = true;
            this.btnHeaderSave.Click += new System.EventHandler(this.btnHeaderSave_Click);
            // 
            // txtHeader
            // 
            this.txtHeader.Location = new System.Drawing.Point(6, 35);
            this.txtHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHeader.Multiline = true;
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Size = new System.Drawing.Size(190, 76);
            this.txtHeader.TabIndex = 0;
            // 
            // btnSaveData
            // 
            this.btnSaveData.Location = new System.Drawing.Point(215, 285);
            this.btnSaveData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(200, 28);
            this.btnSaveData.TabIndex = 3;
            this.btnSaveData.Text = "SALVA DATI";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOk.Image = global::EasyPlanner.Properties.Resources.okImage;
            this.btnOk.Location = new System.Drawing.Point(11, 323);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(404, 51);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(110)))), ((int)(((byte)(153)))));
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(425, 8);
            this.pnlTop.TabIndex = 6;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 385);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.btnSaveData);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Password);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SETTINGS";
            this.Password.ResumeLayout(false);
            this.Password.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblOldPassword;
        private GroupBox Password;
        private Button btnPasswordChange;
        private TextBox txtNewPassword;
        private Label lblNewPassword;
        private TextBox txtOldPassword;
        private Label lblPasswordResult;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnHeaderSave;
        private TextBox txtHeader;
        public CheckBox chkAccessMode;
        private Button btnOk;
        private Button btnPasswordReset;
        private Label lblHeaderResult;
        private Button btnSaveData;
        private Panel pnlTop;
        private Button button1;
    }
}