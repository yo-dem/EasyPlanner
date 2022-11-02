namespace EasyPlanner.Forms
{
    partial class DeleteForm
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
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAnnulla.Location = new System.Drawing.Point(14, 92);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(320, 55);
            this.btnAnnulla.TabIndex = 0;
            this.btnAnnulla.Text = "ANNULLA";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            this.btnAnnulla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnAnnulla_KeyDown);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOk.ForeColor = System.Drawing.Color.Red;
            this.btnOk.Image = global::EasyPlanner.Properties.Resources.trashImage;
            this.btnOk.Location = new System.Drawing.Point(341, 92);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(146, 55);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(14, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(275, 28);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "ELIMINARE DEFINITIVAMENTE";
            // 
            // lblText
            // 
            this.lblText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblText.Location = new System.Drawing.Point(14, 40);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(473, 31);
            this.lblText.TabIndex = 3;
            this.lblText.Text = "LABEL";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DeleteForm
            // 
            this.AcceptButton = this.btnAnnulla;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 161);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAnnulla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DeleteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ELIMINA ELEMENTO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnAnnulla;
        private Button btnOk;
        private Label lblTitle;
        private Label lblText;
    }
}