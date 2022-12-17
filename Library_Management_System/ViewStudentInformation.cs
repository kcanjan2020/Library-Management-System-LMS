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
    public partial class ViewStudentInformation : Form
    {
        public ViewStudentInformation()
        {
            InitializeComponent();
        }

        private void ViewStudentInformation_Load(object sender, EventArgs e)
        {
            int i = 0;
            // View Details in Gridview from  Database Table
           // panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Student_info";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];





           /* DataTable dt = new DataTable();
            
            DataGridViewImageColumn imgcoln = new DataGridViewImageColumn();
            imgcoln.Width = 500;
            imgcoln.HeaderText = "Student Image";
            imgcoln.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imgcoln.Width = 100;
            dataGridView1.Columns.Add(imgcoln);
            foreach (DataRow dr in dt.Rows)
            {
                Bitmap img;
                img = new Bitmap(@"..\\.." + dr.ToString());
                dataGridView1.Rows[i].Cells[8].Value = img;
                dataGridView1.Rows[i].Height = 100;
                i = i + 1;

            }*/





        }

        private void txtSem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DATA Will Be Deleted. Confirm", "DElETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from Student_info where Student_Id=" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                txtStudentName.Clear();
                txtEnroll.Clear();
                txtDeprt.Clear();
                txtSem.Clear(); 
                txtCont.Clear();
                txtEmail.Clear();


                // After update the Data and form wil be refresh and Loaded instantly
                ViewStudentInformation_Load(this, null);
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string sname = txtStudentName.Text;
            string enroll = txtEnroll.Text;
            string dprt = txtDeprt.Text;
            string sem = txtSem.Text;
            Int64 contact = Int64.Parse(txtCont.Text);
            string email = txtEmail.Text;

            if (MessageBox.Show("DATA Will Be Updated. Confirm", "Sucess", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update Student_info set Student_Name='" + sname + "',Enrollment_No='" + enroll + "',Department='" + dprt + "',Semester='" + sem + "',Contact='" + contact + "',Email='" + email + "'where Student_Id=" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                txtStudentName.Clear();
                txtEnroll.Clear();
                txtDeprt.Clear();
                txtSem.Clear(); ;
                txtCont.Clear();
                txtEmail.Clear();


                // After update the Data and form wil be refresh and Loaded instantly
                ViewStudentInformation_Load(this, null);
            }


        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCont_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
              if(MessageBox.Show("Unsaved Data Will Be Lost","Are You Sure",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                this.Close();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtEnrolllSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtEnrolllSearch.Text !="")

            {
                // Image Change in previous image
                label8.Visible = false;
                Image img = Image.FromFile("D:/Computer Engineering Note/4th Sem/6.Project I/Library Management System/Library Management System/Library Management System/Icon/search1.gif");
                pictureBox1.Image = img;



                // Search Specific Data From GridView or Database Table
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                
                // Enroll is column of the table so we want to Search Enroll from Table Student_Info

                cmd.CommandText = "select * from Student_info where Enrollment_No LIKE '"+txtEnrolllSearch.Text+"%' ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                //Reload the previous Image
                label8.Visible = true;
                Image img = Image.FromFile("C:/Users/Anjan/Desktop/Library Management System/IconD:/Computer Engineering Note/4th Sem/6.Project I/Library Management System/Library Management System/Library Management System/Icon/search.gif");
                pictureBox1.Image = img;


                // After Search Erase the search content and Again View All DATA in Gridview

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Student_info";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];


            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        //global variable for Load the conteent into textbox from gridview 
        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                // convert dataGridview into String
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); 

            }


            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Student_info where Student_Id ='"+bid+"'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            txtStudentName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtEnroll.Text= ds.Tables[0].Rows[0][2].ToString();
            txtDeprt.Text= ds.Tables[0].Rows[0][3].ToString();
            txtSem.Text= ds.Tables[0].Rows[0][4].ToString();
            txtCont.Text= ds.Tables[0].Rows[0][5].ToString();
            txtEmail.Text= ds.Tables[0].Rows[0][6].ToString();

        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            txtEnrolllSearch.Clear();

            // panel2.Visible = false;
            //OR
            ViewStudentInformation_Load(this, null);
        }
    }
}
