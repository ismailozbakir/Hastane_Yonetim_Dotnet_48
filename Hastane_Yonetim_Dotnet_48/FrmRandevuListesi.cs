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
    public partial class FrmRandevuListesi : Form
    {
        public FrmRandevuListesi()
        {
            InitializeComponent();
        }
        
        public DataTable RandevuDataTablosu { get; set; }
        public string SekreterAdSoyad { get; set; }
        DataGridFont dataGridFont = new DataGridFont();
        SqlBaglantisi bgl = new SqlBaglantisi();
        int idNumber;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Temizle()
        {
            mskSaat.Clear();
            cmbBrans.Text = default;
            cmbDoktor.Text = default;
            mskHastaTc.Clear();
            txbHastaAd.Clear();
            txbHastaSoyad.Clear();
            chkDurum.Checked = default;
            dateTimePicker1.Focus();

            dataGridRandevuListesi.Refresh();
            dataGridFont.DataGridFontDuzenle(dataGridRandevuListesi, 11, 11, 32);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"SELECT ID, Tarih, Saat, Brans, Doktor, HastaTC, HastaAd, Soyad, Durum FROM Tbl_Randevular WHERE Tarih = '{dateTimePicker1.Value.ToString("yyyyMMdd")}' ORDER BY ID", bgl.Baglanti());
            da.Fill(dt);
            dataGridRandevuListesi.DataSource = dt;
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"{idNumber} nolu kayıt güncellenecek!", "Uyarı!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result.Equals(DialogResult.OK))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Tbl_Randevular SET Tarih = @p1, Saat = @p2, Brans = @p3, Doktor = @p4, HastaTC = @p5, HastaAd = @p6, Soyad = @p7, Durum = @p8, Guncelleyen = @p9 WHERE ID = @p10", bgl.Baglanti());
                cmd.Parameters.AddWithValue("@p1", dateTimePicker1.Value.ToString("yyyyMMdd"));
                cmd.Parameters.AddWithValue("@p2", mskSaat.Text);
                cmd.Parameters.AddWithValue("@p3", cmbBrans.Text);
                cmd.Parameters.AddWithValue("@p4", cmbDoktor.Text);
                cmd.Parameters.AddWithValue("@p5", mskHastaTc.Text);
                cmd.Parameters.AddWithValue("@p6", txbHastaAd.Text);
                cmd.Parameters.AddWithValue("@p7", txbHastaSoyad.Text.ToUpper());
                cmd.Parameters.AddWithValue("@p8", chkDurum.Checked);
                cmd.Parameters.AddWithValue("@p9", SekreterAdSoyad);
                cmd.Parameters.AddWithValue("@p10", idNumber);
                cmd.ExecuteNonQuery();
                bgl.Baglanti().Close();
                //MessageBox.Show($"{idNumber} nolu kayıt güncellendi.");

                // Güncelleme sonrası işlemler
                Temizle();
            }
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

        private void FrmRandevuListesi_Load(object sender, EventArgs e)
        {
            // Geçmiş bir tarihden randevu alınamaması için.
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.MinDate = DateTime.Now;
            btnPrevious.Enabled = false;

            dataGridFont.DataGridFontDuzenle(dataGridRandevuListesi, 11, 11, 32);
            dataGridRandevuListesi.DataSource = RandevuDataTablosu;


            // Branşları combox'a çek
            SqlCommand cmd = new SqlCommand("SELECT Branslar FROM Tbl_Branslar ORDER BY Branslar", bgl.Baglanti());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cmbBrans.Items.Add(reader.GetString(0));
            }

            reader.Close();
            bgl.Baglanti().Close();

            // Doktorları combobox'a çek
            SqlCommand cmd2 = new SqlCommand("SELECT Ad, Soyad, Brans FROM Tbl_Doktorlar WHERE Brans = @p1 ORDER BY Ad", bgl.Baglanti());
            cmd2.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                cmbDoktor.Items.Add($"{reader2[0]} {reader2[1]}");
            }
            reader2.Close();
            bgl.Baglanti().Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"{idNumber} nolu kayıt SİLİNECEK!", "Uyarı!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result.Equals(DialogResult.OK))
            {
                string query = "DELETE FROM Tbl_Randevular WHERE ID = @p1";
                string resetQuery = @"DECLARE @max int SELECT @max=max(ID) FROM Tbl_Randevular if @max IS NULL SET @max = 0 DBCC CHECKIDENT (Tbl_Randevular, RESEED, @max)";

                SqlCommand cmd = new SqlCommand(query, bgl.Baglanti());

                cmd.Parameters.AddWithValue("@p1", idNumber);
                cmd.ExecuteNonQuery();
                bgl.Baglanti().Close();

                SqlCommand cmdReset = new SqlCommand(resetQuery, bgl.Baglanti());
                cmdReset.ExecuteNonQuery();
                bgl.Baglanti().Close();
                //MessageBox.Show($"{idNumber} nolu kayıt silindi!");
                Temizle();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnPrevious.Enabled = true;
            int date = int.Parse(dateTimePicker1.Value.ToString("yyyyMMdd")) + 1;
            dateTimePicker1.Text = $"{date.ToString().Substring(6, 2)}.{date.ToString().Substring(4, 2)}.{date.ToString().Substring(0, 4)}";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridFont.DataGridFontDuzenle(dataGridRandevuListesi, 11, 11, 32);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"SELECT ID, Tarih, Saat, Brans, Doktor, HastaTC, HastaAd, Soyad, Durum FROM Tbl_Randevular WHERE Tarih = '{dateTimePicker1.Value.ToString("yyyyMMdd")}' ORDER BY ID", bgl.Baglanti());
            da.Fill(dt);
            dataGridRandevuListesi.DataSource = dt;
        }

        private void dataGridRandevuListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbBrans.Items.Clear();
            cmbDoktor.Items.Clear();

            int rowIndex = dataGridRandevuListesi.CurrentRow.Index;
            idNumber = (int)dataGridRandevuListesi.Rows[rowIndex].Cells[0].Value;
            string dateFlat = dataGridRandevuListesi.Rows[rowIndex].Cells[1].Value as string;
            string day = dateFlat.Substring(6, 2);
            string month = dateFlat.Substring(4, 2);
            string year = dateFlat.Substring(0, 4);

            //MessageBox.Show($"{day}.{month}.{year}");

            //dateTimePicker1.Text = $"{day}.{month}.{year}";
            mskSaat.Text = dataGridRandevuListesi.Rows[rowIndex].Cells[2].Value as string;
            cmbBrans.Text = dataGridRandevuListesi.Rows[rowIndex].Cells[3].Value as string;
            cmbDoktor.Text = dataGridRandevuListesi.Rows[rowIndex].Cells[4].Value as string;
            mskHastaTc.Text = dataGridRandevuListesi.Rows[rowIndex].Cells[5].Value as string;
            txbHastaAd.Text = dataGridRandevuListesi.Rows[rowIndex].Cells[6].Value as string;
            txbHastaSoyad.Text = dataGridRandevuListesi.Rows[rowIndex].Cells[7].Value as string;
            chkDurum.Checked = (bool)dataGridRandevuListesi.Rows[rowIndex].Cells[8].Value;

            // Branşları combox'a çek
            SqlCommand cmd = new SqlCommand("SELECT Branslar FROM Tbl_Branslar ORDER BY Branslar", bgl.Baglanti());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cmbBrans.Items.Add(reader.GetString(0));
            }

            reader.Close();
            bgl.Baglanti().Close();


            SqlCommand cmd2 = new SqlCommand("SELECT Ad, Soyad, Brans FROM Tbl_Doktorlar WHERE Brans = @p1 ORDER BY Ad", bgl.Baglanti());
            cmd2.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                cmbDoktor.Items.Add($"{reader2[0]} {reader2[1]}");
            }
            reader2.Close();
            bgl.Baglanti().Close();
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
