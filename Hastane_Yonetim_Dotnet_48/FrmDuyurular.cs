using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Yonetim_Dotnet_48
{
    public partial class FrmDuyurular : Form
    {
        public FrmDuyurular()
        {
            InitializeComponent();
        }
        DataGridFont dataGridFont = new DataGridFont();
        public DataTable DataTablosu { get; set; }

        private void FrmDuyurular_Load(object sender, EventArgs e)
        {
            dataGridFont.DataGridFontDuzenle(dataGridView1, 11, 11, 16);
            dataGridView1.DataSource = DataTablosu;
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;

        }
    }
}
