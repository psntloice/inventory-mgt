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
    public partial class Inventor : Form
    {
        public Inventor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO public.smalltable(good_name,  brand)	VALUES(@good_name, @brand);";

            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; Port = 5432; Database = pos_trial; User Id = postgres; Password = mysqlprojects101;");
                conn.Open();
                //Globalvariable.conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                //cmd.Parameters.AddWithValue("@carid", int.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString()));
                cmd.Parameters.AddWithValue("@good_name", textBox1.Text);
                //cmd.Parameters.AddWithValue(" @price", textBox3.Text);
                cmd.Parameters.AddWithValue("@brand", textBox2.Text);
                cmd.ExecuteScalar();
                conn.Close();
                MessageBox.Show("Success", "msg", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //conn.Close();
            }
        }
    }
}
