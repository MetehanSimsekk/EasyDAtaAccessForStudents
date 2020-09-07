using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SpecialHumans : Form
    {
        public SpecialHumans()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxSpecial1.Clear();
            textBoxSpecial2.Clear();
            textBoxSpecial3.Clear();
            textBoxSpecial4.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            
            String Name = textBoxSpecial1.Text;
            String Surname = textBoxSpecial2.Text;
            String City = textBoxSpecial3.Text;
            Int64 Birthday =Int64.Parse(textBoxSpecial4.Text);

           

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "SERVER = RootMeth\\SQLEXPRESS; database = ECommerce; Integrated security=True";
           
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            connection.Open();
            command.CommandText = "INSERT into HUMAN (Name,Surname,City,Birthday) values ('" + Name + "','" + Surname + "','"+City+"','"+Birthday+"')";
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Special Human Saved","Are U Sure ?",MessageBoxButtons.OK,MessageBoxIcon
                .Information);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
