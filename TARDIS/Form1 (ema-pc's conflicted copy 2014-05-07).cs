using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Charge_States
{
    public partial class Form1 : Form
    {
        double z, m, E, incharge, qmean_nd, qmean_s;
        List<List<double>> results = new List<List<double>>();
        List<double> data = new List<double>();
       
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Rtf = getDataFromWord("NikolaevDmitrievModel.docx");
            richTextBox2.Rtf = getDataFromWord("SayerModel.docx");
            toolTip1.SetToolTip(richTextBox1, "");
        }
        private String getDataFromWord(string fileName)
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = false;
            object file = Application.StartupPath + "\\Resources\\"+fileName;
            object nullobj = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref file, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj);
            doc.ActiveWindow.Selection.WholeStory();
            doc.ActiveWindow.Selection.Copy();
            IDataObject data = Clipboard.GetDataObject();
            String dataTxt = data.GetData(DataFormats.Rtf).ToString();
            doc.ActiveWindow.Close();
            //doc.Close();
            //wordApp.Documents.Close(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges);
            ((Microsoft.Office.Interop.Word._Application)wordApp).Quit(false);
            return dataTxt;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("The Nikolaev and Dmitriev formula is one of the best semi - empirical formulas for  Carbon Stripper Foils for medium/high Z  values and energy of few MeV/A.", richTextBox1);
        }

        private void richTextBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip2.Show("The Sayer empirical formula provides speculations on the passage of ions with Z > 36 through Gas or Carbon foils. \n The asymmetric distribution gives substantial improvement over previous expressions for prediction of small F(q) values for heavy ions in dilute gases. \n Recent systematic data accumulations however has revealed that the observed values are not always well reproduced with this formula.", richTextBox2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        public double f_nik_dmitr(double z, double m, double E, double incharge)
        {
            double f_nd = z*m*E*incharge;
            return f_nd;
        }

        public double f_sayer(double z, double m, double E, double incharge)
        {
            double f_s = (z / m) * (E / incharge);
            return f_s;
        }
         private void button1_Click()
        {
            Double.TryParse(zBox.Text, out z);
            Double.TryParse(mBox.Text, out m);
            Double.TryParse(eBox.Text, out E);
            Double.TryParse(icBox.Text, out incharge);

            qmean_nd = f_nik_dmitr(z, m, E, incharge);
            qmean_s = f_sayer(z, m, E, incharge);

            for (int i = 1; i < (z + 1); i++)
            {
                data.Add(i);
                data.Add(qmean_nd);
                data.Add(qmean_s);
                results.Add(data);
            }          
        }
    }

       
}
