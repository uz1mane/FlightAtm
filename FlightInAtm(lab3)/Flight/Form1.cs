using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flight.BusinessModel;

namespace Flight
{
    public partial class Form1 : Form
    {

        Model model;

        public Form1()
        {
            InitializeComponent();            
        }
        
        public double[] ReadData()
        {
            double[] mas = new double[5];
            mas[0] = (double)edAngle.Value;
            mas[1] = (double)edSpeed.Value;
            mas[2] = (double)edHeight.Value;
            mas[3] = (double)edWeight.Value;
            mas[4] = (double)edSquare.Value;

            return mas;
        }
        private void btStart_Click(object sender, EventArgs e)
        {
            model = new Model(this);

            KeyValuePair<double, double> pair = model.Start();

            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(pair.Key, pair.Value);
            
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            KeyValuePair<double, double> pair = model.NextTick();
           
            chart1.Series[0].Points.AddXY(pair.Key, pair.Value);
            if (pair.Value <= 0)
                timer1.Stop();
        }
    }
}
