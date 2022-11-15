namespace Hastane_Yonetim_Dotnet_48
{
    partial class FrmBransPaneli
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBransPaneli));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataGridBranslarPanel = new System.Windows.Forms.DataGridView();
            this.txbBrans = new System.Windows.Forms.TextBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBranslarPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridBranslarPanel
            // 
            this.dataGridBranslarPanel.AllowUserToAddRows = false;
            this.dataGridBranslarPanel.AllowUserToDeleteRows = false;
            this.dataGridBranslarPanel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridBranslarPanel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridBranslarPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBranslarPanel.Location = new System.Drawing.Point(291, 12);
            this.dataGridBranslarPanel.Name = "dataGridBranslarPanel";
            this.dataGridBranslarPanel.ReadOnly = true;
            this.dataGridBranslarPanel.RowHeadersWidth = 51;
            this.dataGridBranslarPanel.RowTemplate.Height = 24;
            this.dataGridBranslarPanel.Size = new System.Drawing.Size(389, 170);
            this.dataGridBranslarPanel.TabIndex = 27;
            this.dataGridBranslarPanel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridBranslarPanel_CellClick);
            // 
            // txbBrans
            // 
            this.txbBrans.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txbBrans.Location = new System.Drawing.Point(24, 31);
            this.txbBrans.Name = "txbBrans";
            this.txbBrans.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbBrans.Size = new System.Drawing.Size(241, 34);
            this.txbBrans.TabIndex = 24;
            this.txbBrans.Text = "yeni branş";
            this.txbBrans.Click += new System.EventHandler(this.txbBrans_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(166, 88);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(99, 41);
            this.btnSil.TabIndex = 21;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(23, 88);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(119, 41);
            this.btnEkle.TabIndex = 20;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(24, 141);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(241, 41);
            this.btnExit.TabIndex = 28;
            this.btnExit.Text = "Çıkış";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmBransPaneli
            // 
            this.AcceptButton = this.btnEkle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(689, 194);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dataGridBranslarPanel);
            this.Controls.Add(this.txbBrans);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "FrmBransPaneli";
            this.Text = "Branş Paneli";
            this.Load += new System.EventHandler(this.FrmBransPaneli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBranslarPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dataGridBranslarPanel;
        private System.Windows.Forms.TextBox txbBrans;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnExit;
    }
}