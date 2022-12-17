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
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            // Load Data in comboBox from DataBase

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand("select Book_Name from AddBooks",con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read())
            {
                for(int i= 0;i<sdr.FieldCount;i++)
                {
                    comboBoxBook.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();
        }

        int count; //global variable for count how many book has been issued
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            if(txtEnrollSearch.Text !="")
            {
                string edi = txtEnrollSearch.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                //load data into textBox from database
                cmd.CommandText = "select * from Student_Info where Enrollment_No='"+edi+"'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);



                //.............................................................................
                //Code to count How many Book has been issued on this Enrollment No
                cmd.CommandText = "select count(Student_Enroll) from Issue_Return_Book where Student_Enroll='" + edi + "' and Book_Returns_Date is null ";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);

                count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                //.............................................................................



                //load data into textBox while Click the Button
                if (ds.Tables[0].Rows.Count !=0)
                {
                    txtStudentName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtDepartment.Text= ds.Tables[0].Rows[0][3].ToString();
                    txtSemester.Text= ds.Tables[0].Rows[0][4].ToString();
                    txtContact.Text= ds.Tables[0].Rows[0][5].ToString();
                    txtEmail.Text= ds.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    txtStudentName.Clear();
                    txtDepartment.Clear();
                    txtSemester.Clear();
                    txtContact.Clear();
                    txtEmail.Clear();
                    MessageBox.Show("Invalid Enrollment No","Error" ,MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }



        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if(txtStudentName.Text !="")
            {
                //check 3 only can be issued
                if(comboBoxBook.SelectedIndex !=-1 && count <=2)
                {
                    string enroll = txtEnrollSearch.Text;
                    string sname = txtStudentName.Text;
                    string dprt = txtDepartment.Text;
                    string sem = txtSemester.Text;
                    string contact = txtContact.Text;
                    string email = txtEmail.Text;
                    string bname = comboBoxBook.Text;
                    string issubookdate = dateTimePicker.Text;

                    string edi = txtEnrollSearch.Text;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();


                    cmd.CommandText = "insert into Issue_Return_Book(Student_Enroll,Student_Name,Student_Department,Student_Sem,Student_Contact,Student_Email,Book_Name,Book_Issue_Date ) values('"+enroll+ "','"+sname+ "','"+dprt+ "','"+sem+ "','"+contact+ "','"+email+ "','"+bname+ "','"+issubookdate+"')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    
                    MessageBox.Show("Book Issued.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStudentName.Clear();
                    txtDepartment.Clear();
                    txtSemester.Clear();
                    txtContact.Clear();
                    txtEmail.Clear();
                    txtEnrollSearch.Clear();
                    IssueBooks_Load(this, null);
                    
                    


                }
                else
                {
                    MessageBox.Show("Select Book. Maximum Number of Book Has Been ISSUED", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IssueBooks_Load(this, null);

                }

            }
        else
            {
                MessageBox.Show("Enter Valid Enrollment No","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
              
            }
        }

        private void txtEnrollSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtEnrollSearch.Text =="")
            {
                txtStudentName.Clear();
                txtDepartment.Clear();
                txtSemester.Clear();
                txtContact.Clear();
                txtEmail.Clear();
                
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnrollSearch.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure ?","Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
                {
                this.Close();
            }
        }

        private void comboBoxBook_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
