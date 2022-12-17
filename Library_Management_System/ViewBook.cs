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
   public partial class ViewBook : Form
    {
        public ViewBook()
       {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
           
        {
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            if(txtSearch.Text !="")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandText = "select * from AddBooks where Book_Name LIKE '" + txtSearch.Text+"%'";
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

                cmd.CommandText = "select * from AddBooks";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void ViewBook_Load(object sender, EventArgs e)
        {

            // panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            cmd.CommandText = "select * from AddBooks";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }
        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

           
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());


            }
           
            //panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            cmd.CommandText = "select * from AddBooks where Books_id=" + bid + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            //specific row update 
            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtIs.Text = ds.Tables[0].Rows[0][1].ToString();
            txtBookName.Text = ds.Tables[0].Rows[0][2].ToString();
            txtAuthor.Text = ds.Tables[0].Rows[0][3].ToString();
            txtPublication.Text = ds.Tables[0].Rows[0][4].ToString();
            txtPdate.Text = ds.Tables[0].Rows[0][5].ToString();
            txtPrice.Text = ds.Tables[0].Rows[0][6].ToString();



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Select Valid Cell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            //panel2.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will Be Updated. Confirm ?", "Sucess", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                string isbn = txtIs.Text;
                string bname = txtBookName.Text;
                string bauthor = txtAuthor.Text;
                string publication = txtPublication.Text;
                string pdate = txtPdate.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
               

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandText = "update AddBooks set ISBN_No='" + isbn+ "',Book_Name='" + bname + "',Author_Name='" + bauthor + "',Books_Publication='" + publication + "',Purchase_Date='" + pdate + "',Books_Price='" + price + "' where Books_Id=" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //After Uptate the Data field will be refresh

                txtIs.Clear();
                txtBookName.Clear();
                txtAuthor.Clear();
                txtPublication.Clear();
                txtPdate.Clear();
                txtPrice.Clear();
               
                //OR Refresh the form instantly
                ViewBook_Load(this, null);
                
            }
           
            
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            txtSearch.Clear();
            //panel2.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will Be Deletedd. Confirm ?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {




                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandText = "delete from AddBooks where Books_Id='" + rowid + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                txtIs.Clear();
                txtBookName.Clear();
                txtAuthor.Clear();
                txtPublication.Clear();
                txtPdate.Clear();
                txtPrice.Clear();
               
                //OR
                ViewBook_Load(this, null);
            }
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
       