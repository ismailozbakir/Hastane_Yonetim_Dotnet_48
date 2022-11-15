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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        public string AdSoyad { get; set; }
        public string TcKim { get; set; }

        SqlBaglantisi bgl = new SqlBaglantisi();
        DataGridFont dataGridFont = new DataGridFont();
        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            lblAdSoyad.Text = AdSoyad;
            lblTC.Text = TcKim;

            btnPrevious.Enabled = false;

            // Geçmiş bir tarihden randevu alınamaması için.
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.MinDate = DateTime.Now;

            // Branş DataGridView Font ayarları

            dataGridFont.DataGridFontDuzenle(dataGridBranslar, 11, 11, 32);

            // Branşları datagrid'e çek
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Branslar FROM Tbl_Branslar ORDER BY Branslar", bgl.Baglanti());
            da.Fill(dt);
            dataGridBranslar.DataSource = dt;

            // Branşları combox'a çek
            SqlCommand cmd = new SqlCommand("SELECT Branslar FROM Tbl_Branslar ORDER BY Branslar", bgl.Baglanti());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cmbBrans.Items.Add(reader.GetString(0));
                //comboBrans.Items.Add(reader[0]); // veya bu satır

            }

            reader.Close();
            bgl.Baglanti().Close();


            // Doktor DataGridView Font ayarları
            dataGridFont.DataGridFontDuzenle(dataGridDoktorlar, 11, 11, 32);

            // Doktorları çek
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT (Ad + ' ' + Soyad) AS Ad_Soyad, Brans, TC_Kimlik FROM Tbl_Doktorlar ORDER BY Ad", bgl.Baglanti());
            da2.Fill(dt2);
            dataGridDoktorlar.DataSource = dt2;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            bgl.Baglanti().Close();
            FrmGirisler frmGirisler = new FrmGirisler();
            frmGirisler.Show();
            this.Hide();
        }

        private void FrmSekreterDetay_FormClosing(object sender, FormClosingEventArgs e)
        {
            bgl.Baglanti().Close();
            FrmGirisler frmGirisler = new FrmGirisler();
            frmGirisler.Show();
            this.Hide();
        }

        private void btnRandevuOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Randevular (Tarih, Saat, Brans, Doktor, Durum, HastaTC, HastaAd, Soyad, Duzenleyen) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9)", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", dateTimePicker1.Value.ToString("yyyyMMdd"));
            cmd.Parameters.AddWithValue("@p2", mskSaat.Text);
            cmd.Parameters.AddWithValue("@p3", cmbBrans.Text);
            cmd.Parameters.AddWithValue("@p4", cmbDoktor.Text);
            cmd.Parameters.AddWithValue("@p5", chkDurum.Checked);
            cmd.Parameters.AddWithValue("@p6", mskHastaTc.Text);
            cmd.Parameters.AddWithValue("@p7", txbHastaAd.Text);
            cmd.Parameters.AddWithValue("@p8", txbHastaSoyad.Text.ToUpper());
            cmd.Parameters.AddWithValue("@p9", AdSoyad);

            cmd.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show($"EKLENEN RANDEVU\n---------------\nTarih : {dateTimePicker1.Text}\nSaat : {mskSaat.Text}\nBrans : {cmbBrans.Text}\nDoktor : {cmbDoktor.Text}\nHasta TC : {mskHastaTc.Text}\nHasta Ad : {txbHastaAd.Text}\nHasta Soyad : {txbHastaSoyad.Text.ToUpper()}\nRandevu Durumu : {(chkDurum.Checked ? "Dolu" : "Uygun")}");
            
            mskSaat.Clear();
            cmbBrans.Text = default;
            cmbDoktor.Text = default;
            mskHastaTc.Clear();
            txbHastaAd.Clear();
            txbHastaSoyad.Clear();
            chkDurum.Checked = default;

        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();
            cmbDoktor.Text = default;

            SqlCommand cmd = new SqlCommand("SELECT Ad, Soyad, Brans FROM Tbl_Doktorlar WHERE Brans = @p1 ORDER BY Ad", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cmbDoktor.Items.Add($"{reader[0]} {reader[1]}");
            }
            reader.Close();
            bgl.Baglanti().Close();

        }

        private void btnDuyuruEkle_Click(object sender, EventArgs e)
        {
            string dateTime = DateTime.Now.ToString();
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            string time = DateTime.Now.ToString("HH:mm");

            SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Duyurular (Duyuru, Duzenleyen, TarihSaat) VALUES (@p1, @p2, @p3)", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p2", AdSoyad);
            cmd.Parameters.AddWithValue("@p3", dateTime);
            cmd.Parameters.AddWithValue("@p1", $"{date} - {time} : {richDuyurular.Text}");
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Duyuru Eklendi");

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Lütfen en fazla 300 karekterlik bir metin giriniz!");

            }

            bgl.Baglanti().Close();
        }

        private void btnDoktorPanel_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli frmDoktorPaneli = new FrmDoktorPaneli();
            frmDoktorPaneli.SekreterAdSoyad = AdSoyad;
            frmDoktorPaneli.Show();
        }

        private void cmbBrans_DropDown(object sender, EventArgs e)
        {
            // Bütün doktorları dataGrid'e çek
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT (Ad + ' ' + Soyad) AS Ad_Soyad, Brans, TC_Kimlik FROM Tbl_Doktorlar ORDER BY Ad", bgl.Baglanti());
            da.Fill(dt);
            dataGridDoktorlar.DataSource = dt;

            // Branş comboBox item yenile
            cmbBrans.Items.Clear();
            SqlCommand cmd = new SqlCommand("SELECT Branslar FROM Tbl_Branslar ORDER BY Branslar", bgl.Baglanti());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cmbBrans.Items.Add(reader.GetString(0));
                //comboBrans.Items.Add(reader[0]); // veya bu satır
            }

            reader.Close();
            bgl.Baglanti().Close();

            // Branşları datagrid'e çek
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT Branslar FROM Tbl_Branslar ORDER BY Branslar", bgl.Baglanti());
            da2.Fill(dt2);
            dataGridBranslar.DataSource = dt2;
        }

        private void dataGridBranslar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridBranslar.CurrentRow.Index;
            string selectedBrans = dataGridBranslar.Rows[rowIndex].Cells[0].Value.ToString();
            cmbBrans.Text = selectedBrans;
        }

        private void dataGridDoktorlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridDoktorlar.CurrentRow.Index;
            string selectedDoctor = dataGridDoktorlar.Rows[rowIndex].Cells[0].Value.ToString();
            string selectedBrans = dataGridDoktorlar.Rows[rowIndex].Cells[1].Value.ToString();
            cmbBrans.Text = selectedBrans;
            cmbDoktor.Text = selectedDoctor;
            
        }

        private void btnDoktorListele_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"SELECT (Ad + ' ' + Soyad) AS Ad_Soyad, Brans, TC_Kimlik FROM Tbl_Doktorlar ORDER By Ad", bgl.Baglanti());
            da.Fill(dt);
            dataGridDoktorlar.DataSource = dt;

            txbDoktorAra.ForeColor = SystemColors.ControlDark;
            txbDoktorAra.Text = "Doktorlar tablosunda arama yap";
        }

        private void btnBransPanel_Click(object sender, EventArgs e)
        {
            FrmBransPaneli frmBransPaneli = new FrmBransPaneli();
            frmBransPaneli.Show();
        }

        private void btnBransListele_Click(object sender, EventArgs e)
        {
            // Branşları datagrid'e çek
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Branslar FROM Tbl_Branslar ORDER BY Branslar", bgl.Baglanti());
            da.Fill(dt);
            dataGridBranslar.DataSource = dt;
        }

        private void txbDoktorAra_Click(object sender, EventArgs e)
        {
            txbDoktorAra.Text = default;
            txbDoktorAra.ForeColor = SystemColors.WindowText;
        }

        private void txbDoktorAra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                string query = $"SELECT (Ad + ' ' + Soyad) AS Ad_Soyad, Brans, TC_Kimlik FROM Tbl_Doktorlar WHERE CONCAT_WS(Ad, Soyad, Brans, TC_Kimlik) LIKE '%{txbDoktorAra.Text}%' ORDER BY Ad";


                DataGridFont dataGridFont = new DataGridFont();
                dataGridFont.DataGridFontDuzenle(dataGridDoktorlar, 11, 11, 32);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, bgl.Baglanti());
                da.Fill(dt);
                dataGridDoktorlar.DataSource = dt;

                txbDoktorAra.ForeColor = SystemColors.ControlDark;
                txbDoktorAra.Text = "Doktorlar tablosunda arama yap";
            }
        }

        private void txbDoktorAra_Leave(object sender, EventArgs e)
        {
            txbDoktorAra.ForeColor = SystemColors.ControlDark;
            txbDoktorAra.Text = "Doktorlar tablosunda arama yap";
        }

        private void btnRandevuList_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"SELECT ID, Tarih, Saat, Brans, Doktor, HastaTC, HastaAd, Soyad, Durum FROM Tbl_Randevular WHERE Tarih = '{DateTime.Now.ToString("yyyyMMdd")}' ORDER BY ID", bgl.Baglanti());
            da.Fill(dt);

            FrmRandevuListesi frmRandevuListesi = new FrmRandevuListesi();
            frmRandevuListesi.SekreterAdSoyad = AdSoyad;
            frmRandevuListesi.RandevuDataTablosu = dt;
            frmRandevuListesi.Show();
        }

        private void btnDuyuruListe_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Duyuru AS DUYURULAR FROM Tbl_Duyurular", bgl.Baglanti());
            da.Fill(dt);

            FrmDuyurular frmDuyurular = new FrmDuyurular();
            frmDuyurular.DataTablosu = dt;

            frmDuyurular.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnPrevious.Enabled = true;
            int date = int.Parse(dateTimePicker1.Value.ToString("yyyyMMdd")) + 1;
            dateTimePicker1.Text = $"{date.ToString().Substring(6, 2)}.{date.ToString().Substring(4, 2)}.{date.ToString().Substring(0, 4)}";
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int minDate = int.Parse(DateTime.Now.ToString("yyyyMMdd"));

            int date = int.Parse(dateTimePicker1.Value.ToString("yyyyMMdd")) - 1;
            if (date > minDate)
            {
                dateTimePicker1.Text = $"{date.ToString().Substring(6, 2)}.{date.ToString().Substring(4, 2)}.{date.ToString().Substring(0, 4)}";
            }
            else if (date == minDate)
            {
                dateTimePicker1.Value = DateTime.Now;
                btnPrevious.Enabled = false;
            }
            else
            {
                btnPrevious.Enabled = false;
            }
        }

        private void mskHastaTc_TextChanged(object sender, EventArgs e)
        {
            chkDurum.Checked = string.IsNullOrEmpty(mskHastaTc.Text) ? false : true;
        }
    }
}
