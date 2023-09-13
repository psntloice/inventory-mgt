using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Postgreconn
{
    public partial class calc : Form
    {
        decimal answer;
        decimal val1 ;
        decimal val;
        int op;       
        public calc()
        {
            InitializeComponent();            

        }
                
        private void btexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btequals_Click(object sender, EventArgs e)
        {
            try
            {
                switch (op)
                {
                    case 1:
                        answer = val1 + decimal.Parse(textBox1.Text);
                        break;

                    case 2:
                        answer = val1 - decimal.Parse(textBox1.Text);
                        break;

                    case 3:
                        answer = val1 * decimal.Parse(textBox1.Text);
                        break;

                    case 4:
                        answer = val1 / decimal.Parse(textBox1.Text);
                        break;

                    case 6:
                        double myno = double.Parse(textBox1.Text);
                        double myanswer = (Math.Sqrt(myno));
                        answer = Convert.ToDecimal(myanswer);
                        textBox1.Text = string.Empty;
                        break;
                }

                string ans = answer.ToString();
                button1.Text = ans;

            }//answer = 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btclear_Click(object sender, EventArgs e)
        {
            button1.Text = "0";
            answer = 0;
            textBox1.Text = "0";
        }

        private void btplus_Click(object sender, EventArgs e)
        {
            op = 1;
            val1 = decimal.Parse(textBox1.Text);
            textBox1.Text = string.Empty;
        }

        private void btminus_Click(object sender, EventArgs e)
        {
            op = 2;
            val1 = decimal.Parse(textBox1.Text);
            textBox1.Text = string.Empty;
        }

        private void btmultiply_Click(object sender, EventArgs e)
        {
            op = 3;
            val1 = decimal.Parse(textBox1.Text);
            textBox1.Text = string.Empty;
        }

        private void btdivide_Click(object sender, EventArgs e)
        {
            op = 4;
            val1 = decimal.Parse(textBox1.Text);
            textBox1.Text = string.Empty;
        }

        private void btsqroot_Click(object sender, EventArgs e)
        {
            op = 6;
            //val1 = decimal.Parse(textBox1.Text);
            //textBox1.Text = string.Empty;
        }

        private void btseven_Click(object sender, EventArgs e)
        {
            val = 7;        
            textBox1.Text += 7;
            //val1 = 
        }

        private void bteight_Click(object sender, EventArgs e)
        {
            val = 8;
            textBox1.Text += 8;
        }

        private void btnine_Click(object sender, EventArgs e)
        {
            val = 9;
            textBox1.Text += 9;
        }

        private void btfour_Click(object sender, EventArgs e)
        {
            val = 4;
            textBox1.Text += 4;
        }

        private void btfive_Click(object sender, EventArgs e)
        {
            val = 5;
            textBox1.Text += 5;
        }

        private void btsix_Click(object sender, EventArgs e)
        {
            val = 6;
            textBox1.Text += 6;
        }

        private void btone_Click(object sender, EventArgs e)
        {
            val = 1;
            textBox1.Text += 1;
        }

        private void bttwo_Click(object sender, EventArgs e)
        {
            val = 2;
            textBox1.Text += 2;
        }

        private void btthree_Click(object sender, EventArgs e)
        {
            val = 3;
            textBox1.Text += 3;
        }

        private void btzero_Click(object sender, EventArgs e)
        {
            val = 0;
            textBox1.Text += 0;
        }

        private void btfulstop_Click(object sender, EventArgs e)
        {
            //val = 0;
            textBox1.Text = textBox1.Text + ".";
        }
       
    }
}
