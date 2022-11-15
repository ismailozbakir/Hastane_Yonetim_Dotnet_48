using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Yonetim_Dotnet_48
{
    internal class DataGridFont
    {
        /// <summary>
        /// DataGridView Nesnelerinin font ayarlarında kullanılır.
        /// </summary>
        /// <param name="dgviewNesnesi"> dataGridView nesnesi</param>
        /// <param name="headerFontSize">başlık boyutu</param>
        /// <param name="cellFontSize">hücre font boyutu</param>
        /// <param name="loc">MiddleCenter = 32, MiddleLeft = 16</param>
        public void DataGridFontDuzenle(DataGridView dgviewNesnesi, float headerFontSize, float cellFontSize, int loc)
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();

            dgviewNesnesi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = (DataGridViewContentAlignment)loc;
            //dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", headerFontSize, FontStyle.Bold, GraphicsUnit.Point, 162);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgviewNesnesi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

            dataGridViewCellStyle2.Alignment = (DataGridViewContentAlignment)loc;
            //dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", cellFontSize, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgviewNesnesi.DefaultCellStyle = dataGridViewCellStyle2;
        }
    }
}
