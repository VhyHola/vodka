using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace bilet1
{
    internal class DbConnection
    {
        public static DataTable Select(string sql)
        {
            MySqlConnectionStringBuilder builder = new
            MySqlConnectionStringBuilder();
            builder.Server = "cfif31.ru";
            builder.Port = 3306;
            builder.Database = "ISPr24-38_RashodchikovaVA_Bilet1book";
            builder.UserID = "ISPr24-38_RashodchikovaVA";
            builder.Password = "ISPr24-38_RashodchikovaVA";
            MySqlConnection connect = new
            MySqlConnection(builder.ConnectionString);
            try
            {
                connect.Open();
                MySqlCommand command = new MySqlCommand(sql, connect);
                MySqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                return table;
            }
            catch (Exception e)
            {
                MessageBox.Show("При выполнении запроса произошла ошибка! " +
                e.Message);
                return null;
            }
        }
    }
}

