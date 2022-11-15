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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }


        SqlBaglantisi bgl = new SqlBaglantisi();
        private void lnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit fr = new FrmHastaKayit();
            fr.Show();
            this.Hide();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_Hastalar WHERE TC_Kimlik = @p1 AND Sifre = @p2", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", maskedTC_SignIn.Text);
            cmd.Parameters.AddWithValue("@p2", txbSifreSignIn.Text);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                FrmHastaDetay frmHastaDetay = new FrmHastaDetay();

                frmHastaDetay.Ad = reader.GetString(1);
                frmHastaDetay.Soyad = reader.GetString(2).ToUpper();
                //frmHastaDetay.TcKim = maskedTC_SignIn.Text; // aşağıdaki yerine bu kod çalıştırılabilir.
                frmHastaDetay.TcKim = reader.GetString(3);

                frmHastaDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tc Kimlik No veya Şifre Hatalı!");
                maskedTC_SignIn.Clear();
                txbSifreSignIn.Clear();
                maskedTC_SignIn.Focus();
            }

            bgl.Baglanti().Close();
        }
        private void FrmHastaGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmGirisler fr = new FrmGirisler();
            fr.Show();
            this.Hide();
        }

    }
}
