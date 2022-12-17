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
    public partial class Available_Books : Form
    {
        public Available_Books()
        {
            InitializeComponent();
        }

        private void Available_Books_Load(object sender, EventArgs e)
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
            txtQuantity.Text = ds.Tables[0].Rows[0][7].ToString();




        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
