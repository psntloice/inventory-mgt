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
    public partial class customerentry : Form
    {
        string custsex;
        string custage;
        public customerentry()
        {
            InitializeComponent();
            cbage.Text = "--select--";

        }

        private void btexit_Click(object sender, EventArgs e)
        {            
                this.Close();           
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            //connect to the database
            Globalvariables.conn.Open();
            string query = "INSERT INTO customer_data(id, firstname, secondname, age, company, sex, producttype) Values(@id, @firstname, @secondname, @age, @company, @sex, @producttype)";

            if (rbmale.Checked == true)
            {
                custsex = "Male";
            }
            else
            {
                custsex = "Female";
            }


            if (cbage.Text == "10 - 18")
            {
                custage = "10 - 18";
            }
            if (cbage.Text == "19-24")
            {
                custage = "19-24";
            }
            if (cbage.Text == "25-35")
            {
                custage = "25-35";
            }
            if (cbage.Text == "36-45")
            {
                custage = "36-45";
            }
            if (cbage.Text == "50 and above")
            {
                custage = "50 and above";
            }
            try
            {
                //queries to insert data
                NpgsqlCommand comm = new NpgsqlCommand(query, Globalvariables.conn);
                comm.Parameters.AddWithValue("@firstname", tbcustfname.Text);
                comm.Parameters.AddWithValue("@secondname", tbcustsname.Text);
                comm.Parameters.AddWithValue("@id", Decimal.Parse(tbcustID.Text));
                comm.Parameters.AddWithValue("@company", tbcompany.Text);
                comm.Parameters.AddWithValue("@producttype", tbproductcustType.Text);
                comm.Parameters.AddWithValue("@age", custage);
                comm.Parameters.AddWithValue("@sex", custsex);
                 
                    comm.Prepare();//This is useful when running the same command over and over. You will save some execution time, as the whole process doesn't have to be repeated each time.
                    comm.ExecuteScalar();//needed to execute
                    MessageBox.Show("Customer added successfully");
                    foreach (Control field in Controls)
                    {
                        if (field is TextBox)
                            ((TextBox)field).Clear();
                    }                                  
            }
            catch
            {
                MessageBox.Show("error connecting");
            }                  

            //close connection
            Globalvariables.conn.Close();
        }

        private void btclear_Click(object sender, EventArgs e)
        {
            foreach (Control field in Controls)
            {
                if (field is TextBox)
                    ((TextBox)field).Clear();
            }
        }
    }
}
