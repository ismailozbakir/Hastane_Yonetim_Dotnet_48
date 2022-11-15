namespace Hastane_Yonetim_Dotnet_48
{
    partial class FrmDoktorPaneli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDoktorPaneli));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.txbAd = new System.Windows.Forms.TextBox();
            this.txbSoyad = new System.Windows.Forms.TextBox();
            this.txbSifre = new System.Windows.Forms.TextBox();
            this.cmbBrans = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mskTC = new System.Windows.Forms.MaskedTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txbAranan = new System.Windows.Forms.TextBox();
            this.btnDoktorListele = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ad :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Soyad :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Branş :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tc Kimlik :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "Şifre :";
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(36, 285);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(74, 41);
            this.btnEkle.TabIndex = 5;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(125, 285);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(74, 41);
            this.btnSil.TabIndex = 6;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(36, 342);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(265, 41);
            this.btnGuncelle.TabIndex = 7;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // txbAd
            // 
            this.txbAd.Location = new System.Drawing.Point(143, 20);
            this.txbAd.Name = "txbAd";
            this.txbAd.Size = new System.Drawing.Size(159, 34);
            this.txbAd.TabIndex = 1;
            // 
            // txbSoyad
            // 
            this.txbSoyad.Location = new System.Drawing.Point(143, 71);
            this.txbSoyad.Name = "txbSoyad";
            this.txbSoyad.Size = new System.Drawing.Size(159, 34);
            this.txbSoyad.TabIndex = 2;
            // 
            // txbSifre
            // 
            this.txbSifre.Location = new System.Drawing.Point(143, 227);
            this.txbSifre.Name = "txbSifre";
            this.txbSifre.Size = new System.Drawing.Size(159, 34);
            this.txbSifre.TabIndex = 5;
            this.txbSifre.UseSystemPasswordChar = true;
            this.txbSifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbSifre_KeyDown);
            // 
            // cmbBrans
            // 
            this.cmbBrans.FormattingEnabled = true;
            this.cmbBrans.Location = new System.Drawing.Point(143, 122);
            this.cmbBrans.Name = "cmbBrans";
            this.cmbBrans.Size = new System.Drawing.Size(158, 37);
            this.cmbBrans.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(328, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(733, 339);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // mskTC
            // 
            this.mskTC.Location = new System.Drawing.Point(144, 176);
            this.mskTC.Mask = "00000000000";
            this.mskTC.Name = "mskTC";
            this.mskTC.PromptChar = ' ';
            this.mskTC.Size = new System.Drawing.Size(157, 34);
            this.mskTC.TabIndex = 4;
            this.mskTC.ValidatingType = typeof(int);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(215, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 41);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txbAranan
            // 
            this.txbAranan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txbAranan.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txbAranan.Location = new System.Drawing.Point(328, 15);
            this.txbAranan.Name = "txbAranan";
            this.txbAranan.Size = new System.Drawing.Size(352, 30);
            this.txbAranan.TabIndex = 15;
            this.txbAranan.Text = "Doktorlar tablosunda arama yap";
            this.txbAranan.Click += new System.EventHandler(this.txbAranan_Click);
            this.txbAranan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbAranan_KeyDown);
            this.txbAranan.Leave += new System.EventHandler(this.txbAranan_Leave);
            // 
            // btnDoktorListele
            // 
            this.btnDoktorListele.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDoktorListele.Location = new System.Drawing.Point(840, 15);
            this.btnDoktorListele.Name = "btnDoktorListele";
            this.btnDoktorListele.Size = new System.Drawing.Size(221, 32);
            this.btnDoktorListele.TabIndex = 16;
            this.btnDoktorListele.Text = "Tüm Doktorları Listele";
            this.btnDoktorListele.UseVisualStyleBackColor = true;
            this.btnDoktorListele.Click += new System.EventHandler(this.btnDoktorListele_Click);
            // 
            // FrmDoktorPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1073, 408);
            this.Controls.Add(this.btnDoktorListele);
            this.Controls.Add(this.txbAranan);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.mskTC);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmbBrans);
            this.Controls.Add(this.txbSifre);
            this.Controls.Add(this.txbSoyad);
            this.Controls.Add(this.txbAd);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "FrmDoktorPaneli";
            this.Text = "Doktor Paneli";
            this.Load += new System.EventHandler(this.FrmDoktorPaneli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.TextBox txbAd;
        private System.Windows.Forms.TextBox txbSoyad;
        private System.Windows.Forms.TextBox txbSifre;
        private System.Windows.Forms.ComboBox cmbBrans;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MaskedTextBox mskTC;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txbAranan;
        private System.Windows.Forms.Button btnDoktorListele;
    }
}