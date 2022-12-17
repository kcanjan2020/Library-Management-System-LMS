using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Add_Students : Form
    {
        string Wanted_path;
        public Add_Students()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Exit?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK);
            {
                this.Close();

            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtStudentName.Clear();
            txtEnroll.Clear();
           // txtDeprt.Clear();
           // txtSem.Clear();
            txtCont.Clear();
            txtEmail.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtStudentName.Text != "" && txtEnroll.Text != "" && txtDeprt.Text != "" && txtSem.Text != "" && txtCont.Text != "" && txtEmail.Text != "")
            {
                string sname = txtStudentName.Text;
                String enroll = txtEnroll.Text;
                string dprt = txtDeprt.Text;
                string sem = txtSem.Text;
                Int64 contact = Int64.Parse(txtCont.Text);
                string email = txtEmail.Text;

                

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into Student_Info(Student_Name,Enrollment_No,Department,Semester,Contact,Email) values('" + sname + "','" + enroll + "','" + dprt + "','" + sem + "','" + contact + "','" + email + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStudentName.Clear();
                txtEnroll.Clear();
               // txtDeprt.Clear();
                //txtSem.Clear();
                txtCont.Clear();
                txtEmail.Clear();
               



            }
            else
            {
                MessageBox.Show("Please Field Empty Field", " Suggest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            DialogResult result = openFileDialog1.ShowDialog();
          	      
         	 openFileDialog1.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
           	 if (result == DialogResult.OK)
                	            {
                	              StudentpicBox.ImageLocation=openFileDialog1.FileName;
                StudentpicBox.SizeMode = PictureBoxSizeMode.StretchImage;


                	            }

        }

        private void txtSem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Add_Students_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
