using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_Management_System
{
    public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
    

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usrtxt_MouseClick(object sender, MouseEventArgs e)
        {
            if(usrtxt.Text=="Username")
            {
                usrtxt.Clear();
            }
        }

        private void passtxt_MouseClick(object sender, MouseEventArgs e)
        {
            if(passtxt.Text=="Password")
            {
                passtxt.Clear();
                passtxt.PasswordChar ='*';
            }
        }

        private void usrtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
             con.ConnectionString= "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = "select * from Library_Preson where Username='"+ usrtxt.Text+"'and Password='"+passtxt.Text+"'";
       
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                this.Hide();
                Dashboard d = new Dashboard();
                    d.Show();
            }
            else 
           
            {
                MessageBox.Show("Username and Password Does not Match","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
           

                
               
            

        }

        private void signupbtn_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
            
        }

        private void Login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = "select * from Library_Preson where Username='" + usrtxt.Text + "'and Password='" + passtxt.Text + "'";


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                this.Hide();
                Dashboard d = new Dashboard();
                d.Show();
            }
            else

            {
                MessageBox.Show("Username and Password Does not Match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
