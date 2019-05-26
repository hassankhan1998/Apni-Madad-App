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
using System.IO;



namespace Project101
{
    public partial class Donate : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Donate()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Lenovo\Desktop\Apni Madad App\Project Materials\ApniMadadApp.accdb";

        }

        private void Donate_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg) | *.jpg| PNG files(*.png) | *.png | All Files(*.*) | *.* ";

            if(dlg.ShowDialog()==DialogResult.OK)
            {
                string picPath = dlg.FileName.ToString();
                image_path.Text = picPath;
                pictureBox1.ImageLocation = picPath;
            }



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "insert into Donor(ItemName,DonorName,ItemImage,ItemDescription,Address,Path) values ('" + textBox1.Text + "','" + textBox4.Text + "','"+ SavePhoto() + "','" + textBox3.Text + "','" + textBox2.Text + "','"+image_path.Text+"') ";
            command.CommandText = query;
            command.ExecuteNonQuery();
            MessageBox.Show("Item Uploaded!");
            VariableClass.a++;
            connection.Close();
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
