using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hastane_Yonetim_Dotnet_48
{
    public partial class FrmHastaBilgiGuncelle : Form
    {
        public FrmHastaBilgiGuncelle()
        {
            InitializeComponent();
        }
        public short ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TcKim { get; set; }
        public string Tel { get; set; }
        public string Cinsiyet { get; set; }

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void FrmHastaBilgiGuncelle_Load(object sender, EventArgs e)
        {
            txbAd.Text = Ad;
            txbSoyad.Text = Soyad;
            maskedTC_SignUp.Text = TcKim;
            maskedTel.Text = Tel;
            comboCinsiyet.Text = Cinsiyet;

        }

        private void btnHastaBilgiGuncelle_Click(object sender, EventArgs e)
        {
            if (txbSifreSignUp.Text == txbSifreSignUpConf.Text)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Tbl_Hastalar Set AD = @ad, SOYAD = @soyad, TC_Kimlik = @tc, Telefon = @tel, Sifre = @sifre, Cinsiyet = @cinsiyet where ID = @id", bgl.Baglanti());
                cmd.Parameters.AddWithValue("@ad", txbAd.Text);
                cmd.Parameters.AddWithValue("@soyad", txbSoyad.Text.ToUpper());
                cmd.Parameters.AddWithValue("@tc", maskedTC_SignUp.Text);
                cmd.Parameters.AddWithValue("@tel", maskedTel.Text);
                cmd.Parameters.AddWithValue("@sifre", txbSifreSignUp.Text);
                cmd.Parameters.AddWithValue("@cinsiyet", comboCinsiyet.Text);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();

                bgl.Baglanti().Close();

                MessageBox.Show("Bilgileriniz güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmHastaGiris frmHastaGiris = new FrmHastaGiris();
                frmHastaGiris.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Şifre tekrarında hata yaptınız. Tekrar giriniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbSifreSignUp.Clear();
                txbSifreSignUpConf.Clear();
            }
        }

        private void FrmHastaBilgiGuncelle_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmHastaGiris frmHastaGiris = new FrmHastaGiris();
            frmHastaGiris.Show();
            this.Hide();
            
        }
    }
}
