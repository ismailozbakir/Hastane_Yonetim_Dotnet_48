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
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        DataGridFont dataGridFont = new DataGridFont();
        public string SekreterAdSoyad { get; set; }
        public int IdNumber { get; set; }

        private void Ara()
        {
            string query = $"SELECT Ad, Soyad, Brans, TC_Kimlik, Sifre FROM Tbl_Doktorlar WHERE CONCAT_WS(Ad, Soyad, Brans, TC_Kimlik) LIKE '%{txbAranan.Text}%' ORDER BY Ad";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, bgl.Baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Kaydet()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Doktorlar (Ad, Soyad, Brans, TC_Kimlik, Sifre, Duzenleyen) VALUES (@p1, @p2, @p3, @p4, @p5, @p6)", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", txbAd.Text);
            cmd.Parameters.AddWithValue("@p2", txbSoyad.Text.ToUpper());
            cmd.Parameters.AddWithValue("@p3", cmbBrans.Text);
            cmd.Parameters.AddWithValue("@p4", mskTC.Text);
            cmd.Parameters.AddWithValue("@p5", txbSifre.Text);
            cmd.Parameters.AddWithValue("@p6", SekreterAdSoyad);
            cmd.ExecuteNonQuery();
            bgl.Baglanti().Close();

            MessageBox.Show($"{txbAd.Text} {txbSoyad.Text.ToUpper()} isimli doktor kaydı eklendi.");
            Temizle();

        }
        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            dataGridFont.DataGridFontDuzenle(dataGridView1, 11, 11, 32);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Ad, Soyad, Brans, TC_Kimlik, Sifre FROM Tbl_Doktorlar ORDER BY Ad", bgl.Baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // Branş combobox'a listeyi çek
            SqlCommand cmd = new SqlCommand("SELECT Branslar FROM Tbl_Branslar ORDER BY Branslar", bgl.Baglanti());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cmbBrans.Items.Add(reader[0]);
            }

        }
        private void Temizle()
        {
            txbAd.Clear();
            txbSoyad.Clear();
            cmbBrans.Text = default;
            mskTC.Clear();
            txbSifre.Clear();
            txbAd.Focus();
            dataGridView1.Refresh();

            dataGridFont.DataGridFontDuzenle(dataGridView1, 11, 11, 32);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Ad, Soyad, Brans, TC_Kimlik, Sifre FROM Tbl_Doktorlar ORDER BY Ad", bgl.Baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Kaydet();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridView dataGridView = (DataGridView)sender;

            // get the row number clicked
            int rowIndex = dataGridView1.CurrentRow.Index;
            txbAd.Text = dataGridView1.Rows[rowIndex].Cells[0].Value as string;
            txbSoyad.Text = dataGridView1.Rows[rowIndex].Cells[1].Value as string;
            cmbBrans.Text = dataGridView1.Rows[rowIndex].Cells[2].Value as string;
            mskTC.Text = dataGridView1.Rows[rowIndex].Cells[3].Value as string;
            txbSifre.Text = dataGridView1.Rows[rowIndex].Cells[4].Value as string;

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Tbl_Doktorlar SET Ad = @p1, Soyad = @p2, Brans = @p3, TC_Kimlik = @p4, Sifre = @p5 WHERE TC_Kimlik = @p6", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", txbAd.Text);
            cmd.Parameters.AddWithValue("@p2", txbSoyad.Text.ToUpper());
            cmd.Parameters.AddWithValue("@p3", cmbBrans.Text);
            cmd.Parameters.AddWithValue("@p4", mskTC.Text);
            cmd.Parameters.AddWithValue("@p5", txbSifre.Text);
            cmd.Parameters.AddWithValue("@p6", mskTC.Text);
            cmd.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show($"{txbAd.Text} {txbSoyad.Text} nolu kayıt güncellendi.");
            Temizle();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            Ara();
        }

        private void txbAranan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                dataGridFont.DataGridFontDuzenle(dataGridView1, 11, 11, 32);

                Ara();
                txbAranan.Text = "Doktorlar tablosunda arama yap";
                txbAranan.ForeColor = SystemColors.ControlDark;
            }
        }

        private void txbSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Kaydet();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"{txbAd.Text} {txbSoyad.Text} isimli doktor kaydı SİLİNECEK!", "Uyarı!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result.Equals(DialogResult.OK))
            {
                string query = "DELETE FROM Tbl_Doktorlar WHERE TC_Kimlik = @p1";
                string resetQuery = @"DECLARE @max int SELECT @max=max(ID) FROM Tbl_Doktorlar if @max IS NULL SET @max = 0 DBCC CHECKIDENT (Tbl_Doktorlar, RESEED, @max)";

                SqlCommand cmd = new SqlCommand(query, bgl.Baglanti());

                cmd.Parameters.AddWithValue("@p1", mskTC.Text);
                cmd.ExecuteNonQuery();
                bgl.Baglanti().Close();

                SqlCommand cmdReset = new SqlCommand(resetQuery, bgl.Baglanti());
                cmdReset.ExecuteNonQuery();
                bgl.Baglanti().Close();
                //MessageBox.Show($"{IdNumber} nolu kayıt silindi!");
                Temizle();
            }
        }

        private void txbAranan_Click(object sender, EventArgs e)
        {
            txbAranan.Text = default;
            txbAranan.ForeColor = SystemColors.WindowText;
        }

        private void txbAranan_Leave(object sender, EventArgs e)
        {
            txbAranan.ForeColor = SystemColors.ControlDark;
            txbAranan.Text = "Doktorlar tablosunda arama yap";
        }

        private void btnDoktorListele_Click(object sender, EventArgs e)
        {
            dataGridFont.DataGridFontDuzenle(dataGridView1, 11, 11, 32);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Ad, Soyad, Brans, TC_Kimlik, Sifre FROM Tbl_Doktorlar ORDER BY Ad", bgl.Baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            txbAranan.Text = "Doktorlar tablosunda arama yap";
            txbAranan.ForeColor = SystemColors.ControlDark;
        }
    }
}
