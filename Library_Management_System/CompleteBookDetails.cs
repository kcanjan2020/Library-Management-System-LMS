using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class CompleteBookDetails : Form
    {
        public CompleteBookDetails()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CompleteBookDetails_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Issue_Return_Book where Book_Returns_Date is null";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            cmd.CommandText = "select * from Issue_Return_Book where Book_Returns_Date IS NOT NULL";
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            dataGridView2.DataSource = ds1.Tables[0];


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandText = "select * from Issue_Return_Book where Book_Returns_Date is null and Student_Enroll LIKE '" + textBox1.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandText = "select * from Issue_Return_Book";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandText = "select * from Issue_Return_Book where Book_Returns_Date is not null and Student_Enroll LIKE '" + textBox2.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];

            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandText = "select * from Issue_Return_Book";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
            }
        }
    }
}
