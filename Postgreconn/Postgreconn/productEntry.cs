using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Postgreconn
{
    public partial class productEntry : Form
    {
        string prdstatus;
        int myid = 34;
        public productEntry()
        {
            InitializeComponent();
            cbstatus.Text = "--select--";
            tbbuyingp.Text = "0";
            tbwholesale.Text = "0";
            tbsellingprice.Text = "0";
            tbquantity.Text = "0";
            tbdiscount.Text = "0";
            
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btproductadd_Click(object sender, EventArgs e)
        {
            myid += 1;

            //connect to the database
            Globalvariables.conn.Open();
            string query = "INSERT INTO product_data(pid, pname, pbuyingp, pwholesalep, psellingp, pcategory, pbrand, pboughtfrom, pquantity, pdescription, pdiscount, porderdate, pdeliverdate, pstatus) Values(@pid, @pname, @pbuyingp, @pwholesalep, @psellingp, @pcategory, @pbrand, @pboughtfrom, @pquantity, @pdescription, @pdiscount, @porderdate, @pdeliverdate, @pstatus)";

            if (cbstatus.Text == "Good")
            {
                prdstatus = "Good";
            }
            if (cbstatus.Text == "Expired")
            {
                prdstatus = "Expired";
            }
            if (cbstatus.Text == "Poor")
            {
                prdstatus = "Poor";
            }
            try
            {
                //queries to insert data
                NpgsqlCommand comm = new NpgsqlCommand(query, Globalvariables.conn);

                comm.Parameters.AddWithValue("@pid", myid);
                comm.Parameters.AddWithValue("@pname", tbproduct.Text);
                comm.Parameters.AddWithValue("@pbuyingp", Decimal.Parse(tbbuyingp.Text));
                comm.Parameters.AddWithValue("@pwholesalep", Decimal.Parse(tbwholesale.Text));
                comm.Parameters.AddWithValue("@psellingp", Decimal.Parse(tbsellingprice.Text));
                comm.Parameters.AddWithValue("@pcategory", tbcategory.Text);
                comm.Parameters.AddWithValue("@pbrand", tbbrand.Text);
                comm.Parameters.AddWithValue("@pboughtfrom", tbfrom.Text);
                comm.Parameters.AddWithValue("@pquantity", Decimal.Parse(tbquantity.Text));
                comm.Parameters.AddWithValue("@pdescription", tbdescription.Text);
                comm.Parameters.AddWithValue("@pdiscount", Decimal.Parse(tbdiscount.Text));
                comm.Parameters.AddWithValue("@porderdate", dateTimePicker1.Value);
                comm.Parameters.AddWithValue("@pdeliverdate", dateTimePicker2.Value);
                comm.Parameters.AddWithValue("@pstatus", prdstatus);
                

                comm.Prepare();//This is useful when running the same command over and over. You will save some execution time, as the whole process doesn't have to be repeated each time.
                comm.ExecuteScalar();//needed to execute
                MessageBox.Show("Product added successfully");
                foreach (Control field in Controls)
                {
                    if (field is TextBox)
                        ((TextBox)field).Clear();
                }

                /* while (true)
                 {
                     //comm.Parameters.AddWithValue("@pid", myid);
                     myid+=1 ;
                     // myid = "@pid";
                 }*/
                myid += 1;

                tbbuyingp.Text = "0";
                tbwholesale.Text = "0";
                tbsellingprice.Text = "0";
                tbquantity.Text = "0";
                tbdiscount.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //close connection
            Globalvariables.conn.Close();
        }

        private void btprdclear_Click(object sender, EventArgs e)
        {
            foreach (Control field in Controls)
            {
                if (field is TextBox)
                    ((TextBox)field).Clear();
            }

            tbbuyingp.Text = "0";
            tbwholesale.Text = "0";
            tbsellingprice.Text = "0";
            tbquantity.Text = "0";
            tbdiscount.Text = "0";
        }
    }
}
