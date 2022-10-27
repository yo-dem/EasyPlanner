namespace EasyPlanner.Forms
{
    partial class ProductEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductEditForm));
            this.nudAliquota = new System.Windows.Forms.NumericUpDown();
            this.lblAliquota = new System.Windows.Forms.Label();
            this.nudQnt = new System.Windows.Forms.NumericUpDown();
            this.lblQnt = new System.Windows.Forms.Label();
            this.btnRemoveIVA = new System.Windows.Forms.Button();
            this.btnAddIVA = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblPrezzoIvato = new System.Windows.Forms.Label();
            this.txtPrezzoIvato = new System.Windows.Forms.TextBox();
            this.lblPrezzoNetto = new System.Windows.Forms.Label();
            this.txtPrezzoNetto = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.lblDescrizione = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudAliquota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQnt)).BeginInit();
            this.SuspendLayout();
            // 
            // nudAliquota
            // 
            this.nudAliquota.Location = new System.Drawing.Point(14, 295);
            this.nudAliquota.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAliquota.Name = "nudAliquota";
            this.nudAliquota.Size = new System.Drawing.Size(136, 27);
            this.nudAliquota.TabIndex = 3;
            this.nudAliquota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAliquota.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // lblAliquota
            // 
            this.lblAliquota.AutoSize = true;
            this.lblAliquota.Location = new System.Drawing.Point(14, 272);
            this.lblAliquota.Name = "lblAliquota";
            this.lblAliquota.Size = new System.Drawing.Size(78, 20);
            this.lblAliquota.TabIndex = 0;
            this.lblAliquota.Text = "ALIQUOTA";
            // 
            // nudQnt
            // 
            this.nudQnt.Location = new System.Drawing.Point(157, 295);
            this.nudQnt.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudQnt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQnt.Name = "nudQnt";
            this.nudQnt.Size = new System.Drawing.Size(59, 27);
            this.nudQnt.TabIndex = 4;
            this.nudQnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudQnt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQnt
            // 
            this.lblQnt.AutoSize = true;
            this.lblQnt.Location = new System.Drawing.Point(157, 272);
            this.lblQnt.Name = "lblQnt";
            this.lblQnt.Size = new System.Drawing.Size(39, 20);
            this.lblQnt.TabIndex = 0;
            this.lblQnt.Text = "QNT";
            // 
            // btnRemoveIVA
            // 
            this.btnRemoveIVA.Location = new System.Drawing.Point(157, 407);
            this.btnRemoveIVA.Name = "btnRemoveIVA";
            this.btnRemoveIVA.Size = new System.Drawing.Size(59, 33);
            this.btnRemoveIVA.TabIndex = 8;
            this.btnRemoveIVA.Text = "- IVA";
            this.btnRemoveIVA.UseVisualStyleBackColor = true;
            this.btnRemoveIVA.Click += new System.EventHandler(this.btnRemoveIVA_Click);
            // 
            // btnAddIVA
            // 
            this.btnAddIVA.Location = new System.Drawing.Point(157, 351);
            this.btnAddIVA.Name = "btnAddIVA";
            this.btnAddIVA.Size = new System.Drawing.Size(59, 32);
            this.btnAddIVA.TabIndex = 6;
            this.btnAddIVA.Text = "+ IVA";
            this.btnAddIVA.UseVisualStyleBackColor = true;
            this.btnAddIVA.Click += new System.EventHandler(this.btnAddIVA_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOk.Image = global::EasyPlanner.Properties.Resources.okImage;
            this.btnOk.Location = new System.Drawing.Point(222, 443);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(649, 91);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "SALVA MODIFICHE";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblPrezzoIvato
            // 
            this.lblPrezzoIvato.AutoSize = true;
            this.lblPrezzoIvato.Location = new System.Drawing.Point(14, 384);
            this.lblPrezzoIvato.Name = "lblPrezzoIvato";
            this.lblPrezzoIvato.Size = new System.Drawing.Size(106, 20);
            this.lblPrezzoIvato.TabIndex = 0;
            this.lblPrezzoIvato.Text = "PREZZO IVATO";
            // 
            // txtPrezzoIvato
            // 
            this.txtPrezzoIvato.Location = new System.Drawing.Point(14, 407);
            this.txtPrezzoIvato.Name = "txtPrezzoIvato";
            this.txtPrezzoIvato.Size = new System.Drawing.Size(135, 27);
            this.txtPrezzoIvato.TabIndex = 7;
            this.txtPrezzoIvato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrezzoNetto
            // 
            this.lblPrezzoNetto.AutoSize = true;
            this.lblPrezzoNetto.Location = new System.Drawing.Point(14, 328);
            this.lblPrezzoNetto.Name = "lblPrezzoNetto";
            this.lblPrezzoNetto.Size = new System.Drawing.Size(112, 20);
            this.lblPrezzoNetto.TabIndex = 0;
            this.lblPrezzoNetto.Text = "PREZZO NETTO";
            // 
            // txtPrezzoNetto
            // 
            this.txtPrezzoNetto.Location = new System.Drawing.Point(14, 351);
            this.txtPrezzoNetto.Name = "txtPrezzoNetto";
            this.txtPrezzoNetto.Size = new System.Drawing.Size(135, 27);
            this.txtPrezzoNetto.TabIndex = 5;
            this.txtPrezzoNetto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(223, 87);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(46, 20);
            this.lblNote.TabIndex = 0;
            this.lblNote.Text = "NOTE";
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.Location = new System.Drawing.Point(223, 109);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(647, 327);
            this.txtNote.TabIndex = 9;
            // 
            // dtpData
            // 
            this.dtpData.CustomFormat = "";
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(14, 15);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(202, 27);
            this.dtpData.TabIndex = 0;
            this.dtpData.TabStop = false;
            // 
            // lblDescrizione
            // 
            this.lblDescrizione.AutoSize = true;
            this.lblDescrizione.Location = new System.Drawing.Point(14, 143);
            this.lblDescrizione.Name = "lblDescrizione";
            this.lblDescrizione.Size = new System.Drawing.Size(101, 20);
            this.lblDescrizione.TabIndex = 0;
            this.lblDescrizione.Text = "DESCRIZIONE";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(14, 165);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(202, 103);
            this.txtDescrizione.TabIndex = 2;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(14, 87);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(60, 20);
            this.lblMarca.TabIndex = 0;
            this.lblMarca.Text = "MARCA";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(14, 109);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(202, 27);
            this.txtMarca.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Image = global::EasyPlanner.Properties.Resources.trashImage;
            this.btnDelete.Location = new System.Drawing.Point(14, 443);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(201, 91);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "ELIMINA IL PRODOTTO";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ProductEditForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 548);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.nudAliquota);
            this.Controls.Add(this.lblAliquota);
            this.Controls.Add(this.nudQnt);
            this.Controls.Add(this.lblQnt);
            this.Controls.Add(this.btnRemoveIVA);
            this.Controls.Add(this.btnAddIVA);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblPrezzoIvato);
            this.Controls.Add(this.txtPrezzoIvato);
            this.Controls.Add(this.lblPrezzoNetto);
            this.Controls.Add(this.txtPrezzoNetto);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.lblDescrizione);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.txtMarca);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(903, 595);
            this.Name = "ProductEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MODIFICA PRODOTTO";
            ((System.ComponentModel.ISupportInitialize)(this.nudAliquota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQnt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericUpDown nudAliquota;
        private Label lblAliquota;
        private NumericUpDown nudQnt;
        private Label lblQnt;
        private Button btnRemoveIVA;
        private Button btnAddIVA;
        private Button btnOk;
        private Label lblPrezzoIvato;
        private TextBox txtPrezzoIvato;
        private Label lblPrezzoNetto;
        private TextBox txtPrezzoNetto;
        private Label lblNote;
        private TextBox txtNote;
        private DateTimePicker dtpData;
        private Label lblDescrizione;
        private Label lblMarca;
        private TextBox txtMarca;
        private Button btnDelete;
        public TextBox txtDescrizione;
    }
}