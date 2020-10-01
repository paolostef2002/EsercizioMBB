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
            this.txtSeparator = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRootPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
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
            // txtSeparator
            // 
            this.txtSeparator.Location = new System.Drawing.Point(143, 44);
            this.txtSeparator.MaxLength = 1;
            this.txtSeparator.Name = "txtSeparator";
            this.txtSeparator.Size = new System.Drawing.Size(31, 20);
            this.txtSeparator.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Separatore identificatore:";
            // 
            // txtRootPath
            // 
            this.txtRootPath.Location = new System.Drawing.Point(143, 70);
            this.txtRootPath.Name = "txtRootPath";
            this.txtRootPath.Size = new System.Drawing.Size(429, 20);
            this.txtRootPath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Directory radice:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 99);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(602, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Imposta";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "[value]";
            // 
            // btnFolderDestination
            // 
            this.btnFolderDestination.Location = new System.Drawing.Point(578, 68);
            this.btnFolderDestination.Name = "btnFolderDestination";
            this.btnFolderDestination.Size = new System.Drawing.Size(39, 23);
            this.btnFolderDestination.TabIndex = 8;
            this.btnFolderDestination.Text = "...";
            this.btnFolderDestination.UseVisualStyleBackColor = true;
            this.btnFolderDestination.Click += new System.EventHandler(this.btnFolderDestination_Click);
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 134);
            this.Controls.Add(this.btnFolderDestination);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRootPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSeparator);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHeaderSymbol);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Configurazione";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHeaderSymbol;
        private System.Windows.Forms.TextBox txtSeparator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRootPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFolderDestination;
    }
}