using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Media;

namespace Project101
{
    public partial class Signup : Form
    {
        private OleDbConnection connection1 = new OleDbConnection();
        public ErrorProvider errorProvider1 = new ErrorProvider();
        public Signup()
        {
            InitializeComponent();
            connection1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Lenovo\Desktop\Apni Madad App\Project Materials\ApniMadadApp.accdb";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void Register_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "This Field Must Be Filled");
            }
            else if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "This Field Must Be Filled");
            }
            else if (textBox3.Text == "")
            {
                errorProvider1.SetError(textBox3, "This Field Must Be Filled");
            }
            else if (textBox7.Text == "")
            {
                errorProvider1.SetError(textBox4, "This Field Must Be Filled");
            }
            else if (textBox7.TextLength != 13)
            {
                errorProvider1.SetError(textBox4, "CNIC MUST BE 13 DIGItS");
            }

            else if (textBox4.Text == "")
            {
                errorProvider1.SetError(textBox4, "This Field Must Be Filled");
            }

            //PASSWORD VERIFICATION NEEDS TO BE IMPLEMENTED TOO//

            else
            {
                {

                    connection1.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection1;
                    string query = "insert into customers(Username,FirstName,LastName,Type,ContactNumber,Email,[PASSWORD],CNIC) values ('" + textBox8.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedItem + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "') ";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    MessageBox.Show("Congratulations!");
                    connection1.Close();
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}