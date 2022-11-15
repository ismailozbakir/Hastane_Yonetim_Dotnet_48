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
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }
        public string TcKim { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string SecilenTarih { get; set; }
        public string SecilenSaat { get; set; }
        public string SecilenBrans { get; set; }
        public string SecilenDoktor { get; set; }

        SqlBaglantisi bgl = new SqlBaglantisi();
        DataGridFont dataGridFont = new DataGridFont();


        private void FrmHastaDetay_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmHastaGiris fr = new FrmHastaGiris();
            fr.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            bgl.Baglanti().Close();
            Environment.Exit(0);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmHastaGiris fr = new FrmHastaGiris();
            fr.Show();
            this.Hide();
        }

        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            btnPrevious.Enabled = false;

            dataGridFont.DataGridFontDuzenle(dataGridAktifRandevu, 11, 11, 32);

            lblTC.Text = TcKim;
            lblAdSoyad.Text = $"{Ad} {Soyad}";

            // Geçmiş bir tarihden randevu alınamaması için.
            dateTimePickerTarih.Value = DateTime.Now;
            dateTimePickerTarih.MinDate = DateTime.Now;

            // Aktif Randevular

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"SELECT Tarih, Saat, Brans, Doktor FROM Tbl_Randevular WHERE HastaTC = '{TcKim}' AND Durum = 1 ORDER BY Tarih", bgl.Baglanti());
            da.Fill(dt);
            dataGridAktifRandevu.DataSource = dt;

            // Açık Randevular
            dataGridFont.DataGridFontDuzenle(dataGridAcikRandevu, 12, 12, 32);
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter($"SELECT Tarih, Saat, Brans, Doktor FROM Tbl_Randevular WHERE Durum = 0 AND Tarih = '{dateTimePickerTarih.Value.ToString("yyyyMMdd")}' ORDER BY ID", bgl.Baglanti());
            da2.Fill(dt2);
            dataGridAcikRandevu.DataSource = dt2;

            // Branş Çekme
            SqlCommand cmd = new SqlCommand("SELECT Branslar FROM Tbl_Branslar ORDER BY Branslar", bgl.Baglanti());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                comboBrans.Items.Add(reader.GetString(0));
                //comboBrans.Items.Add(reader[0]); // veya bu satır

            }

            reader.Close();
            bgl.Baglanti().Close();

        }

        private void comboBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridFont.DataGridFontDuzenle(dataGridAcikRandevu, 12, 12, 32);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"SELECT Tarih, Saat, Brans, Doktor FROM Tbl_Randevular WHERE Brans = '{comboBrans.Text}' AND Durum = 0 AND Tarih = '{dateTimePickerTarih.Value.ToString("yyyyMMdd")}'", bgl.Baglanti());
            da.Fill(dt);
            dataGridAcikRandevu.DataSource = dt;

        }

        private void lnkBilgiGuncelle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaBilgiGuncelle frmHastaBilgiGuncelle = new FrmHastaBilgiGuncelle();
            frmHastaBilgiGuncelle.Ad = Ad;
            frmHastaBilgiGuncelle.Soyad = Soyad;
            frmHastaBilgiGuncelle.TcKim = lblTC.Text;

            SqlCommand cmd = new SqlCommand("SELECT ID, Telefon, Cinsiyet FROM Tbl_Hastalar WHERE TC_Kimlik = @p1", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", lblTC.Text);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                frmHastaBilgiGuncelle.ID = reader.GetInt16(0);
                frmHastaBilgiGuncelle.Tel = reader.GetString(1);
                frmHastaBilgiGuncelle.Cinsiyet = reader.GetString(2);
            }

            reader.Close();
            bgl.Baglanti().Close();

            frmHastaBilgiGuncelle.Show();
            this.Hide();
        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Tbl_Randevular SET HastaTC = @p1, HastaAd = @p2, Soyad = @p3, Durum = 1 WHERE Tarih = @p4 AND Saat = @p5 AND Brans = @p6 AND Doktor = @p7", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", TcKim);
            cmd.Parameters.AddWithValue("@p2", Ad);
            cmd.Parameters.AddWithValue("@p3", Soyad.ToUpper());
            cmd.Parameters.AddWithValue("@p4", SecilenTarih);
            cmd.Parameters.AddWithValue("@p5", SecilenSaat);
            cmd.Parameters.AddWithValue("@p6", SecilenBrans);
            cmd.Parameters.AddWithValue("@p7", SecilenDoktor);

            cmd.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show($"ALINAN RANDEVU :\n------------------------\nTarih : {SecilenTarih}\nSaat : {SecilenSaat}\nBrans : {SecilenBrans}\nDoktor : {SecilenDoktor}");

            // Randevu alma işleminden sonraki işlemler
            // Data tablosu bilgilerini yeniden yükleyerek aynı ekranda en güncel olanı göstermek için
            dataGridFont.DataGridFontDuzenle(dataGridAktifRandevu, 12, 12, 32);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"SELECT Tarih, Saat, Brans, Doktor FROM Tbl_Randevular WHERE HastaTC = '{TcKim}' AND Durum = 1 ORDER BY ID", bgl.Baglanti());
            da.Fill(dt);
            dataGridAktifRandevu.DataSource = dt;

            // Açık Randevu Grid alanını güncelle
            dataGridFont.DataGridFontDuzenle(dataGridAcikRandevu, 12, 12, 32);
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter($"SELECT Tarih, Saat, Brans, Doktor FROM Tbl_Randevular WHERE Durum = 0 AND Tarih = '{dateTimePickerTarih.Value.ToString("yyyyMMdd")}' ORDER BY ID", bgl.Baglanti());
            da2.Fill(dt2);
            dataGridAcikRandevu.DataSource = dt2;

            //
            comboBrans.Text = default;
            comboBrans.Focus();

        }

        private void dataGridAcikRandevu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            SecilenTarih = dataGridAcikRandevu.Rows[rowIndex].Cells[0].Value.ToString();
            SecilenSaat = dataGridAcikRandevu.Rows[rowIndex].Cells[1].Value.ToString();
            SecilenBrans = dataGridAcikRandevu.Rows[rowIndex].Cells[2].Value.ToString();
            SecilenDoktor = dataGridAcikRandevu.Rows[rowIndex].Cells[3].Value.ToString();
            btnRandevuAl.Text = $"Seçilen Randevu : \n-------------------------\n\nTarih    : {SecilenTarih}\nSaat    : {SecilenSaat}\nBranş  : {SecilenBrans}\nDoktor : {SecilenDoktor}\n\n               RANDEVU AL";
        
        }

        private void dateTimePickerTarih_ValueChanged(object sender, EventArgs e)
        {
            // Açık Randevular
            dataGridFont.DataGridFontDuzenle(dataGridAcikRandevu, 12, 12, 32);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"SELECT Tarih, Saat, Brans, Doktor FROM Tbl_Randevular WHERE Durum = 0 AND Tarih = '{dateTimePickerTarih.Value.ToString("yyyyMMdd")}' ORDER BY ID", bgl.Baglanti());
            da.Fill(dt);
            dataGridAcikRandevu.DataSource = dt;

        }

        private void btnTumRandevular_Click(object sender, EventArgs e)
        {
            // Açık Randevular
            dataGridFont.DataGridFontDuzenle(dataGridAcikRandevu, 12, 12, 32);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"SELECT Tarih, Saat, Brans, Doktor FROM Tbl_Randevular WHERE Durum = 0 AND Tarih = '{dateTimePickerTarih.Value.ToString("yyyyMMdd")}' ORDER BY ID", bgl.Baglanti());
            da.Fill(dt);
            dataGridAcikRandevu.DataSource = dt;


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnPrevious.Enabled = true;
            int date = int.Parse(dateTimePickerTarih.Value.ToString("yyyyMMdd")) + 1;
            dateTimePickerTarih.Text = $"{date.ToString().Substring(6, 2)}.{date.ToString().Substring(4, 2)}.{date.ToString().Substring(0, 4)}";
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int minDate = int.Parse(DateTime.Now.ToString("yyyyMMdd"));

            int date = int.Parse(dateTimePickerTarih.Value.ToString("yyyyMMdd")) - 1;
            if (date > minDate)
            {
                dateTimePickerTarih.Text = $"{date.ToString().Substring(6, 2)}.{date.ToString().Substring(4, 2)}.{date.ToString().Substring(0, 4)}";
            }
            else if (date == minDate)
            {
                dateTimePickerTarih.Value = DateTime.Now;
                btnPrevious.Enabled = false;
            }
            else
            {
                btnPrevious.Enabled = false;
            }
        }

        private void btnRandevuIptal_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Tbl_Randevular SET HastaTC = @p1, HastaAd = @p2, Soyad = @p3, Durum = 0 WHERE Tarih = @p4 AND Saat = @p5 AND Brans = @p6 AND Doktor = @p7", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", "");
            cmd.Parameters.AddWithValue("@p2", "");
            cmd.Parameters.AddWithValue("@p3", "");
            cmd.Parameters.AddWithValue("@p4", SecilenTarih);
            cmd.Parameters.AddWithValue("@p5", SecilenSaat);
            cmd.Parameters.AddWithValue("@p6", SecilenBrans);
            cmd.Parameters.AddWithValue("@p7", SecilenDoktor);

            cmd.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show($"İPTAL EDİLEN RANDEVU BİLGİLERİ\n------------------------\nTarih : {SecilenTarih}\nSaat : {SecilenSaat}\nBrans : {SecilenBrans}\nDoktor : {SecilenDoktor}");


            // Aktif Randevular

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"SELECT Tarih, Saat, Brans, Doktor FROM Tbl_Randevular WHERE HastaTC = '{TcKim}' AND Durum = 1 ORDER BY Tarih", bgl.Baglanti());
            da.Fill(dt);
            dataGridAktifRandevu.DataSource = dt;

            // Açık Randevular
            dataGridFont.DataGridFontDuzenle(dataGridAcikRandevu, 12, 12, 32);
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter($"SELECT Tarih, Saat, Brans, Doktor FROM Tbl_Randevular WHERE Durum = 0 AND Tarih = '{dateTimePickerTarih.Value.ToString("yyyyMMdd")}' ORDER BY ID", bgl.Baglanti());
            da2.Fill(dt2);
            dataGridAcikRandevu.DataSource = dt2;
        }

        private void dataGridAktifRandevu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            SecilenTarih = dataGridAktifRandevu.Rows[rowIndex].Cells[0].Value.ToString();
            SecilenSaat = dataGridAktifRandevu.Rows[rowIndex].Cells[1].Value.ToString();
            SecilenBrans = dataGridAktifRandevu.Rows[rowIndex].Cells[2].Value.ToString();
            SecilenDoktor = dataGridAktifRandevu.Rows[rowIndex].Cells[3].Value.ToString();

            MessageBox.Show($"İPTAL ETMEK İÇİN SEÇİLEN RANDEVU :\n------------------------\nTarih : {SecilenTarih}\nSaat : {SecilenSaat}\nBrans : {SecilenBrans}\nDoktor : {SecilenDoktor}");

        }
    }
}
