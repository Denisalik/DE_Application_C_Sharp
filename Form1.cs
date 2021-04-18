using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DE_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart.ChartAreas["ChartArea1"].AxisX.Title = "x";
            chart.ChartAreas["ChartArea1"].AxisY.Title = "y";
            chart_global.ChartAreas["ChartArea1"].AxisX.Title = "x";
            chart_global.ChartAreas["ChartArea1"].AxisY.Title = "y";
            chart_local.ChartAreas["ChartArea1"].AxisX.Title = "x";
            chart_local.ChartAreas["ChartArea1"].AxisY.Title = "y";
        }

        private void button_plot_Click(object sender, EventArgs e)
        {
            
            try
            {
                double x0 = Double.Parse(textBox_x0.Text);
                double X = Double.Parse(textBox_X.Text);
                if (x0 <= 0 && X >= 0) throw new DivideByZeroException();
                double y0 = Double.Parse(textBox_y0.Text);
                int N = Int32.Parse(textBox_N.Text);
                ExactSolution es = new ExactSolution(x0, X, N, y0);
                Euler euler = new Euler(x0, X, N, y0);
                ImprovedEuler ie = new ImprovedEuler(x0, X, N, y0);
                RungeKutta rk = new RungeKutta(x0, X, N, y0);
                chart.Series[0].Points.DataBindXY(es.x, es.y);
                chart.Series[1].Points.DataBindXY(euler.x, euler.y);
                chart.Series[2].Points.DataBindXY(ie.x, ie.y);
                chart.Series[3].Points.DataBindXY(rk.x, rk.y);
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Cannot divide by 0, try to enter different data");
            }
            catch (Exception)
            {
                MessageBox.Show("Enter numbers please");
            }
        }
        private void checkbox_ES_CheckedChanged(object sender, EventArgs e)
        {
            chart.Series[0].Enabled = checkBox_ES.Checked;
        }

        private void checkbox_Euler_CheckedChanged(object sender, EventArgs e)
        {
            chart.Series[1].Enabled = checkBox_Euler.Checked;
        }

        private void checkBox_IE_CheckedChanged(object sender, EventArgs e)
        {
            chart.Series[2].Enabled = checkBox_IE.Checked;
        }

        private void checkBox_RK_CheckedChanged(object sender, EventArgs e)
        {
            chart.Series[3].Enabled = checkBox_RK.Checked;
        }

        private void button_local_Click(object sender, EventArgs e)
        {
            try
            {
                double x0_local = Double.Parse(textBox_local_x0.Text);
                double X_local = Double.Parse(textBox_local_X.Text);
                if (x0_local <= 0 && X_local >= 0) throw new DivideByZeroException();
                double y0_local = Double.Parse(textBox_local_y0.Text);
                int N_local = Int32.Parse(textBox_local_N.Text);
                ExactSolution es_local = new ExactSolution(x0_local, X_local, N_local, y0_local);
                Euler euler_local = new Euler(x0_local, X_local, N_local, y0_local);
                ImprovedEuler ie_local = new ImprovedEuler(x0_local, X_local, N_local, y0_local);
                RungeKutta rk_local = new RungeKutta(x0_local, X_local, N_local, y0_local);
                double[] euler_error = new TrunkError(es_local.y, euler_local.y, N_local).error;
                double[] ie_error = new TrunkError(es_local.y, ie_local.y, N_local).error;
                double[] rk_error = new TrunkError(es_local.y, rk_local.y, N_local).error;
                chart_local.Series[0].Points.DataBindXY(euler_local.x, euler_error);
                chart_local.Series[1].Points.DataBindXY(ie_local.x, ie_error);
                chart_local.Series[2].Points.DataBindXY(rk_local.x, rk_error);
                
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Cannot divide by 0, try to enter different data");
            }
            catch (Exception)
            {
                
                MessageBox.Show("Enter numbers please");
            }
        }

        private void checkBox_local_euler_CheckedChanged(object sender, EventArgs e)
        {
            chart_local.Series[0].Enabled = checkBox_local_euler.Checked;
        }

        private void checkBox_local_ie_CheckedChanged(object sender, EventArgs e)
        {
            chart_local.Series[1].Enabled = checkBox_local_ie.Checked;
        }

        private void checkBox_local_rk_CheckedChanged(object sender, EventArgs e)
        {
            chart_local.Series[2].Enabled = checkBox_local_rk.Checked;
        }

        private void button_global_Click(object sender, EventArgs e)
        {
            try
            {
                double x0_global = Double.Parse(textBox_global_x0.Text);
                double X_global = Double.Parse(textBox_global_X.Text);
                if (x0_global <= 0 && X_global >= 0) throw new DivideByZeroException();
                double y0_global = Double.Parse(textBox_global_y0.Text);
                int N_global = Int32.Parse(textBox_global_N.Text);
                int n0_global = Int32.Parse(textBox_global_n0.Text);
                if (n0_global > N_global) throw new ArgumentException();
                bool euler = checkBox_global_euler.Checked;
                bool ie = checkBox_global_ie.Checked;
                bool rk = checkBox_global_rk.Checked;
                GlobalError globals = new GlobalError(x0_global, X_global, y0_global, n0_global, N_global, euler, ie, rk);
                chart_global.Series[0].Points.DataBindXY(globals.arrayN, globals.maxError_euler);
                chart_global.Series[1].Points.DataBindXY(globals.arrayN, globals.maxError_ie);
                chart_global.Series[2].Points.DataBindXY(globals.arrayN, globals.maxError_rk);

            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Cannot divide by 0, try to enter different data");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Enter numbers such that n0<=N please");
            }
            catch (Exception)
            {
                
                MessageBox.Show("Enter numbers please");
            }
        }

        private void checkBox_global_euler_CheckedChanged(object sender, EventArgs e)
        {
            chart_global.Series[0].Enabled = checkBox_global_euler.Checked;
            button_global_Click(null, null);
        }

        private void checkBox_global_ie_CheckedChanged(object sender, EventArgs e)
        {
            chart_global.Series[1].Enabled = checkBox_global_ie.Checked;
            button_global_Click(null, null);
        }

        private void checkBox_global_rk_CheckedChanged(object sender, EventArgs e)
        {
            chart_global.Series[2].Enabled = checkBox_global_rk.Checked;
            button_global_Click(null, null);
        }
    }
}
