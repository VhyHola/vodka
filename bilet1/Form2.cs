using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bilet1
{
    public partial class Form2 : Form
    {
        public Form2()
        {

            InitializeComponent();

            DataTable data = DbConnection.Select("SELECT * FROM Book");
            dataGridView1.DataSource = data;
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name; string newValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            int index = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            DbConnection.Select($"UPDATE Book SET {columnName}='{newValue}' where idBook={index}");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            {
                if ((textBox1.Text == "") || (textBox2.Text == "") ||
                (textBox3.Text == ""))
                {
                    MessageBox.Show("Заполните ВСЕ поля");
                }
                else
                {
                    DataTable data = DbConnection.Select(@"INSERT INTO Book
(`BookName`, `id_Avtor`,`id_Genre`) VALUES ('" + textBox1.Text + "', '" +
                    textBox2.Text + "', '" + textBox3.Text + "');");
                    data = DbConnection.Select(@"SELECT * FROM Book");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    dataGridView1.DataSource = data;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.Select(@" DELETE FROM Book WHERE idBook=" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            data = DbConnection.Select(@"SELECT * FROM Book");
            dataGridView1.DataSource = data;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Выберите колонку поиска");
            }
            else
            {
                DataTable data = DbConnection.Select(@"SELECT * FROM Book
                WHERE " + comboBox1.Text + " LIKE '" + "%" + textBox4.Text + "%" + "';");
                dataGridView1.DataSource = data;
            }
        }
    }
}

