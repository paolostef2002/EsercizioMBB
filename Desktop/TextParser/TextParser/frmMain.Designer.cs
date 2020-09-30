﻿namespace TextParser
{
    partial class frmMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFolderSource = new System.Windows.Forms.Label();
            this.txtFolderSource = new System.Windows.Forms.TextBox();
            this.btnFolderSource = new System.Windows.Forms.Button();
            this.btnFolderDestination = new System.Windows.Forms.Button();
            this.txtFolderDestination = new System.Windows.Forms.TextBox();
            this.lblFolderDestination = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.dgvFragments = new System.Windows.Forms.DataGridView();
            this.lblPreview = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.colFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRowIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdentifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFragments)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFolderSource
            // 
            this.lblFolderSource.AutoSize = true;
            this.lblFolderSource.Location = new System.Drawing.Point(12, 25);
            this.lblFolderSource.Name = "lblFolderSource";
            this.lblFolderSource.Size = new System.Drawing.Size(90, 13);
            this.lblFolderSource.TabIndex = 0;
            this.lblFolderSource.Text = "Cartella di origine:";
            // 
            // txtFolderSource
            // 
            this.txtFolderSource.Enabled = false;
            this.txtFolderSource.Location = new System.Drawing.Point(133, 22);
            this.txtFolderSource.Name = "txtFolderSource";
            this.txtFolderSource.Size = new System.Drawing.Size(610, 20);
            this.txtFolderSource.TabIndex = 1;
            // 
            // btnFolderSource
            // 
            this.btnFolderSource.Location = new System.Drawing.Point(749, 20);
            this.btnFolderSource.Name = "btnFolderSource";
            this.btnFolderSource.Size = new System.Drawing.Size(39, 23);
            this.btnFolderSource.TabIndex = 2;
            this.btnFolderSource.Text = "...";
            this.btnFolderSource.UseVisualStyleBackColor = true;
            this.btnFolderSource.Click += new System.EventHandler(this.btnFolderSource_Click);
            // 
            // btnFolderDestination
            // 
            this.btnFolderDestination.Location = new System.Drawing.Point(749, 62);
            this.btnFolderDestination.Name = "btnFolderDestination";
            this.btnFolderDestination.Size = new System.Drawing.Size(39, 23);
            this.btnFolderDestination.TabIndex = 5;
            this.btnFolderDestination.Text = "...";
            this.btnFolderDestination.UseVisualStyleBackColor = true;
            this.btnFolderDestination.Click += new System.EventHandler(this.btnFolderDestination_Click);
            // 
            // txtFolderDestination
            // 
            this.txtFolderDestination.Enabled = false;
            this.txtFolderDestination.Location = new System.Drawing.Point(133, 64);
            this.txtFolderDestination.Name = "txtFolderDestination";
            this.txtFolderDestination.Size = new System.Drawing.Size(610, 20);
            this.txtFolderDestination.TabIndex = 4;
            // 
            // lblFolderDestination
            // 
            this.lblFolderDestination.AutoSize = true;
            this.lblFolderDestination.Location = new System.Drawing.Point(12, 67);
            this.lblFolderDestination.Name = "lblFolderDestination";
            this.lblFolderDestination.Size = new System.Drawing.Size(118, 13);
            this.lblFolderDestination.TabIndex = 3;
            this.lblFolderDestination.Text = "Cartella di destinazione:";
            // 
            // btnScan
            // 
            this.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnScan.Location = new System.Drawing.Point(15, 104);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(773, 32);
            this.btnScan.TabIndex = 6;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // dgvFragments
            // 
            this.dgvFragments.AllowUserToAddRows = false;
            this.dgvFragments.AllowUserToDeleteRows = false;
            this.dgvFragments.AllowUserToResizeColumns = false;
            this.dgvFragments.AllowUserToResizeRows = false;
            this.dgvFragments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFragments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFilename,
            this.colRowIndex,
            this.colIdentifier,
            this.colText});
            this.dgvFragments.Location = new System.Drawing.Point(15, 165);
            this.dgvFragments.Name = "dgvFragments";
            this.dgvFragments.ReadOnly = true;
            this.dgvFragments.RowHeadersVisible = false;
            this.dgvFragments.Size = new System.Drawing.Size(773, 150);
            this.dgvFragments.TabIndex = 7;
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Location = new System.Drawing.Point(373, 149);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(54, 13);
            this.lblPreview.TabIndex = 8;
            this.lblPreview.Text = "Anteprima";
            // 
            // btnGenerate
            // 
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerate.Location = new System.Drawing.Point(15, 321);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(773, 32);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "Genera Files";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(15, 359);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(773, 217);
            this.rtbLog.TabIndex = 10;
            this.rtbLog.Text = "";
            // 
            // colFilename
            // 
            this.colFilename.HeaderText = "File Origine";
            this.colFilename.Name = "colFilename";
            this.colFilename.ReadOnly = true;
            // 
            // colRowIndex
            // 
            this.colRowIndex.HeaderText = "Riga";
            this.colRowIndex.Name = "colRowIndex";
            this.colRowIndex.ReadOnly = true;
            this.colRowIndex.Width = 50;
            // 
            // colIdentifier
            // 
            this.colIdentifier.HeaderText = "Identificativo";
            this.colIdentifier.Name = "colIdentifier";
            this.colIdentifier.ReadOnly = true;
            // 
            // colText
            // 
            this.colText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colText.HeaderText = "Testo";
            this.colText.Name = "colText";
            this.colText.ReadOnly = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 588);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.dgvFragments);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.btnFolderDestination);
            this.Controls.Add(this.txtFolderDestination);
            this.Controls.Add(this.lblFolderDestination);
            this.Controls.Add(this.btnFolderSource);
            this.Controls.Add(this.txtFolderSource);
            this.Controls.Add(this.lblFolderSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.Text = "Parser di testo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFragments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFolderSource;
        private System.Windows.Forms.TextBox txtFolderSource;
        private System.Windows.Forms.Button btnFolderSource;
        private System.Windows.Forms.Button btnFolderDestination;
        private System.Windows.Forms.TextBox txtFolderDestination;
        private System.Windows.Forms.Label lblFolderDestination;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.DataGridView dgvFragments;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRowIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentifier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colText;
        private System.Windows.Forms.RichTextBox rtbLog;
    }
}
