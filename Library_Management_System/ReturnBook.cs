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
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
           


            cmd.CommandText = "select * from Issue_Return_Book where Student_Enroll='"+txtEnrollSearch.Text+"' and Book_Returns_Date IS NULL ";
            //pu-19070293   and Book return Date is Null

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            
            if(ds.Tables[0].Rows.Count !=0)
            {
                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                MessageBox.Show("Invalid Enrollment NO or No Books Issued", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            // panel2.Visible = false;
            txtEnrollSearch.Clear();
          

        }

        string bname;
        string bdate;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //panel2.Visible = true;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value !=null)
            {
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                bdate = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            txtBookName.Text = bname;
            txtBookDate.Text = bdate;


        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (txtEnrollSearch.Text != "")
            {



                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "update Issue_Return_book set Book_Returns_Date='" + dateTimePicker1.Text + "' where Student_Enroll='" + txtEnrollSearch.Text + "' and Books_Id='" + rowid + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Return Sucessful.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ReturnBook_Load(this, null);
            }
            else
            {
                MessageBox.Show("Select Book. Maximum Number of Book Has Been ISSUED", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                

            }



        }

        private void txtEnrollSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtEnrollSearch.Text!="")
            {
                dataGridView1.DataSource = null;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnrollSearch.Clear();
            txtBookName.Clear();
            txtBookDate.Clear();
            dataGridView1.DataSource = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtEnrollSearch.Clear();
            txtBookName.Clear();
            txtBookDate.Clear();
            dataGridView1.DataSource = null;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBookDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
