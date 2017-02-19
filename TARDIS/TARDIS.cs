using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.Annotations;
using OxyPlot.WindowsForms;

namespace Charge_States
{
    public partial class TARDIS : Form
    {
        double m, m_eVc2, m_kg, E, E_J, gamma, u, u_b, c, factor, x_rv, qmean_nd, d_nd, qmean_s_foil, d_s_foil, rc, epc, qmean_s_gas, d_s_gas, rg, epg, qmean_b, d_b, qmean_ss_foil, qmean_ss_gas, d_ss, sum_nd, sum_s_foil, sum_s_gas, sum_b, sum_ss_foil, sum_ss_gas, max_nd, max_s_foil, max_s_gas, max_b, max_ss_foil, max_ss_gas;

        private void foilStripperButton_CheckedChanged(object sender, EventArgs e)
        {
            zGasBox.Enabled = !foilStripperButton.Checked;
            zFoilBox.Enabled = foilStripperButton.Checked;
            // If you want it to be unchecked as well as grayed out,
            // then have this code as well:
            //if (!zGasBox.Enabled)
            //{
              //  gasStripperButton.Checked = false;
            //}
        }

        //private void radioButtons_CheckedChanged(object sender, EventArgs e)
        //{
        //  throw new NotImplementedException();
        //}

        //foilStripperButton.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
        //gasStripperButton.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);

        private void calculateButton_Click(object sender, EventArgs e)
        {
            Int32.TryParse(zBox.Text, out z);
            Double.TryParse(mBox.Text, out m);
            Double.TryParse(eBox.Text, out E);
            Int32.TryParse(icBox.Text, out incharge);
            Double.TryParse(factorBox.Text, out factor);
            Int32.TryParse(zFoilBox.Text, out z_t_foil);
            Int32.TryParse(zGasBox.Text, out z_t_gas);

            if ((zBox == null) || (incharge == 0))
            {
                z = 6;
            }
            if ((mBox == null) || (incharge == 0))
            {
                m = 12.0;
            }
            if ((eBox == null) || (incharge == 0))
            {
                E = 12.0;
            }
            if ((icBox == null) || (incharge == 0))
            {
                incharge = 1;
            }
            if (factorBox == null || (factor == 0.0))
            {
                factor = 1.0;
            }
            if (zFoilBox == null || (z_t_foil == 0.0))
            {
                z_t_foil = 6;   // Set atomic number of foil target to Carbon (z = 6).
            }
            if (zGasBox == null || (z_t_gas == 0.0))
            {
                z_t_gas = 7;    // Set atomic number of gas target to Nitrogen (z = 7).
            }

            
            // Conversions, Constants and Calculations
            E *= Math.Pow(10, 6); // Convert energy of beam from MeV to eV.
            E_J = E * 1.6 * Math.Pow(10, -19); // Convert energy of beam from eV to J.

            m_eVc2 = m * 931.4941 * Math.Pow(10, 6); // Convert mass of nucleus from amu to eV/c^2.
            m_kg = m * 1.66 * Math.Pow(10, -27); // Convert mass of nucleus from amu to kg.

            c = 3 * Math.Pow(10, 8); // Speed of light in (m/s).
            u_b = 2.188 * Math.Pow(10, 6); // Bohr's velocity of electron in first orbital in (m/s).

            // γ = (E + mc^2)/ (mc^2) where E in (J), m in (kg) and c in (m/s). - γ: Lorentzian factor
            // 1 eV = 1.6 * 10^-19 J.
            // 1 amu = 1.66 * 10^27 kg.
            gamma = (E_J + (m_kg * Math.Pow(c, 2))) / (m_kg * Math.Pow(c, 2)); // Lorentzian factor: γ = 1/sqrt(1 - (u^2/c^2))
            // Derivation of ion speed u from gamma.       
            u = c * Math.Sqrt(1 - (1 / Math.Pow(gamma, 2))); // Relativistic velocity of ions in (m/s).
            double u_mmpns = u * Math.Pow(10, 3) / Math.Pow(10, 9); // Relativistic velocity of ions in (mm/ns).
            velocityValueLabel.Text = u_mmpns.ToString("G8");

            x_rv = 3.86 * Math.Pow(z, -0.45) * Math.Sqrt(E * Math.Pow(10, -6) / m);// Reduced Velocity.


            // Intitializing
            data = new List<List<double>>(z);
            max = 0;

            // Calling the formulas.
            qmean_nd = f_nikolaev_dmitriev().Item1;
            d_nd = f_nikolaev_dmitriev().Item2;

            qmean_s_foil = f_sayer().Item1;
            rc = f_sayer().Item2;
            epc = f_sayer().Item3;

            qmean_s_gas = f_sayer().Item4;
            rg = f_sayer().Item5;
            epg = f_sayer().Item6;

            qmean_b = f_betz().Item1;
            d_b = f_betz().Item2;

            qmean_ss_foil = f_schiwietz_schmitt().Item1;
            qmean_ss_gas = f_schiwietz_schmitt().Item2;
            d_ss = f_schiwietz_schmitt().Item3;

            sum_nd = sum().Item1; // Calculating sum of Nikolaev - Dmitriev formula values for integer values of q.
            sum_s_foil = sum().Item2; // Calculating sum of Sayer's carbon foil formula values for integer values of q.
            sum_s_gas = sum().Item3; // Calculating sum of Sayer's gas formula values for integer values of q.
            sum_b = sum().Item4; // Calculating sum of Betz's formula values for integer values of q.
            sum_ss_foil = sum().Item5; // Calculating sum of Schiwietz - Schmitt foil formula values for integer values of q.
            sum_ss_gas = sum().Item6; // Calculating sum of Schiwietz - Schmitt gas formula values for integer values of q.

            max_nd = maximum().Item1; // Calculating max of Nikolaev - Dmitriev formula values.
            max_s_foil = maximum().Item2; // Calculating max of Sayer's carbon foil formula values.
            max_s_gas = maximum().Item3; // Calculating max of Sayer's gas formula values.
            max_b = maximum().Item4; // Calculating max of Betz's formula values.
            max_ss_foil = maximum().Item5; // Calculating max of Schiwietz - Schmitt foil formula values.
            max_ss_gas = maximum().Item6; // Calculating max of Schiwietz - Schmitt gas formula values.

            for (int i = 0; i < z; i++)
            {
                double q = (double)i + 1;

                if (foilStripperButton.Checked)     // Foil Stripper has been selected
                {
                    double gauss_nd = gaussian_fit_nd(q, qmean_nd, d_nd);
                    double gauss_s_foil = gaussian_fit_s(q, qmean_s_foil, rc, epc);
                    double gauss_b = gaussian_fit_b_ss(q, qmean_b, d_b);
                    double gauss_ss_foil = 0.0;
                    if (z_t_foil < 6)
                    {
                        gauss_ss_foil = gaussian_fit_b_ss(q, qmean_ss_foil, d_ss);
                    }

                    double I_I0_nd = ((gauss_nd / sum_nd * q) / incharge) * factor;
                    double I_I0_s_foil = ((gauss_s_foil / sum_s_foil * q) / incharge) * factor;
                    double I_I0_b = ((gauss_b / sum_b * q) / incharge) * factor;
                    double I_I0_ss_foil = ((gauss_ss_foil / sum_ss_foil * q) / incharge) * factor;

                    List<Double> foilRow = new List<Double>() { q, gauss_nd / sum_nd, I_I0_nd, gauss_s_foil / sum_s_foil, I_I0_s_foil, gauss_b / sum_b, I_I0_b, gauss_ss_foil / sum_ss_foil, I_I0_ss_foil }; //, gauss_s_gas / sum_s_gas, I_I0_s_gas, gauss_ss_gas / sum_ss_gas, I_I0_ss_gas };
                    data.Add(foilRow);
                }
                else    // Gas Stripper has been selected
                {
                    double gauss_s_gas = gaussian_fit_s(q, qmean_s_gas, rg, epg);
                    double gauss_ss_gas = 0.0;
                    if (z_t_gas < 6)
                    {
                        gauss_ss_gas = gaussian_fit_b_ss(q, qmean_ss_gas, d_ss);
                    }

                    double I_I0_s_gas = ((gauss_s_gas / sum_s_gas * q) / incharge) * factor;
                    double I_I0_ss_gas = ((gauss_ss_gas / sum_ss_gas * q) / incharge) * factor;

                    List<Double> gasRow = new List<Double>() { q, gauss_s_gas / sum_s_gas, I_I0_s_gas, gauss_ss_gas / sum_ss_gas, I_I0_ss_gas };
                    data.Add(gasRow);
                }
            }

            fillDataGrid(data); // Filling the data grid with the data list<list>.
            var myModel = new PlotModel(); // Creating a plot model.
            myModel = FunctionAnnotation(z, data);
            this.plot1.Model = myModel;
        }

        //
        // Clicking the Hyberlinks --> redirection to respective websites.
        //
        private void atnumLabel_Click(object sender, EventArgs e)
        {
            try
            {
                // Send the URL to the operating system.
                System.Diagnostics.Process.Start("http://www.chemicalelements.com/show/atomicnumber.html");
            }
            catch
            {
            }
        }

        private void atmassLabel_Click(object sender, EventArgs e)
        {
            try
            {
                // Send the URL to the operating system.
                System.Diagnostics.Process.Start("http://www.chemicalelements.com/show/mass.html");
            }
            catch
            {
            }
        }

        //
        // Exporting data to excel file.
        //
        private void buttonExcel_Click(object sender, EventArgs e)
        {
            //SaveFileDialog openDlg_excel = new SaveFileDialog();
            //openDlg_excel.InitialDirectory = @"C:\";
            //openDlg_excel.DefaultExt = "xlsx";
            //openDlg_excel.Filter = "Microsoft Excel Worksheet (.xlsx) | *.xlsx";
            //openDlg_excel.OverwritePrompt = true;
            //openDlg_excel.AddExtension = true;

            //if (openDlg_excel.ShowDialog() == DialogResult.OK)
            //{
            //    using (var stream = File.Create(openDlg_excel.FileName))
            //    {
            // Creating Excel Application  
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                //Excel.Workbook newWorkbook = app.Workbooks.Add();            
                // Creating new WorkBook within Excel application            
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // Creating new Excelsheet in workbook
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // Setting excel sheet behind the program as visible 
                app.Visible = true;
                // Get the reference of first sheet. By default its name is Sheet1. 
                // Store its reference to worksheet. 
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet 
                worksheet.Name = "Charge States Data";

                // storing header part in Excel            
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                // storing Each row and column value to excel sheet     
                for (int i = 0; i < z; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        int k = i + 2;
                        int l = j + 1;
                        DataGridViewCell cell = dataGridView1[j, i];
                        worksheet.Cells[k, l] = cell.Value;
                    }
                }
                //for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                //{
                //    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                //    {
                //        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                //    }
                //}
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }

            //workbook.SaveAs("Charge_States.xlsx", Excel.XlFileFormat.xlWorkbookNormal, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
            //workbook.Close(true, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
            //app.Quit();
            //workbook.SaveAs(openDlg_excel.FileName);
            //workbook.Close();        
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
            }
        }

        //
        // Exporting the graph to .png.
        //
        private void buttonPNG_Click(object sender, EventArgs e)
        {
            SaveFileDialog openDlg_png = new SaveFileDialog();
            openDlg_png.InitialDirectory = @"C:\";
            openDlg_png.DefaultExt = "png";
            openDlg_png.Filter = "Portable Network Graphics (.png) | *.png";
            openDlg_png.OverwritePrompt = true;
            openDlg_png.AddExtension = true;
            if (openDlg_png.ShowDialog() == DialogResult.OK)
            {
                using (var stream = File.Create(openDlg_png.FileName))
                {
                    PngExporter png_exp = new PngExporter();
                    png_exp.Background = OxyColor.FromRgb(255, 255, 255);
                    png_exp.Width = 2048;
                    png_exp.Height = 1080;
                    png_exp.Resolution = 72;
                    png_exp.Export(plot1.Model, stream);
                }
            }
        }

        //
        // Functions used.
        //

        //
        // Empirical Formulas of Nikoaev & Dmitriev (carbon foil stripper), Sayer (carbon foil and gas stripper) and Betz (carbon foil stripper) follow.
        //
        public Tuple<double, double> f_nikolaev_dmitriev()
        {
            // Formulas according to Posocco's PhDthesis - ALPI.
            // double qmean_nd = z * Math.Pow((1 + (2.29 * Math.Pow(Math.Pow(z, -0.45) * u / u_b, -1.667))), -0.6); // Calculating most probable charge state - Nikolaev - Dmitriev formula.
            // double d_nd = 0.5 * Math.Sqrt(qmean_nd * (1.0 - Math.Pow(qmean_nd / z, 1.667))); // Calculating width d - Nikolaev - Dmitriev formula.

            // Formulas according to Justin M. Sanders' Fortran program.
            // Parameters: alpha, k, v_prim from Betz, Eqn 3.7.5
            double alpha = -0.45;
            double k = -0.61;
            double k2 = 0.6;
            double inv_k = 1/k;
            double inv_k2 = 1/k2;
            double v_prim = 3.6 * Math.Pow(10, 8);
            double qmean_nd = z * Math.Pow((1.0 + (Math.Pow(Math.Pow(z, alpha) * (u * 100 / v_prim), inv_k))), k); // Calculating most probable charge state - Nikolaev - Dmitriev formula.
            double d_nd = 0.5 * Math.Sqrt(qmean_nd * (1.0 - Math.Pow(qmean_nd / z, inv_k2))); // Calculating width d - Nikolaev - Dmitriev formula.

            return new Tuple<double, double>(qmean_nd, d_nd);
        }

        public Tuple<double, double, double, double, double, double> f_sayer()
        {
            double b = u / c;

            // FOIL STRIPPER
            // Formulas according to a program created by B.L. Doyle, SNL, using Sayer's paper.
            // double red_vel = 47.3 * Math.Pow(z, -0.38) * Math.Pow(b, 0.86);
            // double qmean_s_foil = z * (1 - 1.03 * Math.Exp(-red_vel)); // Calculating most probable charge state - Sayer foil stripper formula.
            // double rho_gas = 0.48 * Math.Pow(z, 0.45) * Math.Pow(qmean_s_foil / z * (1 - (qmean_s_foil / z)), 0.26);
            // double e = rho_gas * ((0.0007 * z) - (0.7 * b));
            // double d_s_foil = Math.Pow((0.47 * Math.Pow(z, 0.46) * Math.Pow(((qmean_s_foil / z) * (1 - (qmean_s_foil / z))), 0.26)), 2); // Calculating width d - Sayer foil stripper formula.

            // Formulas according to Justin M. Sanders' Fortran program.
            double qmean_s_foil = z * (1 - Math.Exp(-55.8 * Math.Pow(z, -0.421) * Math.Pow(b, 0.89)));
            double rc = 0.38 * Math.Pow(z, 0.51) * Math.Pow(qmean_s_foil / z * (1 - (qmean_s_foil / z)), 0.2);
            double epc;
            if (z <= 15)
            {
                epc = 0;
            }
            else
            {
                epc = rc * ((0.0007 * z) - (0.7 * b));
            }


            // GAS STRIPPER
            // Formulas according to a program created by B.L. Doyle, SNL, using Sayer's paper.
            // double red_vel = 80.1 * Math.Pow(z, -0.506) * Math.Pow(b, 0.996);
            // double max_num = 1 - (1.08 * Math.Exp(-red_vel));
            // if (red_vel * 0.116 / 0.2 > max_num) max_num = red_vel * 0.116 / 0.2; // q0/z takes the maximum between: a = 1 - (1.08 * Math.Exp(-red_vel)) and b = red_vel * 0.116 / 0.2.
            // double qmean_s_gas = z * max_num; // Calculating most probable charge state - Sayer gas stripper formula.
            // double rho = 0.35 * Math.Pow(z, 0.55) * Math.Pow(qmean_s_gas / z * (1 - (qmean_s_gas / z)), 0.27);
            // double e = rho * (0.17 + (0.0012 * z) - (3.3 * b));
            // double d_s_gas = Math.Pow((0.47 * Math.Pow(z, 0.46) * Math.Pow(((qmean_s_gas / z) * (1 - (qmean_s_gas / z))), 0.26)), 2); // Calculating width d - Sayer gas stripper formula.

            // Formulas according to Justin M. Sanders' Fortran program.
            double br = formula_switching_point().Item1;
            double co = formula_switching_point().Item2; // Constant.

            double qmean_s_gas;
            if (b <= br)
            {
                qmean_s_gas = z * co * b;
            }
            else
            {
                qmean_s_gas = z * (1 - 1.08 * Math.Exp(-80.1 * Math.Pow(z, -0.506) * Math.Pow(b, 0.996)));
            }
            double rg = 0.35 * Math.Pow(z, 0.55) * Math.Pow((qmean_s_gas / z) * (1 - (qmean_s_gas / z)), 0.27);
            double epg;
            if (z <= 15)
            {
                epg = 0;
            }
            else
            {
                epg = rg * (0.17 + (0.0012 * z) - (3.3 * b));
            }

            return new Tuple<double, double, double, double, double, double>(qmean_s_foil, rc, epc, qmean_s_gas, rg, epg);
        }

        //public Tuple<double, double, double> f_sayer_gas()
        //{
        //    // Formulas according to a program created by B.L. Doyle, SNL, using Sayer's paper.
        //    double b = u / c;
        //    // double red_vel = 80.1 * Math.Pow(z, -0.506) * Math.Pow(b, 0.996);
        //    // double max_num = 1 - (1.08 * Math.Exp(-red_vel));
        //    // if (red_vel * 0.116 / 0.2 > max_num) max_num = red_vel * 0.116 / 0.2; // q0/z takes the maximum between: a = 1 - (1.08 * Math.Exp(-red_vel)) and b = red_vel * 0.116 / 0.2.
        //    // double qmean_s_gas = z * max_num; // Calculating most probable charge state - Sayer gas stripper formula.
        //    // double rho = 0.35 * Math.Pow(z, 0.55) * Math.Pow(qmean_s_gas / z * (1 - (qmean_s_gas / z)), 0.27);
        //    // double e = rho * (0.17 + (0.0012 * z) - (3.3 * b));
        //    // double d_s_gas = Math.Pow((0.47 * Math.Pow(z, 0.46) * Math.Pow(((qmean_s_gas / z) * (1 - (qmean_s_gas / z))), 0.26)), 2); // Calculating width d - Sayer gas stripper formula.

        //    double br = formula_switching_point().Item1;
        //    double co = formula_switching_point().Item2; // Constant.

        //    double qmean_s_gas;
        //    if (b <= br)
        //    {
        //        qmean_s_gas = z * co * b;
        //    }
        //    else
        //    {
        //        qmean_s_gas = z * (1 - 1.08 * Math.Exp(-80.1 * Math.Pow(z, -0.506) * Math.Pow(b, 0.996)));
        //    }
        //    double rg = 0.35 * Math.Pow(z, 0.55) * Math.Pow((qmean_s_gas / z) * (1 - (qmean_s_gas / z)), 0.27);
        //    double epg;
        //    if (z <= 15)
        //    {
        //        epg = 0;
        //    }
        //    else
        //    {
        //        epg = rg * (0.17 + (0.0012 * z) - (3.3 * b));
        //    }

        //    return new Tuple<double, double, double>(qmean_s_gas, rg, epg);
        //}

        public Tuple<double, double> f_betz()
        {
            // Formulas according to Posocco's PhDthesis - ALPI.
            double qmean_b = z * (1 - (1.041 * Math.Exp(-0.851 * Math.Pow(z, -0.432) * Math.Pow(u / u_b, 0.847)))); // Calculating most probable charge state - Betz formula.
            double d_b = 0.27 * Math.Sqrt(z); // Calculating width d - Betz formula.

            return new Tuple<double, double>(qmean_b, d_b);
        }

        public Tuple<double, double, double> f_schiwietz_schmitt() // Use for low Z values (He - C).
        {
            // Formulas for foil stripping according to Schmitt's paper.
            //double u_spv = Math.Pow(z,-0.543)*(u/u_b); // Scaled projectile velocity.
            //double c_1  = 1 - (0.26*Math.Exp(-z_t/11)*Math.Exp(-Math.Pow((z_t - z),2)/9));
            //double c_2 = 1 + (0.030*u_spv*Math.Log(z_t));
            //double x_rrv =  c_1* Math.Pow(((u_spv/c_2)/1.54),(1 + (1.83/z))); // Reformulated reduced velocity.

            // Formulas according to Schiwietz's paper.
            double u_spv_foil = Math.Pow(z, -0.52) * (u / u_b); // Scaled projectile velocity.
            double c_1_foil = (-0.019 * u_spv_foil);
            double c_2_foil = Math.Pow(z_t_foil, c_1_foil);
            double x_rrv_foil = Math.Pow((u_spv_foil * c_2_foil / 1.68), (1 + (1.8 / z))); // Reformulated reduced velocity.             


            //double qmean_ss_foil = z*((8.29*x_rrv) + Math.Pow(x_rrv,4)) / ((0.06/x_rrv) + 4 + (7.4*x_rrv)+ Math.Pow(x_rrv,4)); // Calculating most probable charge state - Schiwietz formula.
            double qmean_ss_foil = z * ((12 * x_rrv_foil) + Math.Pow(x_rrv_foil, 4)) / ((0.07 / x_rrv_foil) + 6 + (0.3 * Math.Sqrt(x_rrv_foil)) + (10.37 * x_rrv_foil) + Math.Pow(x_rrv_foil, 4)); // Calculating most probable charge state - Schiwietz formula.

            // GAS STRIPPER
            // Formulas according to Schiwietz's paper.
            double u_spv_gas = Math.Pow(z, -0.52) * (u / u_b); // Scaled projectile velocity.
            double c_1_gas = (0.03 - (0.017 * u_spv_gas));
            double c_2_gas = Math.Pow(z_t_gas, c_1_gas);
            double x_rrv_gas = Math.Pow((u_spv_gas * c_2_gas), (1 + (0.4 / z))); // Reformulated reduced velocity.             

            double qmean_ss_gas = z * ((376 * x_rrv_gas) + Math.Pow(x_rrv_gas, 6)) / (1428 - (1206 * Math.Sqrt(x_rrv_gas)) + (690 * x_rrv_gas) + Math.Pow(x_rrv_gas, 6)); // Calculating most probable charge state - Schiwietz formula.


            //// Calculating width w - Schiwietz's paper.
            //// FOIL STRIPPER
            //double d_temp = 0.0;
            //for (int i = 0; i < z; i++)
            //{

            //}
            //double d_sch_foil = Math.Sqrt(d_temp);
            //double f_1_foil = Math.Sqrt((qmean_ss_foil + (0.37*Math.Pow(z,0.6)))/qmean_ss_foil);
            //double f_2_foil = Math.Sqrt(((z - qmean_ss_foil) + (0.37*Math.Pow(z,0.6)))/(z - qmean_ss_foil));
            //double w_foil = d_sch_foil * Math.Pow(z, -0.27) * Math.Pow(z_t, (0.035 - (0.0009 * z))) * f_1_foil * f_2_foil;

            ////GAS STRIPPER
            //double d_sch_gas = 0.0;
            //double f_1_gas = Math.Sqrt((qmean_ss_gas + (0.37*Math.Pow(z,0.6)))/qmean_ss_gas);
            //double f_2_gas = Math.Sqrt(((z - qmean_ss_gas) + (0.37*Math.Pow(z,0.6)))/(z - qmean_ss_gas));
            //double w_gas = d_sch_gas * Math.Pow(z, -0.27) * Math.Pow(z_t, (0.035 - (0.0009*z))) * f_1_gas * f_2_gas;

            // Calculating width d - Schmitt formula.
            double[] const_He = new double[8] { -1.45151, 1.67547, -1.0876, 0.1842, 0, 0, 0, 0 };
            double[] const_Li = new double[8] { -2.26797, 3.08476, -2.02953, 0.49942, -0.04372, 0, 0, 0 };
            double[] const_Be = new double[8] { -1.00947, 0.08991, 0.1345, -0.1461, 0.03489, -0.00266, 0, 0 };
            double[] const_B = new double[8] { -1.16557, 1.15722, -2.45451, 2.24786, -0.97857, 0.19618, -0.01465, 0 };
            double[] const_C = new double[9] { -1.3736, 2.25812, -5.23364, 5.38241, -2.85544, 0.81527, -0.11999, 0.00718, 0 };
            double d_ss_foil = 0.0;

            if (z >= 2 && z < 6)
            {
                if (x_rv > 2.0)
                {
                    d_ss_foil = Math.Pow(10, ((-0.360 * x_rv) - 0.2397)) * Math.Pow(z, 1.2);
                }
                else
                {
                    if (z == 2)
                    {
                        for (int i = 1; i < (z + 2); i++)
                        {
                            d_ss_foil += const_He[i] * Math.Pow(x_rv, i - 1);
                        }
                        d_ss_foil = Math.Pow(10, d_ss_foil) * Math.Pow(z, 1.2);
                    }
                    else
                    {
                        if (z == 3)
                        {
                            for (int i = 1; i < (z + 2); i++)
                            {
                                d_ss_foil += const_Li[i] * Math.Pow(x_rv, i - 1);
                            }
                            d_ss_foil = Math.Pow(10, d_ss_foil) * Math.Pow(z, 1.2);
                        }
                        else
                        {
                            if (z == 4)
                            {
                                for (int i = 1; i < (z + 2); i++)
                                {
                                    d_ss_foil += const_Be[i] * Math.Pow(x_rv, i - 1);
                                }
                                d_ss_foil = Math.Pow(10, d_ss_foil) * Math.Pow(z, 1.2);
                            }
                            else
                            {
                                for (int i = 1; i < (z + 2); i++)
                                {
                                    d_ss_foil += const_B[i] * Math.Pow(x_rv, i - 1);
                                }
                                d_ss_foil = Math.Pow(10, d_ss_foil) * Math.Pow(z, 1.2);
                            }
                        }
                    }
                }
            }
            else
            {
                if ((x_rv > 2.5) || (z > 6))
                {
                    d_ss_foil = Math.Pow(10, ((-0.360 * x_rv) - 0.2397)) * Math.Pow(z, 1.2);
                }
                else
                {
                    for (int i = 1; i < (z + 2); i++)
                    {
                        d_ss_foil += const_C[i] * Math.Pow(x_rv, i - 1);
                    }
                    d_ss_foil = Math.Pow(10, d_ss_foil) * Math.Pow(z, 1.2);
                }
            }

            return new Tuple<double, double, double>(qmean_ss_foil, qmean_ss_gas, d_ss_foil);
        }

        public Tuple<double, double> f_schiwietz_schmitt_gas() // Use for low Z values (He - C).
        {
            // Formulas according to Schiwietz's paper.
            double u_spv = Math.Pow(z, -0.52) * (u / u_b); // Scaled projectile velocity.
            double c_1 = (0.03 - (0.017 * u_spv));
            double c_2 = Math.Pow(z_t_gas, c_1);
            double x_rrv = Math.Pow((u_spv * c_2), (1 + (0.4 / z))); // Reformulated reduced velocity.             

            double qmean_ss_gas = z * ((376 * x_rrv) + Math.Pow(x_rrv, 6)) / (1428 - (1206 * Math.Sqrt(x_rrv)) + (690 * x_rrv) + Math.Pow(x_rrv, 6)); // Calculating most probable charge state - Schiwietz formula.

            // Calculating width d - Schmitt formula.
            double[] const_He = new double[8] { -1.45151, 1.67547, -1.0876, 0.1842, 0, 0, 0, 0 };
            double[] const_Li = new double[8] { -2.26797, 3.08476, -2.02953, 0.49942, -0.04372, 0, 0, 0 };
            double[] const_Be = new double[8] { -1.00947, 0.08991, 0.1345, -0.1461, 0.03489, -0.00266, 0, 0 };
            double[] const_B = new double[8] { -1.16557, 1.15722, -2.45451, 2.24786, -0.97857, 0.19618, -0.01465, 0 };
            double[] const_C = new double[9] { -1.3736, 2.25812, -5.23364, 5.38241, -2.85544, 0.81527, -0.11999, 0.00718, 0 };
            double d_ss_gas = 0.0;

            if (z >= 2 && z < 6)
            {
                if (x_rv > 2.0)
                {
                    d_ss_gas = Math.Pow(10, ((-0.360 * x_rv) - 0.2397)) * Math.Pow(z, 1.2);
                }
                else
                {
                    if (z == 2)
                    {
                        for (int i = 1; i < (z + 2); i++)
                        {
                            d_ss_gas += const_He[i] * Math.Pow(x_rv, i - 1);
                        }
                    }
                    else
                    {
                        if (z == 3)
                        {
                            for (int i = 1; i < (z + 2); i++)
                            {
                                d_ss_gas += const_Li[i] * Math.Pow(x_rv, i - 1);
                            }
                        }
                        else
                        {
                            if (z == 4)
                            {
                                for (int i = 1; i < (z + 2); i++)
                                {
                                    d_ss_gas += const_Be[i] * Math.Pow(x_rv, i - 1);
                                }
                            }
                            else
                            {
                                for (int i = 1; i < (z + 2); i++)
                                {
                                    d_ss_gas += const_B[i] * Math.Pow(x_rv, i - 1);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if ((x_rv > 2.5) || (z > 6))
                {
                    d_ss_gas = Math.Pow(10, ((-0.360 * x_rv) - 0.2397)) * Math.Pow(z, 1.2);
                }
                else
                {
                    for (int i = 1; i < (z + 2); i++)
                    {
                        d_ss_gas += const_C[i] * Math.Pow(x_rv, i - 1);
                    }
                }
            }

            return new Tuple<double, double>(qmean_ss_gas, d_ss_gas);
        }

        public Tuple<double, double> formula_switching_point()
        {
            double tol = Math.Pow(10, -6);

            double c1 = 1.08, a1 = 80.1, a2 = -0.506, g1 = 0.996, c2 = 65.76, d1 = -0.55;
            double a3 = a1 * Math.Pow(z, a2);
            double c3 = c2 * Math.Pow(z, d1);
            double bf = (c1 - 1.0) / ((c1 * a3) - c3);
            double bff = Math.Pow(Math.Log10(c1 / (1.0 - (c3 * bf))) / a3, (1 / g1));

            double f_1 = (1 - (c1 * Math.Exp(-a3 * Math.Pow(bff, g1)))) - (g1 * c1 * a3 * Math.Pow(bff, g1) * Math.Exp(-a3 * Math.Pow(bff, g1)));
            double f_2 = -g1 * c1 * a3 * Math.Pow(bff, g1) * Math.Exp(-a3 * Math.Pow(bff, g1)) * (((g1 - 1) / bff) - (g1 * a3 * Math.Pow(bff, (g1 - 1))));

            while (Math.Abs(f_1) > tol)
            {
                bff -= f_1 / f_2;
                f_1 = (1 - (c1 * Math.Exp(-a3 * Math.Pow(bff, g1)))) - (g1 * c1 * a3 * Math.Pow(bff, g1) * Math.Exp(-a3 * Math.Pow(bff, g1)));
                f_2 = -g1 * c1 * a3 * Math.Pow(bff, g1) * Math.Exp(-a3 * Math.Pow(bff, g1)) * (((g1 - 1) / bff) - (g1 * a3 * Math.Pow(bff, (g1 - 1))));
            }

            double br = bff;
            double co = g1 * c1 * a3 * Math.Pow(bff, (g1 - 1)) * Math.Exp(-a3 * Math.Pow(bff, g1));

            return new Tuple<double, double>(br, co);
        }

        //
        // Each formula will be represented with a gaussian distribution using the most propable charge state that is calculated from each formula and the respective width.
        //

        public double gaussian_fit_nd(double q, double qmean, double d) // Function responisble for the Gaussian distribution of the values of the Nikolaev - Dmitriev formula. 
        {
            double c_norm = 1 / (Math.Sqrt(2 * Math.PI));
            double calc = new double();
            // Gaussian Distribution as discribed in Justin M. Sanders' program.
            return calc = c_norm * Math.Exp(-Math.Pow((q - qmean) / d, 2) / 2) / d;
        }

        public double gaussian_fit_s(double q, double qmean, double r, double ep) // Function responisble for the Gaussian distribution of the values of the Sayer formula. 
        {
            double c_norm = 1 / (Math.Sqrt(2 * Math.PI));
            double calc = new double();
            // Gaussian Distribution as discribed in Justin M. Sanders' program.
            return calc = c_norm * Math.Exp(-0.5 * Math.Pow((q - qmean) / r, 2) / (1 + (ep * (q - qmean) / r))) / r;
        }

        public double gaussian_fit_b_ss(double q, double qmean, double d) // Function responisble for the Gaussian distribution of the values of the Betz and the Schiwietz - Schmitt formulas. 
        {
            double c_norm = 1 / (Math.Sqrt(2 * Math.PI));
            double calc = new double();
            // General Gaussian Distribution.
            return calc = c_norm * Math.Exp(-(Math.Pow(q - qmean, 2.0)) / (2.0 * Math.Pow(d, 2.0))) / d;
        }

        //
        // For normalization purposes a function is needed for summing all the gaussian values that are derived for each formula.
        //
        public Tuple<double, double, double, double, double, double> sum() // Function responsible for summing the gaussian values that result from each formula.
        {
            double sum_nd = 0.0;
            double sum_s_foil = 0.0;
            double sum_s_gas = 0.0;
            double sum_b = 0.0;
            double sum_ss_foil = 0.0;
            double sum_ss_gas = 0.0;

            for (int j = 0; j < z; j += 1)
            {
                sum_nd += gaussian_fit_nd(j + 1, qmean_nd, d_nd);
                sum_s_foil += gaussian_fit_s(j + 1, qmean_s_foil, rc, epc);
                sum_s_gas += gaussian_fit_s(j + 1, qmean_s_gas, rg, epg);
                sum_b += gaussian_fit_b_ss(j + 1, qmean_b, d_b);
                sum_ss_foil += gaussian_fit_b_ss(j + 1, qmean_ss_foil, d_ss);
                sum_ss_gas += gaussian_fit_b_ss(j + 1, qmean_ss_gas, d_ss);
            }

            return new Tuple<double, double, double, double, double, double>(sum_nd, sum_s_foil, sum_s_gas, sum_b, sum_ss_foil, sum_ss_gas);
        }

        public Tuple<double, double, double, double, double, double> maximum() // Function responsible for summing the gaussian values that result from each formula.
        {
            double max_nd = 0.0;
            double max_s_foil = 0.0;
            double max_s_gas = 0.0;
            double max_b = 0.0;
            double max_ss_foil = 0.0;
            double max_ss_gas = 0.0;

            for (double j = 0; j < z; j += 0.01)
            {
                if (max_nd < gaussian_fit_nd(j + 1.0, qmean_nd, d_nd))
                {
                    max_nd = gaussian_fit_nd(j + 1.0, qmean_nd, d_nd);
                }
                if (max_s_foil < gaussian_fit_s(j + 1.0, qmean_s_foil, rc, epc))
                {
                    max_s_foil = gaussian_fit_s(j + 1.0, qmean_s_foil, rc, epc);
                }
                if (max_s_gas < gaussian_fit_s(j + 1.0, qmean_s_gas, rg, epg))
                {
                    max_s_gas = gaussian_fit_s(j + 1.0, qmean_s_gas, rg, epg);
                }
                if (max_b < gaussian_fit_b_ss(j + 1.0, qmean_b, d_b))
                {
                    max_b = gaussian_fit_b_ss(j + 1.0, qmean_b, d_b);
                }
                if (max_ss_foil < gaussian_fit_b_ss(j + 1.0, qmean_ss_foil, d_ss))
                {
                    max_ss_foil = gaussian_fit_b_ss(j + 1.0, qmean_ss_foil, d_ss);
                }
                if (max_ss_gas < gaussian_fit_b_ss(j + 1.0, qmean_ss_foil, d_ss))
                {
                    max_ss_gas = gaussian_fit_b_ss(j + 1.0, qmean_ss_foil, d_ss);
                }
            }

            return new Tuple<double, double, double, double, double, double>(max_nd, max_s_foil, max_s_gas, max_b, max_ss_foil, max_ss_gas);
        }

        //
        // Filling the data grid with the calculated data.
        //
        private void fillDataGrid(List<List<double>> list)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            bool Schiwietz_Schmitt_isValid = true;
            string notificationText = "Formula not used for this target.";

            if (foilStripperButton.Checked)     // Foil stripper selected
            {
                if (z_t_foil >= 6) Schiwietz_Schmitt_isValid = false; // Formula for Be - C
                dataGridView1.ColumnCount = 9;
                dataGridView1.Columns[0].Name = "Charge (q)";
                dataGridView1.Columns[1].Name = "F(q) [Nikolaev - Dmitriev formula]"; //"F(q) [Foil Stripper, Nikolaev - Dmitriev formula]";
                dataGridView1.Columns[2].Name = "I / I0 [Nikolaev - Dimitriev formula]"; //"I / I0 [Foil Stripper, Nikolaev - Dimitriev formula]";
                dataGridView1.Columns[3].Name = "F(q) [Sayer Formula]";
                dataGridView1.Columns[4].Name = "I / I0 [Sayer Formula]";
                dataGridView1.Columns[5].Name = "F(q) [Betz Formula]";
                dataGridView1.Columns[6].Name = "I / I0 [Betz Formula]";
                dataGridView1.Columns[7].Name = "F(q) [Schiwietz - Schmitt Formula]";
                dataGridView1.Columns[8].Name = "I / I0 [Schiwietz - Schmitt Formula]";
            }
            else    // Gas stripper selected
            {
                if (z_t_gas >= 6) Schiwietz_Schmitt_isValid = false; // Formula for Be - C
                dataGridView1.ColumnCount = 5;
                dataGridView1.Columns[0].Name = "Charge (q)";
                dataGridView1.Columns[1].Name = "[F(q) [Sayer Formula]";
                dataGridView1.Columns[2].Name = "I / I0 [Sayer formula]";
                dataGridView1.Columns[3].Name = "F(q) [Schiwietz - Schmitt Formula]";
                dataGridView1.Columns[4].Name = "I / I0 [Schiwietz - Schmitt Formula]";
            }
            for (int i = 0; i < list.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                for (int j = 0; j < list[i].Count; j++)
                {
                    DataGridViewCell cell = new DataGridViewTextBoxCell();
                    if (j == 0)
                    {
                        cell.Value = list[i][j].ToString();
                    }
                    else if ((j == list[i].Count - 1) || (j == list[i].Count - 2))
                    {
                        if (Schiwietz_Schmitt_isValid)
                        {
                            cell.Value = list[i][j].ToString("G3"); // Defining the precision of the displayed values to the 3rd decimal digit.
                        }
                        else
                        {
                            cell.Value = notificationText;
                        }
                    }
                    else
                    {
                        cell.Value = list[i][j].ToString("G3"); // Defining the precision of the displayed values to the 3rd decimal digit.
                    }
                    
                    row.Cells.Add(cell);
                }
                dataGridView1.Rows.Insert(i, row);
            }
        }

        //
        // Creating the plots. 
        // Use of "Oxyplot" open source plotting library.
        //
        public PlotModel FunctionAnnotation(int z, List<List<double>> data_list)
        {
            var plotModel1 = new PlotModel();
            if (foilStripperButton.Checked)
            {
                plotModel1.Title = string.Format("Charge State Predictions (Foil Stripper, Z = {0}).", z_t_foil.ToString());
            }
            else
            {
                plotModel1.Title = string.Format("Charge State Predictions (Gas Stripper, Z = {0}).", z_t_gas.ToString());
            }
            
            // Each formula is represented with a unique color.
            // The predictions of each formula for each Z value is plotted as a node (Scatter Series).
            // The general Gaussian disrtibution of the predictions of each formula is plotted with a continuous line (Line Series).

            var scatterSeries1 = new ScatterSeries();
            scatterSeries1.MarkerStrokeThickness = 2;
            scatterSeries1.MarkerType = MarkerType.Circle;
            scatterSeries1.MarkerFill = OxyColor.FromRgb(216, 0, 115);
            scatterSeries1.Title = "Nikolaev - Dmitriev [Foil]";

            var lineSeries1 = new LineSeries();
            lineSeries1.MarkerStrokeThickness = 2;
            lineSeries1.LineStyle = LineStyle.LongDash;
            lineSeries1.Color = OxyColor.FromRgb(216, 0, 115);

            var scatterSeries2 = new ScatterSeries();
            scatterSeries2.MarkerStrokeThickness = 2;
            scatterSeries2.MarkerType = MarkerType.Square;
            scatterSeries2.MarkerFill = OxyColor.FromRgb(0, 80, 239);
            scatterSeries2.Title = "Sayer [Foil]";

            var lineSeries2 = new LineSeries();
            lineSeries2.MarkerStrokeThickness = 2;
            lineSeries2.LineStyle = LineStyle.LongDash;
            lineSeries2.Color = OxyColor.FromRgb(0, 80, 239);

            var scatterSeries3 = new ScatterSeries();
            scatterSeries3.MarkerStrokeThickness = 2;
            scatterSeries3.MarkerType = MarkerType.Triangle;
            scatterSeries3.MarkerFill = OxyColor.FromRgb(96, 169, 23);
            scatterSeries3.Title = "Betz [Foil]";

            var lineSeries3 = new LineSeries();
            lineSeries3.MarkerStrokeThickness = 2;
            lineSeries3.LineStyle = LineStyle.LongDash;
            lineSeries3.Color = OxyColor.FromRgb(96, 169, 23);

            var scatterSeries4 = new ScatterSeries();
            scatterSeries4.MarkerStrokeThickness = 2;
            scatterSeries4.MarkerType = MarkerType.Circle;
            scatterSeries4.MarkerFill = OxyColor.FromRgb(240, 163, 10);
            scatterSeries4.Title = "Schiwietz - Schmitt [Foil]";

            var lineSeries4 = new LineSeries();
            lineSeries4.MarkerStrokeThickness = 2;
            lineSeries4.LineStyle = LineStyle.LongDash;
            lineSeries4.Color = OxyColor.FromRgb(240, 163, 10);

            var scatterSeries5 = new ScatterSeries();
            scatterSeries5.MarkerStrokeThickness = 2;
            scatterSeries5.MarkerType = MarkerType.Diamond;
            scatterSeries5.MarkerFill = OxyColor.FromRgb(100, 118, 135);
            scatterSeries5.Title = "Sayer [Gas]";

            var lineSeries5 = new LineSeries();
            lineSeries5.MarkerStrokeThickness = 2;
            lineSeries5.LineStyle = LineStyle.LongDash;
            lineSeries5.Color = OxyColor.FromRgb(100, 118, 135);

            var scatterSeries6 = new ScatterSeries();
            scatterSeries6.MarkerStrokeThickness = 2;
            scatterSeries6.MarkerType = MarkerType.Diamond;
            scatterSeries6.MarkerFill = OxyColor.FromRgb(130, 90, 44);
            scatterSeries6.Title = "Schiwietz - Schmitt [Gas]";

            var lineSeries6 = new LineSeries();
            lineSeries6.MarkerStrokeThickness = 2;
            lineSeries6.LineStyle = LineStyle.LongDash;
            lineSeries6.Color = OxyColor.FromRgb(130, 90, 44);

            if (foilStripperButton.Checked)     // Foil Stripper has been selected
            {
                for (int i = 0; i < z; i++) // Adding the data points to each data scatter series.
                {
                    scatterSeries1.Points.Add(new OxyPlot.DataPoint(data_list[i][0], data_list[i][1])); // Nikolaev - Dmitriev Formula
                    scatterSeries2.Points.Add(new OxyPlot.DataPoint(data_list[i][0], data_list[i][3])); // Sayer Formula (foil)
                    scatterSeries3.Points.Add(new OxyPlot.DataPoint(data_list[i][0], data_list[i][5])); // Betz Formula
                    if (z_t_foil < 6)  // Schiwietz - Schmitt Formula (foil) - best results for 2 < z < 6 values
                    {
                        scatterSeries4.Points.Add(new OxyPlot.DataPoint(data_list[i][0], data_list[i][7]));
                    }                    
                }

                double y_axis_maximum = -1000;

                for (double j = 0; j < z; j += 0.01) // Adding the data points to each data line series and derivation of the maximum the data values.
                {
                    double dataPoint_nd = gaussian_fit_nd(j + 1.0, qmean_nd, d_nd) / sum_nd;
                    double dataPoint_s_foil = gaussian_fit_s(j + 1.0, qmean_s_foil, rc, epc) / sum_s_foil;
                    double dataPoint_b = gaussian_fit_b_ss(j + 1.0, qmean_b, d_b) / sum_b;
                    double dataPoint_ss_foil = gaussian_fit_b_ss(j + 1.0, qmean_ss_foil, d_ss) / sum_ss_foil;
                    
                    if (dataPoint_nd > y_axis_maximum)
                    {
                        y_axis_maximum = dataPoint_nd;
                    }
                    if (dataPoint_s_foil > y_axis_maximum)
                    {
                        y_axis_maximum = dataPoint_s_foil;
                    }
                    if (dataPoint_b > y_axis_maximum)
                    {
                        y_axis_maximum = dataPoint_b;
                    }
                    if (dataPoint_ss_foil > y_axis_maximum)
                    {
                        y_axis_maximum = dataPoint_ss_foil;
                    }

                    lineSeries1.Points.Add(new OxyPlot.DataPoint(j + 1.0, dataPoint_nd));
                    lineSeries2.Points.Add(new OxyPlot.DataPoint(j + 1.0, dataPoint_s_foil));
                    lineSeries3.Points.Add(new OxyPlot.DataPoint(j + 1.0, dataPoint_b));
                    if (z_t_foil < 6)
                    {
                        lineSeries4.Points.Add(new OxyPlot.DataPoint(j + 1.0, dataPoint_ss_foil));
                    }                    
                }

                var linearAxis1 = new LinearAxis();
                linearAxis1.Maximum = z + (1.0); //Setting the x axis maximum at (z+1)
                linearAxis1.Minimum = 1.0;
                linearAxis1.Position = AxisPosition.Bottom;
                linearAxis1.Title = "q";
                plotModel1.Axes.Add(linearAxis1);

                var linearAxis2 = new LinearAxis();
                linearAxis2.Maximum = y_axis_maximum + (y_axis_maximum * 0.1); //Setting the y axis maximum at 10% over the maximum data value.
                linearAxis2.Minimum = 0;
                linearAxis2.Position = AxisPosition.Left;
                plotModel1.Axes.Add(linearAxis2);

                plotModel1.Series.Add(lineSeries1);
                plotModel1.Series.Add(lineSeries2);
                plotModel1.Series.Add(lineSeries3);
                plotModel1.Series.Add(lineSeries4);
                plotModel1.Series.Add(scatterSeries1);
                plotModel1.Series.Add(scatterSeries2);
                plotModel1.Series.Add(scatterSeries3);
                plotModel1.Series.Add(scatterSeries4);

                var functionAnnotation1 = new FunctionAnnotation();
                functionAnnotation1.Color = OxyColor.FromRgb(216, 0, 115);
                functionAnnotation1.StrokeThickness = 2;
                functionAnnotation1.Text = "Nikolaev-Dmitriev Data [Foil Stripping]";
                plotModel1.Annotations.Add(functionAnnotation1);

                var functionAnnotation2 = new FunctionAnnotation();
                functionAnnotation2.Type = FunctionAnnotationType.EquationY;
                functionAnnotation2.Color = OxyColor.FromRgb(0, 80, 239);
                functionAnnotation2.StrokeThickness = 2;
                functionAnnotation2.Text = "Sayer's Data [Foil Stripping]";
                plotModel1.Annotations.Add(functionAnnotation2);

                var functionAnnotation3 = new FunctionAnnotation();
                functionAnnotation3.Color = OxyColor.FromRgb(96, 169, 23);
                functionAnnotation3.StrokeThickness = 2;
                functionAnnotation3.Text = "Betz's Data [Foil Stripping]";
                plotModel1.Annotations.Add(functionAnnotation3);

                var functionAnnotation4 = new FunctionAnnotation();
                functionAnnotation4.Type = FunctionAnnotationType.EquationY;
                functionAnnotation4.Color = OxyColor.FromRgb(109, 135, 100);
                functionAnnotation4.StrokeThickness = 2;
                functionAnnotation4.Text = "Schiwietz - Schmitt Data [Foil Stripper]";
                plotModel1.Annotations.Add(functionAnnotation4);
            }
            else    // Gas Stripper has been selected
            {
                for (int i = 0; i < z; i++) // Adding the data points to each data scatter series.
                {
                    scatterSeries5.Points.Add(new OxyPlot.DataPoint(data_list[i][0], data_list[i][1])); // Sayer Formula (gas)
                    if (z_t_gas < 6)  // Schiwietz - Schmitt Formula (gas) - best results for 2 < z < 6 values.
                    {
                        scatterSeries6.Points.Add(new OxyPlot.DataPoint(data_list[i][0], data_list[i][3]));
                    }
                }

                double y_axis_maximum = -1000;

                for (double j = 0; j < z; j += 0.01) // Adding the data points to each data line series and derivation of the maximum the data values.
                {
                    double dataPoint_s_gas = gaussian_fit_s(j + 1.0, qmean_s_gas, rg, epg) / sum_s_gas;
                    double dataPoint_ss_gas = gaussian_fit_b_ss(j + 1.0, qmean_ss_gas, d_ss) / sum_ss_gas;

                    if (dataPoint_s_gas > y_axis_maximum)
                    {
                        y_axis_maximum = dataPoint_s_gas;
                    }
                    if (dataPoint_ss_gas > y_axis_maximum)
                    {
                        y_axis_maximum = dataPoint_ss_gas;
                    }
                    lineSeries5.Points.Add(new OxyPlot.DataPoint(j + 1.0, dataPoint_s_gas));
                    if (z_t_gas < 6)
                    {
                        lineSeries6.Points.Add(new OxyPlot.DataPoint(j + 1.0, dataPoint_ss_gas));
                    }
                }

                var linearAxis1 = new LinearAxis();
                linearAxis1.Maximum = z + (1.0); //Setting the x axis maximum at (z+1)
                linearAxis1.Minimum = 1.0;
                linearAxis1.Position = AxisPosition.Bottom;
                plotModel1.Axes.Add(linearAxis1);

                var linearAxis2 = new LinearAxis();
                linearAxis2.Maximum = y_axis_maximum + (y_axis_maximum * 0.1); //Setting the y axis maximum at 10% over the maximum data value.
                linearAxis2.Minimum = 0;
                linearAxis2.Position = AxisPosition.Left;
                plotModel1.Axes.Add(linearAxis2);

                plotModel1.Series.Add(lineSeries5);
                plotModel1.Series.Add(lineSeries6);
                plotModel1.Series.Add(scatterSeries5);
                plotModel1.Series.Add(scatterSeries6);

                var functionAnnotation5 = new FunctionAnnotation();
                functionAnnotation5.Type = FunctionAnnotationType.EquationY;
                functionAnnotation5.Color = OxyColor.FromRgb(100, 118, 135);
                functionAnnotation5.StrokeThickness = 2;
                functionAnnotation5.Text = "Sayer's Data [Gas Stripping]";
                plotModel1.Annotations.Add(functionAnnotation5);

                var functionAnnotation6 = new FunctionAnnotation();
                functionAnnotation6.Type = FunctionAnnotationType.EquationY;
                functionAnnotation6.Color = OxyColor.FromRgb(130, 90, 44);
                functionAnnotation6.StrokeThickness = 2;
                functionAnnotation6.Text = "Schiwietz - Schmitt Data [Gas Stripping]";
                plotModel1.Annotations.Add(functionAnnotation6);
            }

            return plotModel1;
        }

        int z, z_t_foil, z_t_gas, max, q, incharge;
        List<List<double>> data;
        List<string> name = new List<string>();
        SaveFileDialog path = new SaveFileDialog();

        public TARDIS()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            InitializeComponent();
        }

        //
        // Main Program
        // The functions used follow at the end.
        //
        

        //
        // Creating the Info Box.
        // Call of seperate Form (Form2).
        //
        private void aboutButton_Click(object sender, EventArgs e) // Info box.
        {
            infoBox f2 = new infoBox();
            f2.Show();
        }
    }
}
 
