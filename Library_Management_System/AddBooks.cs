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
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtIsbn.Text != "" && txtBookName.Text != "" && txtAuthor.Text != "" && txtPublication.Text != "" && txtPrice.Text != "")
                {
                    string isbn = txtIsbn.Text;
                    string bname = txtBookName.Text;
                    string bauthor = txtAuthor.Text;
                    string publication = txtPublication.Text;
                    string pdate = dateTimePicker1.Text;
                    Int64 price = Int64.Parse(txtPrice.Text);

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "insert into AddBooks(ISBN_No,Book_Name,Author_Name,Books_Publication,Purchase_Date,Books_Price)values('" + isbn + "','" + bname + "','" + bauthor + "','" + publication + "','" + pdate + "','" + price + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIsbn.Clear();
                    txtBookName.Clear();
                    txtAuthor.Clear();
                    txtPublication.Clear();
                    txtPrice.Clear();


                }
                else
                {
                    MessageBox.Show("Empty Field Not Allowed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid ISBN No", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
           

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("This Will DELETE Your Unsaved DATA","Are You Sure ?",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtPublication_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {

        }

        private void l3_Click(object sender, EventArgs e)
        {

        }

        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {

        }

        private void l4_Click(object sender, EventArgs e)
        {

        }

        private void l2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void l5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddBooks_Load(object sender, EventArgs e)
        {

        }
    }
}
