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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmDoktorGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmGirisler frmGirisler = new FrmGirisler();
            frmGirisler.Show();
            this.Hide();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT Ad, Soyad, Brans, TC_Kimlik FROM Tbl_Doktorlar WHERE TC_Kimlik = @p1 AND Sifre = @p2", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", maskedTC_SignIn.Text);
            cmd.Parameters.AddWithValue("@p2", txbSifreSignIn.Text);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                FrmDoktorDetay frmDoktorDetay = new FrmDoktorDetay();

                frmDoktorDetay.Ad = reader.GetString(0);
                frmDoktorDetay.Soyad = reader.GetString(1);
                frmDoktorDetay.Brans = reader.GetString(2);
                frmDoktorDetay.TcKim = reader.GetString(3);

                frmDoktorDetay.Show();
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
    }
}
