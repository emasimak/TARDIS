//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using PdfSharp;
//using PdfSharp.Pdf;
//using PdfSharp.Drawing;
using System;
using System.Windows.Forms;
//using iTextSharp.text.pdf;

namespace Charge_States
{
    public partial class infoBox : Form
    {
        //bool button_formulas_clicked;

        public infoBox()
        {
            InitializeComponent(); 
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

         private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog openDlg_png = new SaveFileDialog();
            openDlg_png.InitialDirectory = @"C:\";
            openDlg_png.DefaultExt = "png";
            openDlg_png.Filter = "Portable Network Graphics (.png) | *.png";
            openDlg_png.OverwritePrompt = true;
            openDlg_png.AddExtension = true;
            if (openDlg_png.ShowDialog() == DialogResult.OK)
            {
                global::TARDIS.Properties.Resources.charge_states_formulas.Save(openDlg_png.FileName);
            }
        }
    }
}
