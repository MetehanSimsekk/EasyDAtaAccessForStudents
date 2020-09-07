using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;

namespace WindowsFormsApp1
{
    
    public partial class ViewBook : Form
    {
       
        public ViewBook()
        {
            InitializeComponent();

        }

        private void ViewBook_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server = RootMeth\\SQLEXPRESS; Database = ECommerce; Integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from Kisi";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            dataGridView1.DataSource = ds.Tables[0];

            

        }
        int ID;
        Int64 rowId;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
           
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server = RootMeth\\SQLEXPRESS; Database = ECommerce; Integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from Kisi where ID="+ID+"";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);           

            rowId = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            textBName.Text = ds.Tables[0].Rows[0][1].ToString();
            textBSurname.Text = ds.Tables[0].Rows[0][2].ToString();
            textBirthday.Text = ds.Tables[0].Rows[0][3].ToString();

            
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Data Updated Confirm ?","Succes",MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            String Name = textBName.Text;
            String Surname = textBSurname.Text;
            String Birthday = textBirthday.Text;



            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server = RootMeth\\SQLEXPRESS; Database = ECommerce; Integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "update Kisi set Name='"+Name+"',Surname='"+Surname+"',Birthday='"+Birthday+"' where ID='"+rowId+"' ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server =  RootMeth\\SQLEXPRESS; Database = ECommerce; Integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            
            cmd.CommandText = " delete From Kisi where ID = '"+rowId+"'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
           
        }
    }
}
