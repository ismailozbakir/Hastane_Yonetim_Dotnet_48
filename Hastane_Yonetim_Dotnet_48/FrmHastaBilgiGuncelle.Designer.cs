namespace Hastane_Yonetim_Dotnet_48
{
    partial class FrmHastaBilgiGuncelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHastaBilgiGuncelle));
            this.btnBilgiGuncelle = new System.Windows.Forms.Button();
            this.txbSifreSignUpConf = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboCinsiyet = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.maskedTel = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbSifreSignUp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTC_SignUp = new System.Windows.Forms.MaskedTextBox();
            this.txbSoyad = new System.Windows.Forms.TextBox();
            this.txbAd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBilgiGuncelle
            // 
            this.btnBilgiGuncelle.Location = new System.Drawing.Point(210, 401);
            this.btnBilgiGuncelle.Name = "btnBilgiGuncelle";
            this.btnBilgiGuncelle.Size = new System.Drawing.Size(126, 39);
            this.btnBilgiGuncelle.TabIndex = 34;
            this.btnBilgiGuncelle.Text = "Güncelle";
            this.btnBilgiGuncelle.UseVisualStyleBackColor = true;
            this.btnBilgiGuncelle.Click += new System.EventHandler(this.btnHastaBilgiGuncelle_Click);
            // 
            // txbSifreSignUpConf
            // 
            this.txbSifreSignUpConf.Location = new System.Drawing.Point(165, 344);
            this.txbSifreSignUpConf.Name = "txbSifreSignUpConf";
            this.txbSifreSignUpConf.Size = new System.Drawing.Size(171, 34);
            this.txbSifreSignUpConf.TabIndex = 7;
            this.txbSifreSignUpConf.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 29);
            this.label7.TabIndex = 32;
            this.label7.Text = "Şifre Tekrar :";
            // 
            // comboCinsiyet
            // 
            this.comboCinsiyet.FormattingEnabled = true;
            this.comboCinsiyet.Items.AddRange(new object[] {
            "Erkek",
            "Kadın"});
            this.comboCinsiyet.Location = new System.Drawing.Point(165, 237);
            this.comboCinsiyet.Name = "comboCinsiyet";
            this.comboCinsiyet.Size = new System.Drawing.Size(171, 37);
            this.comboCinsiyet.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 29);
            this.label6.TabIndex = 30;
            this.label6.Text = "Cinsiyet :";
            // 
            // maskedTel
            // 
            this.maskedTel.Location = new System.Drawing.Point(165, 192);
            this.maskedTel.Mask = "(999) 000-0000";
            this.maskedTel.Name = "maskedTel";
            this.maskedTel.Size = new System.Drawing.Size(171, 34);
            this.maskedTel.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 29);
            this.label5.TabIndex = 28;
            this.label5.Text = "Telefon :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 29);
            this.label4.TabIndex = 27;
            this.label4.Text = "Soyad :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 29);
            this.label1.TabIndex = 26;
            this.label1.Text = "Ad :";
            // 
            // txbSifreSignUp
            // 
            this.txbSifreSignUp.Location = new System.Drawing.Point(165, 294);
            this.txbSifreSignUp.Name = "txbSifreSignUp";
            this.txbSifreSignUp.Size = new System.Drawing.Size(171, 34);
            this.txbSifreSignUp.TabIndex = 6;
            this.txbSifreSignUp.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 29);
            this.label3.TabIndex = 23;
            this.label3.Text = "Şifre :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 29);
            this.label2.TabIndex = 22;
            this.label2.Text = "TC Kimlik :";
            // 
            // maskedTC_SignUp
            // 
            this.maskedTC_SignUp.Enabled = false;
            this.maskedTC_SignUp.Location = new System.Drawing.Point(165, 144);
            this.maskedTC_SignUp.Mask = "00000000000";
            this.maskedTC_SignUp.Name = "maskedTC_SignUp";
            this.maskedTC_SignUp.PromptChar = ' ';
            this.maskedTC_SignUp.Size = new System.Drawing.Size(171, 34);
            this.maskedTC_SignUp.TabIndex = 3;
            this.maskedTC_SignUp.ValidatingType = typeof(int);
            // 
            // txbSoyad
            // 
            this.txbSoyad.Enabled = false;
            this.txbSoyad.Location = new System.Drawing.Point(166, 93);
            this.txbSoyad.Name = "txbSoyad";
            this.txbSoyad.Size = new System.Drawing.Size(170, 34);
            this.txbSoyad.TabIndex = 2;
            // 
            // txbAd
            // 
            this.txbAd.Enabled = false;
            this.txbAd.Location = new System.Drawing.Point(166, 38);
            this.txbAd.Name = "txbAd";
            this.txbAd.Size = new System.Drawing.Size(170, 34);
            this.txbAd.TabIndex = 1;
            // 
            // FrmHastaBilgiGuncelle
            // 
            this.AcceptButton = this.btnBilgiGuncelle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(372, 463);
            this.Controls.Add(this.txbSoyad);
            this.Controls.Add(this.txbAd);
            this.Controls.Add(this.btnBilgiGuncelle);
            this.Controls.Add(this.txbSifreSignUpConf);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboCinsiyet);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maskedTel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbSifreSignUp);
            this.Controls.Add(this.maskedTC_SignUp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "FrmHastaBilgiGuncelle";
            this.Text = "Hasta Bilgi Güncelleme Paneli";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmHastaBilgiGuncelle_FormClosing);
            this.Load += new System.EventHandler(this.FrmHastaBilgiGuncelle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBilgiGuncelle;
        private System.Windows.Forms.TextBox txbSifreSignUpConf;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboCinsiyet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox maskedTel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbSifreSignUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTC_SignUp;
        private System.Windows.Forms.TextBox txbSoyad;
        private System.Windows.Forms.TextBox txbAd;
    }
}