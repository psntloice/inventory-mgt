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
    public partial class admin : Form
    {
        string query = " ";
        bool isCollapsed;
        public admin()
        {
            InitializeComponent();

            this.comboBox1.Items.Clear();
            chart1.Series["Age"].Points.AddXY("may", 37);
            chart1.Series["Age"].Points.AddXY("mary", 37);
            chart1.Series["Age"].Points.AddXY("mrsy", 37);
        }

        private void defalt()
        {
            txttrysearch.Clear();
            this.txttrysearch.Enabled = false;
            comboBox2.SelectedIndex = -1;           
            this.comboBox1.Items.Clear();
            panel2.Hide();
            chart1.Hide();            
            if (dbGrid.Visible == true)
            { dbGrid.Hide(); }
            
        }

        //*************************************************************************************************************//
        //combobox
        //upon combo selection
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            dbGrid.Show();
            if (comboBox2.Text == "Employee")
            {
                query = "SELECT * from employee_data;";
            }
            if (comboBox2.Text == "Products")
            {
                query = "SELECT * from product_data;";
            }
            if (comboBox2.Text == "Customer")
            {
                query = "SELECT * from customer_data;";
            }
            if (comboBox2.Text == "Departments")
            {
                query = "SELECT * from employee_data;";
            }

            postgreconnection(query);
            additemcombo();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "--select--" || comboBox1.Text != " " || comboBox2.Text != " ")
            { this.txttrysearch.Enabled = true; }
        }
        //*************************************************************************************************************//
        //menustrip

        private void productsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            dbGrid.Show();
            query = "SELECT * FROM product_data;";
            postgreconnection(query);
        }
        private void customersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dbGrid.Show();
            query = "SELECT * FROM customer_data;";
            postgreconnection(query);
        }
        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dbGrid.Show();
            query = "SELECT * FROM employee_data;";
            postgreconnection(query);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            defalt();
            registration oj = new registration();
            oj.Show();
        }
        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            defalt();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
                //Environment.Exit(1);
                //login obj = (login)Application.OpenForms["login"];
                //obj.Close();
            }
            else
            { //e.Cancel = true;
            }
        }
        private void analysisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            defalt();
            chart1.Show();
        }

        //*************************************************************************************************************//
        //timer
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (isCollapsed)
                {
                    btcompanydata.BackColor = System.Drawing.Color.DarkGray;
                    //btcustomers.Image = Postgreconn.Properties.Resources.bs3;
                    panel5.Height += 10;
                    if (panel5.Size == panel5.MaximumSize)
                    {
                        timer2.Stop();
                        isCollapsed = false;
                    }
                }
                else
                {
                    btcompanydata.BackColor = System.Drawing.Color.Transparent;
                    //btcustomers.Image = Postgreconn.Properties.Resources.BS1;
                    panel5.Height -= 10;
                    if (panel5.Size == panel5.MinimumSize)
                    {
                        timer2.Stop();
                        isCollapsed = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
        //*************************************************************************************************************//
        //functions
        //posgre connection method
        private void postgreconnection(string query)
        {
            try {
                Globalvariables.conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand(query, Globalvariables.conn);
                //comm.Prepare();
                comm.CommandType = CommandType.Text;
                NpgsqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dbGrid.DataSource = dt;

                }
                comm.Dispose();

                Globalvariables.conn.Close();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void secendsearch()
        {
            try
            {
                if (comboBox2.Text == "Employee")
                {
                    if (comboBox1.Text == "Surname")
                    {
                        query = "SELECT * from employee_data WHERE lower(surname) LIKE '%" + txttrysearch.Text.ToLower() + "%' ;";
                    }
                    if (comboBox1.Text == "ID")
                    {
                        //query = "SELECT * from employee_data WHERE lower(id) LIKE '%" + txttrysearch.Text.ToLower() + "%' ;";
                    }
                    if (comboBox1.Text == "Department")
                    {
                        query = "SELECT * from employee_data WHERE lower(department) LIKE '%" + txttrysearch.Text.ToLower() + "%' ;";
                    }

                }
                if (comboBox2.Text == "Products")
                {
                    if (comboBox1.Text == "Product name")
                    {
                        query = "SELECT * from product_data WHERE lower(pname) LIKE '%" + txttrysearch.Text.ToLower() + "%' ;";
                    }
                    if (comboBox1.Text == "Product status")
                    {
                        query = "SELECT * from product_data WHERE lower(pstatus) LIKE '%" + txttrysearch.Text.ToLower() + "%' ;";
                    }
                    if (comboBox1.Text == "Category")
                    {
                        query = "SELECT * from product_data WHERE lower(pcategory) LIKE '%" + txttrysearch.Text.ToLower() + "%' ;";
                    }

                }
                if (comboBox2.Text == "Customer")
                {
                    if (comboBox1.Text == "First name")
                    {
                        query = "SELECT * from customer_data WHERE lower(firstname) LIKE '%" + txttrysearch.Text.ToLower() + "%' ;";
                    }
                    if (comboBox1.Text == "ID")
                    {
                        //query = "SELECT * from customer_data WHERE lower(id) LIKE '%" + txttrysearch.Text.ToLower() + "%' ;";
                    }
                    if (comboBox1.Text == "Company")
                    {
                        query = "SELECT * from customer_data WHERE lower(company) LIKE '%" + txttrysearch.Text.ToLower() + "%' ;";
                    }

                }
                if (comboBox2.Text == "Departments")
                {
                    if (comboBox1.Text == "Name")
                    {
                        query = "SELECT * from employee_data WHERE lower(department) LIKE '%" + txttrysearch.Text.ToLower() + "%' ;";
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void additemcombo()
        {
            try
            {
                if (comboBox2.Text == "Employee")
                {
                    comboBox1.Text = "--select--";
                    txttrysearch.Clear();
                    this.comboBox1.Items.Clear();
                    this.txttrysearch.Enabled = false;
                    this.comboBox1.Items.AddRange(new object[] {
            "Surname",
            "ID",
            "Department"});
                }
                if (comboBox2.Text == "Products")
                {
                    comboBox1.Text = "--select--";
                    txttrysearch.Clear();
                    this.comboBox1.Items.Clear();
                    this.txttrysearch.Enabled = false;
                    this.comboBox1.Items.AddRange(new object[] {
            "Product name",
            "Product status",
            "Category"});
                }
                if (comboBox2.Text == "Customer")
                {
                    comboBox1.Text = "--select--";
                    txttrysearch.Clear();
                    this.comboBox1.Items.Clear();
                    this.txttrysearch.Enabled = false;
                    this.comboBox1.Items.AddRange(new object[] {
            "First name",
            "ID",
            "Company"});
                }
                if (comboBox2.Text == "Departments")
                {
                    comboBox1.Text = "--select--";
                    txttrysearch.Clear();
                    this.comboBox1.Items.Clear();
                    this.txttrysearch.Enabled = false;
                    this.comboBox1.Items.AddRange(new object[] {
            "Name"
            });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //*************************************************************************************************************//
        //other fncts
        
        //fill datagrid with data function
        private DataTable getData(string query)
        {
            Globalvariables.conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(query, Globalvariables.conn);


            //comm.Prepare();
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(comm);
            DataTable dtb1 = new DataTable();

            sda.Fill(dtb1);
            Globalvariables.conn.Close();
            return dtb1;

        }
        

        //load dev
        private void memberload()
        {
            /*
            string search = "%" + txttrysearch.Text.ToLower() + "%";
            if (txtSearch.Text.Length > 1)
            {
                query = "SELECT * FROM employee_data WHERE lower  (firstname) like @search;";
            }
            else
            {
                query = "SELECT firstname FROM employee_data;";
            }
            try
            {
                Globalvariables.conn.Open();
                dbGrid.Rows.Clear();
                NpgsqlCommand comm = new NpgsqlCommand(query, Globalvariables.conn);
                comm.Parameters.AddWithValue("@search", search);
                NpgsqlDataReader rrd = comm.ExecuteReader();
                int t = 0;
                while (rrd.Read())
                {
                    dbGrid.Rows.Add(rrd["firstname"]);
                    t++;


                }
                Globalvariables.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Globalvariables.conn.Close();
            }*/
        }
        
        //*************************************************************************************************************//
        //buttons
        private void btgoodshow_Click(object sender, EventArgs e)
        {
            defalt();
            panel2.Show();
        }

        private void btgoodedit_Click(object sender, EventArgs e)
        {
            defalt();
            dbGrid.Show();
            query = "SELECT * FROM product_data;";
            postgreconnection(query);
        }

        private void btgoodadd_Click(object sender, EventArgs e)
        {
            defalt();
            dbGrid.Show();
            query = "SELECT * FROM customer_data;";
            postgreconnection(query);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            defalt();
            registration oj = new registration();
            oj.Show();
        }

        private void btemplshow_Click(object sender, EventArgs e)
        {
            defalt();
            dbGrid.Show();
            query = "SELECT * FROM employee_data;";
            postgreconnection(query);
        }

        private void btemplanalysis_Click(object sender, EventArgs e)
        {
            defalt();
            chart1.Show();
        }

        private void btprojects_Click(object sender, EventArgs e)
        {
            defalt();
        }

        private void btfinances_Click(object sender, EventArgs e)
        {
            defalt();
        }

        private void btreports_Click(object sender, EventArgs e)
        {
            defalt();
        }

        private void btprograms_Click(object sender, EventArgs e)
        {
            defalt();
        }

        private void btevents_Click(object sender, EventArgs e)
        {
            defalt();
        }

        private void btsettings_Click(object sender, EventArgs e)
        {
            defalt();
        }

        private void bthome_Click(object sender, EventArgs e)
        {
            defalt();
        }

        private void btcompanydata_Click(object sender, EventArgs e)
        {
            defalt();
            timer2.Start();
        }

        private void btexit_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
                //Environment.Exit(1);
                //login obj = (login)Application.OpenForms["login"];
                //obj.Close();
            }
            else
            { //e.Cancel = true;
            }
        }

        private void btempldashboard_Click(object sender, EventArgs e)
        {
            mainwindow obj = new mainwindow();
            obj.Show();
            this.Close();
        }

        //*************************************************************************************************************//
        //search
        private void txttrysearch_TextChanged(object sender, EventArgs e)
        {
            try
                {
                    if (comboBox1.Text != "--select--" || comboBox1.Text != " " || comboBox2.Text != " ")
                    {
                        secendsearch();
                        postgreconnection(query);
                    }
                    else
                    {
                        //nothing
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            txttrysearch.Clear();
        }
    }
}
