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


namespace Hastane_Yonetim_Dotnet_48
{
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }

        SqlBaglantisi sqlCon = new SqlBaglantisi();
        private void btnSignUp_Click(object sender, EventArgs e)
        {


            SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Hastalar (Ad, Soyad, TC_Kimlik, Telefon, Sifre, Cinsiyet) VALUES (@h1, @h2, @h3, @h4, @h5, @h6)", sqlCon.Baglanti());

            if (txbSifreSignUp.Text == txbSifreSignUpConf.Text)
            {
                cmd.Parameters.AddWithValue("@h1", txbAd.Text);
                cmd.Parameters.AddWithValue("@h2", txbSoyad.Text.ToUpper());
                cmd.Parameters.AddWithValue("@h3", maskedTC_SignUp.Text);
                cmd.Parameters.AddWithValue("@h4", maskedTel.Text);
                cmd.Parameters.AddWithValue("@h6", comboCinsiyet.Text);
                cmd.Parameters.AddWithValue("@h5", txbSifreSignUp.Text);
                cmd.ExecuteNonQuery();

                sqlCon.Baglanti().Close();

                MessageBox.Show("Kaydınız gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmHastaGiris fr = new FrmHastaGiris();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Şifre tekrarında hata yaptınız. Tekrar giriniz.", "Hata!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbSifreSignUpConf.Clear();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FrmHastaGiris fr = new FrmHastaGiris();
            fr.Show();
            this.Hide();
        }

        private void FrmHastaKayit_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmHastaGiris fr = new FrmHastaGiris();
            fr.Show();
            this.Hide();
        }
    }
}
