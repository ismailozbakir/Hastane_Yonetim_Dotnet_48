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
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmSekreterGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmGirisler frmGirisler = new FrmGirisler();
            frmGirisler.Show();
            this.Hide();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_Sekreter WHERE SekreterTC = @p1 AND SekreterSifre = @p2", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", maskedTC_SignIn.Text);
            cmd.Parameters.AddWithValue("@p2", txbSifreSignIn.Text);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                FrmSekreterDetay frmSekreterDetay = new FrmSekreterDetay();

                frmSekreterDetay.AdSoyad = reader.GetString(1);
                frmSekreterDetay.TcKim = reader.GetString(2);

                frmSekreterDetay.Show();
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
