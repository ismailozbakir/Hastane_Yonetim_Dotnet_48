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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        DataGridFont dataGridFont = new DataGridFont();
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Brans { get; set; }
        public string TcKim { get; set; }

        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            lblDoktorAdSoyad.Text = $"{Ad} {Soyad.ToUpper()}";
            lblDoktorTC.Text = TcKim;
            lblBrans.Text = Brans;

            dataGridFont.DataGridFontDuzenle(dataGridRandevuListesi, 12, 12, 32);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"SELECT Tarih, Saat, Durum, HastaTC, Duzenleyen FROM Tbl_Randevular WHERE Doktor = '{lblDoktorAdSoyad.Text}' ORDER BY ID", bgl.Baglanti());
            da.Fill(dt);
            dataGridRandevuListesi.DataSource = dt;
            dataGridRandevuListesi.FirstDisplayedScrollingRowIndex = dataGridRandevuListesi.RowCount - 1; // Llistenin en sonuna gelmek için


            dataGridFont.DataGridFontDuzenle(dataGridDuyuru, 11, 11, 16);
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT Duyuru AS DUYURULAR FROM Tbl_Duyurular", bgl.Baglanti());
            da2.Fill(dt2);
            dataGridDuyuru.DataSource = dt2;
            dataGridDuyuru.FirstDisplayedScrollingRowIndex = dataGridDuyuru.RowCount - 1; // Llistenin en sonuna gelmek için


        }

        private void btnDuyuru_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Duyuru AS DUYURULAR FROM Tbl_Duyurular", bgl.Baglanti());
            da.Fill(dt);

            FrmDuyurular frmDuyurular = new FrmDuyurular();
            frmDuyurular.DataTablosu = dt;
            frmDuyurular.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            FrmGirisler frmGirisler = new FrmGirisler();
            frmGirisler.Show();
            this.Hide();
        }

        private void FrmDoktorDetay_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmGirisler frmGirisler = new FrmGirisler();
            frmGirisler.Show();
            this.Hide();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

        }

    }
}
