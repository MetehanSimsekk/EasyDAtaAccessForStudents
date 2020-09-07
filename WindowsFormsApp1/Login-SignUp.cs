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
    public partial class Login_SignUp : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public Login_SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtBoxLog.Text;
            string pass = txtBoxPassword.Text;
            con = new SqlConnection("Server = RootMeth\\SQLEXPRESS; Database = ECommerce; Integrated security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM LoginS where Name='" + txtBoxLog.Text + "' AND Password='" + txtBoxPassword.Text + "'";
            dr = cmd.ExecuteReader();
           
            if (dr.Read()) {
                MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız.");
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
             
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
                Login_SignUp login = new Login_SignUp();
                this.Close();
                con.Close();
            }
            

           
        }

        private void txtBoxLog_TextChanged(object sender, EventArgs e)
        {

            


        }

        private void txtBoxPassword_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtBoxLog_MouseClick(object sender, MouseEventArgs e)
        {
            

            if (txtBoxLog.Text == "Username")
            {
                txtBoxLog.Clear();

            }
            else {

                txtBoxLog.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp sign = new SignUp();
            sign.Show();
            this.Hide();
        }

        private void txtBoxPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtBoxPassword.Text == "Password")
            {
                txtBoxPassword.Clear();

            }
            else
            {

                txtBoxPassword.Show();
            }
        }

        private void txtBoxPassword_TextChanged_1(object sender, EventArgs e)
        {
            if(txtBoxPassword.Text !=null)
            {
                txtBoxPassword.PasswordChar= '*';
            }
        }
    }
}
