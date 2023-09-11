using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CSharp_Bai7_PTBAC2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblPT.Text = "ax" + ("\u00B2") + " + bx + c = 0";
            int i;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 200;            
            for (i = 0; i <= 200; i++)
            {
                progressBar1.Value = i;

            }

            trbSoA.Value = Convert.ToInt32(txtSoA.Text);
            trbSoB.Value = Convert.ToInt32(txtSoB.Text);
            trbSoC.Value = Convert.ToInt32(txtSoC.Text);
        }

        private void btnGiaiPT_Click(object sender, EventArgs e)
        {
            int intA, intB, intC;
            double delta, x1, x2;
            intA = Convert.ToInt32(txtSoA.Text);
            intB = Convert.ToInt32(txtSoB.Text);
            intC = Convert.ToInt32(txtSoC.Text);



            // Short IF
            string strB = (intB < 0) ? " - " + Math.Abs(intB) : " + " + Math.Abs(intB);
            string strC = (intC < 0) ? " - " + Math.Abs(intC) : " + " + Math.Abs(intC);

            // string strB, strC;
            // if (intB < 0) {
            //     strB = " - " + Math.Abs(intB);
            // } else {
            //     strB = " + " + Math.Abs(intB);
            // }

            lblPT.Text = intA + "x" + ("\u00B2") + strB  + "x"+ strC + " = 0";

            // Nếu A = 0 thì phương trình bậc 2 trở thành phương trình bậc 1, tiến hành giải phương trình bậc 1 với bX + c = 0
            if (intA == 0) {
                giaiPTbac1(intB, intC, lblKQ);
            } else {
                delta = (double)Math.Pow(intB, 2) - 4 * intA * intC;
                lblKQ.Text = "Delta = " + Convert.ToString(delta) + "\n";
                if (delta < 0) {
                    // phương trình đã cho vô nghiệm.
                    lblKQ.Text += "Phương trình vô nghiệm\n";
                }
                if (delta == 0) {
                    // phương trình có nghiệm kép x=-b/2a
                    lblKQ.Text += "Phương trình có nghiệm kép x1 = x2 = "+ (double)(-intB / (2 * intA)) + "\n";
                    
                }
                if (delta > 0) {
                    // phương trình có 2 nghiệm phân biệt.
                    x1 = (double)(-intB + Math.Sqrt(delta)) / (2 * intA);
                    x2 = (double)(-intB - Math.Sqrt(delta)) / (2 * intA);
                    lblKQ.Text += "Phương trình có 2 nghiệm\n";
                    lblKQ.Text += "x1 = " + x1 + "\n";
                    lblKQ.Text += "x2 = " + x2 + "\n";
                }
            }






        }
        private void khiDiChuot(object sender, EventArgs e)
        {
            int i;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 200;
            for (i = 0; i <= 200; i++)
            {
                progressBar1.Value = i;


            }
        }

        private void trbSoA_Scroll(object sender, EventArgs e)
        {
            txtSoA.Text = trbSoA.Value.ToString();
        }

        private void trbSoB_Scroll(object sender, EventArgs e)
        {
            txtSoB.Text = trbSoB.Value.ToString();
        }

        private void trbSoC_Scroll(object sender, EventArgs e)
        {
            txtSoC.Text = trbSoC.Value.ToString();
        }

        static void giaiPTbac1(int intA, int intB, Control lblKQinFunction)
        {
            // bx + c = 0
            lblKQinFunction.Text = "";
            if (intA == 0 && intB == 0)
            {
                //Console.WriteLine(" Phuong trinh co vo so nghiem");
                lblKQinFunction.Text = "Phương trình có vô số nghiệm\n";
            }
            else if (intA == 0 && intB != 0)
            {
                lblKQinFunction.Text = "Phương trình vô nghiệm\n";
            }
            else
            {
                //Console.WriteLine(" Phuong trinh co 1 nghiem duy nhat x = {0}", (double)-intB / intA);
                lblKQinFunction.Text = "Phương trình có 1 nghiệm duy nhất x = " + ((double)-intB / intA) + "\n";
            }
        }
    }
}
