namespace TextParser
{
    partial class FrmConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtHeaderSymbol = new System.Windows.Forms.TextBox();
            this.txtRootPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnFolderDestination = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Simbolo inizio frammento:";
            // 
            // txtHeaderSymbol
            // 
            this.txtHeaderSymbol.Location = new System.Drawing.Point(143, 17);
            this.txtHeaderSymbol.MaxLength = 10;
            this.txtHeaderSymbol.Name = "txtHeaderSymbol";
            this.txtHeaderSymbol.Size = new System.Drawing.Size(100, 20);
            this.txtHeaderSymbol.TabIndex = 1;
            // 
            // txtRootPath
            // 
            this.txtRootPath.Location = new System.Drawing.Point(143, 43);
            this.txtRootPath.Name = "txtRootPath";
            this.txtRootPath.Size = new System.Drawing.Size(429, 20);
            this.txtRootPath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Directory radice:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 72);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(602, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Imposta";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnFolderDestination
            // 
            this.btnFolderDestination.Location = new System.Drawing.Point(578, 41);
            this.btnFolderDestination.Name = "btnFolderDestination";
            this.btnFolderDestination.Size = new System.Drawing.Size(39, 23);
            this.btnFolderDestination.TabIndex = 8;
            this.btnFolderDestination.Text = "...";
            this.btnFolderDestination.UseVisualStyleBackColor = true;
            this.btnFolderDestination.Click += new System.EventHandler(this.btnFolderDestination_Click);
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 102);
            this.Controls.Add(this.btnFolderDestination);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRootPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHeaderSymbol);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Configurazione";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHeaderSymbol;
        private System.Windows.Forms.TextBox txtRootPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnFolderDestination;
    }
}