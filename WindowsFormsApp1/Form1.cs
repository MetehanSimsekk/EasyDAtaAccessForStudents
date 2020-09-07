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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            String Name = textBox1.Text;
            String Surname = textBox2.Text;
            Int64 Birthday = Int64.Parse(textBox3.Text);
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = " Server = RootMeth\\SQLEXPRESS; Database = ECommerce; Integrated security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert into Kisi (Name,Surname,Birthday) values ('" + Name + "','" + Surname + "','" + Birthday + "')";
            cmd.ExecuteNonQuery();


            con.Close();

            MessageBox.Show("Data Saved", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewBook viewBook = new ViewBook();
            viewBook.Show();
            this.Hide();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SpecialHumans special = new SpecialHumans();
            special.Show();
            this.Hide();

        }

        private void SpecialDataHuman_Click(object sender, EventArgs e)
        {
            SpeacialHumanData special = new SpeacialHumanData();
            special.Show();
            this.Hide();
        }
    }
}
