using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Postgreconn
{
    class Globalvariables
    {
        //global class that you can call wherever
        public static NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; Port = 5432; Database = useraccount; User Id = postgres; Password = mysqlprojects101;");

                   //foreach (Control field in Controls)
            //{                if (field is TextBox)
                    //((TextBox)field).Clear();            }
        public void exitbox()
        {
           
        }

    }
}
