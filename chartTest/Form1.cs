using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace chartTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buttonSort_Click(null, null);
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            chart.ChartAreas.First().AxisX.Title = "Ilosc elementów";
            chart.ChartAreas.First().AxisX.CustomLabels.Clear();

            chart.ChartAreas.First().AxisY.Title = "Czas trwania";
            chart.ChartAreas.First().AxisY.LabelStyle.Format = "0ms";
            

            chart.Series.Clear();

            Series sBubble = new Series();
            sBubble.ChartType = SeriesChartType.Line;
            
            int n = (int)numericUpDownStart.Value;
            
            int i = 1;
            for (int x = 1; x <= (int)numericUpDownIloscSerii.Value; x++)
            {
                BubbleSort bs = new BubbleSort(n);
                bs.Sort();
                DataPoint d = new DataPoint(i, bs.Duration);
                
                d.Label = (bs.Duration).ToString();
                d.MarkerStyle = MarkerStyle.Circle;
                d.MarkerSize  = 10;
                d.MarkerColor = Color.Red;

                sBubble.Points.Add(d);

                //ustawienie labelków dla osi X
                chart.ChartAreas.First().AxisX.CustomLabels.Add(i-0.5, i+0.5, n.ToString());
                i++;

                n*= (int)numericUpDownMnoznik.Value;

                //zabezpiecznie przed zbyt długim działaniem ... pierwsza seria powyżej 1000ms przerywa pętlę
                if (bs.Duration>1000)
                {
                    break;
                }
            }

            chart.Series.Add(sBubble);

            //dopasowanie skali a osiach wykresu
            chart.ChartAreas.First().RecalculateAxesScale();
        }
    }
}
