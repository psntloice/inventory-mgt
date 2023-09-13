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
    public partial class mainwindow : Form
    {
        string query;
        private bool isCollapsed;
        private bool istwoCollapsed;
        login objlogin = new login();
        //calc objcalc = new calc();
        customerentry objcust = new customerentry();
        productEntry objproduct = new productEntry();

        public mainwindow()
        {
            InitializeComponent();
            this.comboBox1.Items.Clear();
        }
        private void defalt()
        {
                    
            txttrysearch.Clear();
            this.txttrysearch.Enabled = false;
            comboBox2.SelectedIndex = -1;
            this.comboBox1.Items.Clear();
            //objlogin.Hide();
            //objcalc.Hide();
            //objcust.Hide();
            //objproduct.Hide();
            //if (dbGrid.Visible == true)
            //{ dbGrid.Hide(); }

        }

        private void btadmin_Click(object sender, EventArgs e)
        {
            defalt();
            objlogin.Show();
            this.Close();
        }

        private void btexit_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            { //e.Cancel = true;
            }
        }

        private void btgoodshow_Click(object sender, EventArgs e)
        {
            panel6.Hide();
            dbGrid.Show();
            query = "SELECT * FROM product_data;";
            postgreconnection(query);

            //dbGrid.DataSource obj = new dbGrid.DataSource();
            //obj.Show();
        }

        calc c2;
        
        private void btcalculator_Click(object sender, EventArgs e)
        {
            c2 = new calc();
            c2.MdiParent = this;
            c2.FormClosed += new FormClosedEventHandler(c2_FormClosed);
            c2.Show();
            if (c2 == null)
                {
                    c2 = new calc();
                    c2.MdiParent = this;
                    c2.FormClosed += new FormClosedEventHandler(c2_FormClosed);
                    c2.Show();
                }
                else
                    c2.Activate();
         
            //calc objcalc = new calc();
            //objcalc.Hide();
            //objcalc.Show();
        }

        void c2_FormClosed(object sender, FormClosedEventArgs e)
        {
            c2 = null;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (isCollapsed)
                {
                    btproducts.BackColor = System.Drawing.Color.DarkGray;
                    //btcustomers.Image = Postgreconn.Properties.Resources.bs3;
                    panel5.Height += 10;
                    if (panel5.Size == panel5.MaximumSize)
                    {
                        timer1.Stop();
                        isCollapsed = false;
                    }
                }
                else
                {
                    btproducts.BackColor = System.Drawing.Color.Transparent;
                    //btcustomers.Image = Postgreconn.Properties.Resources.BS1;
                    panel5.Height -= 10;
                    if (panel5.Size == panel5.MinimumSize)
                    {
                        timer1.Stop();
                        isCollapsed = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btcustomers_Click(object sender, EventArgs e)
        {
            panel6.Hide();
            timer2.Start();
        }

        private void bttransactions_Click(object sender, EventArgs e)
        {
            panel6.Hide();
        }

        private void btbatches_Click(object sender, EventArgs e)
        {
            panel6.Hide();
        }

        private void btinvoice_Click(object sender, EventArgs e)
        {
            panel6.Hide();
        }

        private void btreports_Click(object sender, EventArgs e)
        {
            panel6.Hide();
        }

        private void btprograms_Click(object sender, EventArgs e)
        {

            panel6.Hide();
        }

        private void btsettings_Click(object sender, EventArgs e)
        {
            
        }

        private void bthome_Click(object sender, EventArgs e)
        {
            defalt();
            dbGrid.Hide();
            panel6.Show();
            
            
        }

        private void btproducts_Click(object sender, EventArgs e)
        {
            panel6.Hide();
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (istwoCollapsed)
                {
                    btcustomers.BackColor = System.Drawing.Color.DarkGray;
                    //btcustomers.Image = Postgreconn.Properties.Resources.bs3;
                    panel3.Height += 10;
                    if (panel3.Size == panel3.MaximumSize)
                    {
                        timer2.Stop();
                        istwoCollapsed = false;
                    }
                }
                else
                {
                    btcustomers.BackColor = System.Drawing.Color.Transparent;
                    //btcustomers.Image = Postgreconn.Properties.Resources.BS1;
                    panel3.Height -= 10;
                    if (panel3.Size == panel3.MinimumSize)
                    {
                        timer2.Stop();
                        istwoCollapsed = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btgoodedit_Click(object sender, EventArgs e)
        {
            panel6.Hide();
            dbGrid.Show();
            query = "SELECT * FROM product_data;";
            postgreconnection(query);
        }

        private void btcustomeredit_Click(object sender, EventArgs e)
        {
            panel6.Hide();
            dbGrid.Show();
            query = "SELECT * FROM customer_data;";
            postgreconnection(query);

        }

        private void btcustadd_Click(object sender, EventArgs e)
        {
            defalt();
            objcust.Show();
        }

        private void btcustomershow_Click(object sender, EventArgs e)
        {
            panel6.Hide();
            dbGrid.Show();
            query = "SELECT * FROM customer_data;";
            postgreconnection(query);

        }
        private void postgreconnection(string query)
        {
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btgoodadd_Click(object sender, EventArgs e)
        {
            objproduct.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            { //e.Cancel = true;
            }

        }

        private void productsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            dbGrid.Show();
            panel6.Hide();
            query = "SELECT * FROM product_data;";
            postgreconnection(query);
        }

        private void customersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dbGrid.Show();
            panel6.Hide();
            query = "SELECT * FROM customer_data;";
            postgreconnection(query);
        }

        private void productsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            defalt();
            //objproduct.Show();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            defalt();
            //objcust.Show();
        }

        private void mainwindow_Load(object sender, EventArgs e)
        {
            dbGrid.Hide();

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void productsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            dbGrid.Show();
            panel6.Hide();
        }

        private void customesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbGrid.Show();
            panel6.Hide();
        }

        private void btrefresh_Click(object sender, EventArgs e)
        {
            //secendsearch();
            //postgreconnection(query);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbGrid.Show();
            panel6.Hide();
            if (comboBox2.Text == "Employee")
            {
                query = "SELECT * from employee_data;";
            }
            if (comboBox2.Text == "Product")
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
                       // String myval = txttrysearch.Text;
                       // Int32 i;
                       // if (!String.IsNullOrWhitespace(myval) && Int32.TryParse(myval, out i))
                       // { query = "SELECT * from employee_data WHERE id= '" + txttrysearch.Text + "'"; }
                    }
                    if (comboBox1.Text == "Department")
                    {
                        query = "SELECT * from employee_data WHERE lower(department) LIKE '%" + txttrysearch.Text.ToLower() + "%' ;";
                    }

                }
                if (comboBox2.Text == "Product")
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
                       // query = "SELECT * from customer_data WHERE id LIKE '%" + txttrysearch.Text + "%' ;";
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
                if (comboBox2.Text == "Product")
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

        private void txttrysearch_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "--select--" || comboBox1.Text != " " || comboBox2.Text != " ")
            {
                secendsearch();
               postgreconnection(query);
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            txttrysearch.Clear();
        }
    }   
}
