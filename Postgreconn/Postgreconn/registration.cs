using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;//enable postgre connection

namespace Postgreconn
{
    public partial class registration : Form
    {
        string empsex;
        string emped;
        string empcontract;
        public registration()
        {
            InitializeComponent();
            cbedlevel.Text = "--select--";
            cbcontract.Text = "--select--";
            


        }       
        

        private void btcreate_Click(object sender, EventArgs e)
        {
            //connect to the database
            Globalvariables.conn.Open();
            string query = "INSERT INTO employee_data(id, firstname, secondname, surname, email, password, age, sex, edlevel, phoneno, department, salary, bonus, commission, jobtype, contracttype, hiredate) Values(@id,@firstname,@secondname,@surname,@email,@password,@age, @sex, @edlevel, @phoneno, @department, @salary, @bonus, @commission, @jobtype, @contracttype, @hiredate);";


            if (rbmale.Checked == true)
            {
                empsex = "Male";
            }
            else
            {
                empsex = "Female";
            }



            if (cbedlevel.Text == "Primary level")
            {    
                emped = "Primary";
            }
            if (cbedlevel.Text == "Secondary level")
            {
                emped = "Secondary";
            }
            if (cbedlevel.Text == "University level")
            {
                emped = "University";
            }


            if (cbcontract.Text == "3 months")
            {
                empcontract = "three";
            }
            if (cbcontract.Text == "6 months")
            {
                empcontract = "six";
            }
            if (cbcontract.Text == "1 year")
            {
                empcontract = "year";
            }
            if (cbcontract.Text == "Permanent")
            {
                empcontract = "permanent";
            }
            try { 
            //queries to insert data
            NpgsqlCommand comm = new NpgsqlCommand(query, Globalvariables.conn);
            comm.Parameters.AddWithValue("@firstname", tbfname.Text);
            comm.Parameters.AddWithValue("@secondname", tbsname.Text);
            comm.Parameters.AddWithValue("@surname", tbsurname.Text);
            comm.Parameters.AddWithValue("@id", Decimal.Parse(tbuserID.Text));
            comm.Parameters.AddWithValue("@email", tbemail.Text);
            comm.Parameters.AddWithValue("@password", tbpassword.Text);
            comm.Parameters.AddWithValue("@age", Decimal.Parse(tbemage.Text));
            comm.Parameters.AddWithValue("@sex", empsex);
            comm.Parameters.AddWithValue("@edlevel", emped);
            comm.Parameters.AddWithValue("@phoneno", tbphone.Text);
            comm.Parameters.AddWithValue("@department", tbdept.Text); 
            comm.Parameters.AddWithValue("@salary", Decimal.Parse(tbsalary.Text));
            comm.Parameters.AddWithValue("@bonus", Decimal.Parse(tbbonus.Text));
            comm.Parameters.AddWithValue("@commission", Decimal.Parse(tbcomm.Text));
            comm.Parameters.AddWithValue("@jobtype", tbjobtype.Text);
            comm.Parameters.AddWithValue("@contracttype", empcontract);
            comm.Parameters.AddWithValue("@hiredate", dateTimePicker1.Value);         

                if (tbpassword.Text == tbconfirm.Text)
                {
                    comm.Prepare();//This is useful when running the same command over and over. You will save some execution time, as the whole process doesn't have to be repeated each time.
                    comm.ExecuteScalar();//needed to execute
                    MessageBox.Show("Employee added successfully");
                    foreach (Control field in Controls)
                    {
                        if (field is TextBox)
                            ((TextBox)field).Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Password not matching!");
                }
            }
            catch {
                MessageBox.Show("error connecting");
            }
            //confirm if password matches
            
           //close connection
            Globalvariables.conn.Close();

            //Utilities.ResetAllControls(this);

        }

       

        private void btclear_Click(object sender, EventArgs e)
        {
            foreach (Control field in Controls)
            {
                if (field is TextBox)
                    ((TextBox)field).Clear();
            }
        }

        private void btexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
