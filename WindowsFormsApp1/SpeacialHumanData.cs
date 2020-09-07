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
    public partial class SpeacialHumanData : Form
    {
        public SpeacialHumanData()
        {
            InitializeComponent();
        }

        private void SpeacialHumanData_Load(object sender, EventArgs e)
        {
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server = RootMeth\\SQLEXPRESS; Database = ECommerce; Integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * From HUMAN";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView2.DataSource = ds.Tables[0];

        }
        int ID;
        Int64 rowId;
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                ID = int.Parse(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server = RootMeth\\SQLEXPRESS; Database = ECommerce; Integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * From HUMAN where ID='" + ID + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowId = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            textBoxData1.Text = ds.Tables[0].Rows[0][1].ToString();
            textBoxData2.Text = ds.Tables[0].Rows[0][2].ToString();
            textBoxData3.Text = ds.Tables[0].Rows[0][3].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Name = textBoxData1.Text;
            String Surname = textBoxData2.Text;
            String City = textBoxData3.Text;


            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server = RootMeth\\SQLEXPRESS; Database = ECommerce; Integrated security = True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update HUMAN set Name='" +Name+ "',Surname='"+Surname+"',City='"+City+"' where ID='"+rowId+"' ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            MessageBox.Show("Updated", "U Sure ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server = RootMeth\\SQLEXPRESS; Database = ECommerce; Integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from HUMAN where ID='"+rowId+"'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            MessageBox.Show("Deleted", "U Sure ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
