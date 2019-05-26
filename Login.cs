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

namespace Project101
{
    public partial class Login : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Login()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Lenovo\Desktop\Apni Madad App\Project Materials\ApniMadadApp.accdb";
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Loginbutton_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            command.CommandText = "Select * From customers where Username ='" + textBox1.Text + "' and Password = '" + textBox2.Text + "' ";

            OleDbDataReader reader = command.ExecuteReader();

            int count = 0;

            while (reader.Read())
            {
                count++;

            }
            if (count == 1)
            {

                MessageBox.Show("Username And Password is Correct");

                Home2 second = new Home2();
                second.Show();
                this.Hide();

            }
            else if (count > 1)
            {
                MessageBox.Show("Not Accepted more than one");

            }
            else
            {
                MessageBox.Show("Username and Password is not correct");
            }

            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Signup second = new Signup();
            this.Hide();
            second.Show();
        }
    }
}
