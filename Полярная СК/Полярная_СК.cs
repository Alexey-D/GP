using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Полярная_СК
{
    public partial class  Полярная_СК : Form
    {
        public Полярная_СК()
        {
            InitializeComponent();
            Plus.Checked = true;
            Sin.Checked = true;
        }
        public void Ok_Click(object sender, EventArgs e)
        {
            Chart.Series[0].Points.Clear();
            double x, y, res;
            int p, num1, num2;
            for (int angle = 0; angle <= 360; angle++)
            {
                p = Int32.Parse(P.Text);
                num1 = Int32.Parse(Num1.Text);
                num2 = Int32.Parse(Num2.Text);
                if (Sin.Checked)
                {
                    if (Plus.Checked)
                        res = p * (num1 + Math.Sin(num2 * angle));
                    else
                        res = p * (num1 - Math.Sin(num2 * angle));
                }
                else
                {
                    if (Plus.Checked)
                        res = p * (num1 + Math.Cos(num2 * angle));
                    else
                        res = p * (num1 - Math.Cos(num2 * angle));
                }
                x = res * Math.Cos(angle);
                y = res * Math.Sin(angle);
                Chart.Series[0].Points.AddXY(x, y);
            }
        }
    }
}
