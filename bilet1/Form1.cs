using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace bilet1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.Select("select * from User where login = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'");
            if (data.Rows.Count == 1)
            {
                Form2 f2 = new Form2();
                f2.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
        }
    }
}
