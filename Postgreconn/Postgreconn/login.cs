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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        private void btlogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbusername.Text == "" || tbpasswd.Text == "")
                { MessageBox.Show("Please enter the username or ID"); }
                else
                {
                    Globalvariables.conn.Open();
                    string query = "SELECT id, password FROM admin_data WHERE id= '" + tbusername.Text + "' and password= '" + tbpasswd.Text + "'";

                    NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, Globalvariables.conn);
                    DataTable dtb1 = new DataTable();
                    //fill the table with whichever entry in the db that fits the criteria of having the username and password input in the textbox
                    sda.Fill(dtb1);

                    //map the entered details to those of the database, if there's 1elemnt thats a match allow access
                    if (dtb1.Rows.Count == 1)
                    {

                        admin obj = new admin();
                        obj.Show();
                        this.Hide();
                        //this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Enter correct username/password!");
                        foreach (Control field in Controls)
                        {
                            if (field is TextBox)
                                ((TextBox)field).Clear();
                        }
                    }

                    Globalvariables.conn.Close();
                }          
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }


        }
        private void btsignin_Click(object sender, EventArgs e)
        {
            if (tbusername.Text == "" || tbpasswd.Text == "")
            { MessageBox.Show("Please enter the username or ID"); }
            else
            {
                try { 
                Globalvariables.conn.Open();
                string query = "SELECT id, password FROM employee_data WHERE id= '" + tbusername.Text + "' and password= '" + tbpasswd.Text + "'";

                NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, Globalvariables.conn);
                DataTable dtb1 = new DataTable();
                //fill the table with whichever entry in the db that fits the criteria of having the username and password input in the textbox
                sda.Fill(dtb1);
                
                    //map the entered details to those of the database, if there's 1 elemnt thats a match allow access
                    if (dtb1.Rows.Count == 1)
                    {
                        //MessageBox.Show("login successful");
                        mainwindow obj = new mainwindow();
                        obj.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Enter correct username/password!");
                        foreach (Control field in Controls)
                        {
                            if (field is TextBox)
                                ((TextBox)field).Clear();
                        }
                    }

                }

                catch
                {
                    MessageBox.Show("error connecting");
                }


                Globalvariables.conn.Close();
            }
        }

        private void btexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbpasswd_Enter(object sender, EventArgs e)
        {
            this.tbpasswd.PasswordChar = '●';
            this.tbpasswd.UseSystemPasswordChar = true;
        }

        private void tbpasswd_Click(object sender, EventArgs e)
        {
            this.tbpasswd.PasswordChar = '●';
            this.tbpasswd.UseSystemPasswordChar = true;
            //\u25CF
        }
    }         

}

             /* string userID = tbusername.Text;
            string paswd = tbpasswd.Text;

            Globalvariables.conn.Open();
            string query = "SELECT id, password FROM personalinfo where id=@id and password=@password";
            NpgsqlCommand comm = new NpgsqlCommand(query, Globalvariables.conn);

            var reader = comm.ExecuteReader();



            //int val;
            //val = Int32.Parse(reader[0].ToString());

            //MessageBox.Show(val);

            int id = 0;
            while(reader.Read())   var myid = Int32.Parse(reader["id"].ToString());
                Console.WriteLine(myid);
            }


            if (userID == null)
                {
                MessageBox.Show("Please enter the username or ID");        
            }
            if (paswd == null)
                {
                MessageBox.Show("Please enter the username or ID");
            }



            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                //MessageBox.Show("\t[0]", reader.GetInt32(0));
            }

            reader.Close();
                //if userID in username

                //if paswd in password


                Globalvariables.conn.Close();*/
                                               