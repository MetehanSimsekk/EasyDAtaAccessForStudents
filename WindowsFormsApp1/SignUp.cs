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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login_SignUp login = new Login_SignUp();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Name = textS1.Text;
            String Password = textS2.Text;
            String Email = textS3.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "SERVER = RootMeth\\SQLEXPRESS; database = ECommerce; Integrated security = True";
            SqlCommand command = new SqlCommand();
            con.Open();
            command.Connection = con;
            command.CommandText = "Insert into LoginS (Name,Password,Email) values ('"+Name+"','"+Password+"','"+Email+"')";
            command.ExecuteNonQuery();
            con.Close();

            if (textS3.Text == string.Empty)
            {
                MessageBox.Show("Mail Adresinizi Giriniz!!!");
                return;
            }
            
            else
            {
                // Program logic...
            }

        }

        private void textS3_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void textS2_TextChanged(object sender, EventArgs e)
        {
            if (textS2.Text != null)
            {
                textS2.PasswordChar = '*';
            }
        }

        private void textS3_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (textS3.Text.Length > 0 && textS3.Text.Trim().Length != 0)
            {
                if (!rEmail.IsMatch(textS3.Text.Trim()))
                {
                    MessageBox.Show("@",".com");
                    textS3.SelectAll();
                    e.Cancel = true;
                }
            }
        }
    }
    
    }

