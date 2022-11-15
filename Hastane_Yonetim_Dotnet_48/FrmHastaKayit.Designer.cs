namespace Hastane_Yonetim_Dotnet_48
{
    partial class FrmHastaKayit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHastaKayit));
            this.txbSifreSignUp = new System.Windows.Forms.TextBox();
            this.maskedTC_SignUp = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTel = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboCinsiyet = new System.Windows.Forms.ComboBox();
            this.txbSifreSignUpConf = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.txbAd = new System.Windows.Forms.TextBox();
            this.txbSoyad = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbSifreSignUp
            // 
            this.txbSifreSignUp.Location = new System.Drawing.Point(170, 279);
            this.txbSifreSignUp.Name = "txbSifreSignUp";
            this.txbSifreSignUp.Size = new System.Drawing.Size(171, 34);
            this.txbSifreSignUp.TabIndex = 6;
            this.txbSifreSignUp.UseSystemPasswordChar = true;
            // 
            // maskedTC_SignUp
            // 
            this.maskedTC_SignUp.Location = new System.Drawing.Point(170, 129);
            this.maskedTC_SignUp.Mask = "00000000000";
            this.maskedTC_SignUp.Name = "maskedTC_SignUp";
            this.maskedTC_SignUp.PromptChar = ' ';
            this.maskedTC_SignUp.Size = new System.Drawing.Size(171, 34);
            this.maskedTC_SignUp.TabIndex = 3;
            this.maskedTC_SignUp.ValidatingType = typeof(int);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Şifre :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "TC Kimlik :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ad :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 29);
            this.label4.TabIndex = 11;
            this.label4.Text = "Soyad :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 29);
            this.label5.TabIndex = 13;
            this.label5.Text = "Telefon :";
            // 
            // maskedTel
            // 
            this.maskedTel.Location = new System.Drawing.Point(170, 177);
            this.maskedTel.Mask = "(999) 000-0000";
            this.maskedTel.Name = "maskedTel";
            this.maskedTel.Size = new System.Drawing.Size(171, 34);
            this.maskedTel.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 29);
            this.label6.TabIndex = 15;
            this.label6.Text = "Cinsiyet :";
            // 
            // comboCinsiyet
            // 
            this.comboCinsiyet.FormattingEnabled = true;
            this.comboCinsiyet.Items.AddRange(new object[] {
            "Erkek",
            "Kadın"});
            this.comboCinsiyet.Location = new System.Drawing.Point(170, 222);
            this.comboCinsiyet.Name = "comboCinsiyet";
            this.comboCinsiyet.Size = new System.Drawing.Size(171, 37);
            this.comboCinsiyet.TabIndex = 5;
            // 
            // txbSifreSignUpConf
            // 
            this.txbSifreSignUpConf.Location = new System.Drawing.Point(170, 329);
            this.txbSifreSignUpConf.Name = "txbSifreSignUpConf";
            this.txbSifreSignUpConf.Size = new System.Drawing.Size(171, 34);
            this.txbSifreSignUpConf.TabIndex = 7;
            this.txbSifreSignUpConf.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 29);
            this.label7.TabIndex = 17;
            this.label7.Text = "Şifre Tekrar :";
            // 
            // btnSignUp
            // 
            this.btnSignUp.Location = new System.Drawing.Point(222, 386);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(119, 39);
            this.btnSignUp.TabIndex = 19;
            this.btnSignUp.Text = "Kaydet";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // txbAd
            // 
            this.txbAd.Location = new System.Drawing.Point(171, 23);
            this.txbAd.Name = "txbAd";
            this.txbAd.Size = new System.Drawing.Size(170, 34);
            this.txbAd.TabIndex = 1;
            // 
            // txbSoyad
            // 
            this.txbSoyad.Location = new System.Drawing.Point(171, 78);
            this.txbSoyad.Name = "txbSoyad";
            this.txbSoyad.Size = new System.Drawing.Size(170, 34);
            this.txbSoyad.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(59, 386);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(119, 39);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmHastaKayit
            // 
            this.AcceptButton = this.btnSignUp;
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(390, 437);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txbSoyad);
            this.Controls.Add(this.txbAd);
            this.Controls.Add(this.btnSignUp);
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
            this.Name = "FrmHastaKayit";
            this.Text = "Hasta Kayıt Paneli";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmHastaKayit_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbSifreSignUp;
        private System.Windows.Forms.MaskedTextBox maskedTC_SignUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboCinsiyet;
        private System.Windows.Forms.TextBox txbSifreSignUpConf;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.TextBox txbAd;
        private System.Windows.Forms.TextBox txbSoyad;
        private System.Windows.Forms.Button btnCancel;
    }
}