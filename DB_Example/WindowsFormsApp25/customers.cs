using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp25
{
    public partial class customers : Form
    {
        public customers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string fami = textBox2.Text;
                string tele = textBox3.Text;
                string addr = textBox4.Text;
                string query = "INSERT INTO customers (name,family,tel,address)" +
                    "VALUES ('" + name + "','" + fami + "','" + tele + "','" + addr + "')";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gheir\source\repos\WindowsFormsApp25\WindowsFormsApp25\Database1.mdf;Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Insert OK");
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                    refresh();
                }
                else
                    MessageBox.Show("Nashod");
                sqlConnection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void customers_Load(object sender, EventArgs e)
        {
            button4.Enabled = false;
            refresh();
        }
        void refresh()
        {
            try
            {
                comboBox1.Items.Clear();
                string query = "SELECT * FROM customers";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gheir\source\repos\WindowsFormsApp25\WindowsFormsApp25\Database1.mdf;Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["id"] + ":" + dr["name"] + " " + dr["family"]);
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string id = comboBox1.SelectedItem.ToString();
            int index = id.IndexOf(":");
            id = id.Substring(0, index);
            try
            {
                string query = "DELETE FROM customers WHERE id='" + id + "'";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gheir\source\repos\WindowsFormsApp25\WindowsFormsApp25\Database1.mdf;Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("DELETE OK");
                    refresh();
                }
                else
                    MessageBox.Show("Nashod");
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        string id_1;
        private void button3_Click(object sender, EventArgs e)
        {
            
            try
            {
                string id = comboBox1.SelectedItem.ToString();
                int index = id.IndexOf(":");
                id = id.Substring(0, index);
                id_1 = id;
                comboBox1.Items.Clear();
                string query = "SELECT * FROM customers WHERE id='" + id + "'";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gheir\source\repos\WindowsFormsApp25\WindowsFormsApp25\Database1.mdf;Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                var dr = command.ExecuteReader();
                dr.Read();
                textBox1.Text = dr["name"].ToString();
                textBox2.Text = dr["family"].ToString();
                textBox3.Text = dr["tel"].ToString();
                textBox4.Text = dr["address"].ToString();
                button4.Enabled = true;
                button1.Enabled = false;
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string fami = textBox2.Text;
                string tele = textBox3.Text;
                string addr = textBox4.Text;
                string query = "UPDATE customers SET name='" + name + "',family='" + fami + "'," +
                    "tel='" + tele + "',address='" + addr + "' WHERE id='" + id_1 + "'";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gheir\source\repos\WindowsFormsApp25\WindowsFormsApp25\Database1.mdf;Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Update OK");
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                    refresh();
                    button1.Enabled = true;
                    button4.Enabled = false;
                }
                else
                    MessageBox.Show("Nashod");
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
