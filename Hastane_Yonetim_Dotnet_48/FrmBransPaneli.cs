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
    public partial class FrmBransPaneli : Form
    {
        public FrmBransPaneli()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        DataGridFont dataGridFont = new DataGridFont();
        void TabloYenile()
        {
            // Branşları datagrid'e çek
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Branslar FROM Tbl_Branslar ORDER BY Branslar", bgl.Baglanti());
            da.Fill(dt);
            dataGridBranslarPanel.DataSource = dt;
        }
        private void FrmBransPaneli_Load(object sender, EventArgs e)
        {
            TabloYenile();
        }

        private void txbBrans_Click(object sender, EventArgs e)
        {
            txbBrans.Text = default;
            txbBrans.ForeColor = SystemColors.WindowText;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Branslar (Branslar) VALUES (@p1)", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", txbBrans.Text);
            cmd.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show($"{txbBrans.Text} branşı başarılı şekilde eklendi.");
            txbBrans.Text = default;
            TabloYenile();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridBranslarPanel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridBranslarPanel.CurrentRow.Index;
            string secilenBrans = dataGridBranslarPanel.Rows[rowIndex].Cells[0].Value as string;

            txbBrans.ForeColor = SystemColors.WindowText;
            txbBrans.Text = secilenBrans;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Tbl_Branslar WHERE Branslar = @p1";
            string resetQuery = @"DECLARE @max int SELECT @max=max(BransID) FROM Tbl_Branslar if @max IS NULL SET @max = 0 DBCC CHECKIDENT (Tbl_Branslar, RESEED, @max)";

            SqlCommand cmd = new SqlCommand(query, bgl.Baglanti());

            cmd.Parameters.AddWithValue("@p1", txbBrans.Text);
            cmd.ExecuteNonQuery();
            bgl.Baglanti().Close();

            SqlCommand cmdReset = new SqlCommand(resetQuery, bgl.Baglanti());
            cmdReset.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show($"{txbBrans.Text} isimli branş silindi!");

            // Silme işleminden sonraki adımlar
            txbBrans.Text = "yeni branş";
            dataGridBranslarPanel.Refresh();

            dataGridFont.DataGridFontDuzenle(dataGridBranslarPanel, 14, 14, 16);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Branslar FROM Tbl_Branslar ORDER BY Branslar", bgl.Baglanti());
            da.Fill(dt);
            dataGridBranslarPanel.DataSource = dt;

        }
    }
}
