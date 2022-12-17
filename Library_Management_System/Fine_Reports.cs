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
    public partial class Fine_Reports : Form
    {
        DateTime issuedate;
        DateTime returndate;
        DateTime datediff;

        public Fine_Reports()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ANJAN\\SQLEXPRESS; database=Library_Management_System(LMS);Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;



            cmd.CommandText = "select * from Issue_Return_Book where Student_Enroll='" + txtEnrollSearch.Text + "' and Book_Returns_Date IS NULL ";
            //pu-19070293   and Book return Date is Null

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                MessageBox.Show("Invalid Enrollment NO or No Books Issued", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtEnrollSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtEnrollSearch.Text != "")
            {
                dataGridView1.DataSource = null;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnrollSearch.Clear();
            txtBookName.Clear();
            txtidate.Clear();
            dataGridView1.DataSource = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        string bname;
        string idate;
        string enroll;
        string sname;
        string deprt;
        string sem;
        string email;
        string contact;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //panel2.Visible = true;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                enroll = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                sname = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                deprt = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                sem = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                email = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                contact = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                bname = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                idate = (dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
            }
            txtenroll.Text = enroll;
            txtsname.Text = sname;
            txtdept.Text = deprt;
            txtsem.Text = sem;
            txtemail.Text = email;
            txtcontact.Text = contact;

            txtBookName.Text = bname;
            txtidate.Text = idate;
            
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textfine_TextChanged(object sender, EventArgs e)
        {

        }

        private void textfineday_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtBookDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            try
            {
                System.Drawing.Font fnstring = new System.Drawing.Font("Arial",12,FontStyle.Regular);
                e.Graphics.DrawString(richTextBox1.Text, fnstring, Brushes.Black, 20, 20);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Library fine", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                printPreviewDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Library fine", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnreceipt_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.AppendText("\t" + "\t" + "\t"+ label15.Text +"\n");

            richTextBox1.AppendText(lblsdetails.Text + "\t" + "\t"+ "\t" + "\t" + "\t" + lblfinedetails.Text +"\n" +"\n");
            richTextBox1.AppendText(lblenroll.Text + "\t" + txtenroll.Text +"\t"+"\t"+ "\t"+ "\t"+ lblfday.Text+"\t"+ "\t" + textfineday.Text +"\n" + "\n");
            richTextBox1.AppendText(lblsname.Text + "\t" + txtsname.Text+ "\t" + "\t" + "\t" +  lblpdfine.Text + "\t"+  textperfin.Text+ "\n" + "\n");
            richTextBox1.AppendText(lbldept.Text+ "\t" + txtdept.Text + "\t" + "\t" + "\t" + "\t" + lbltfine.Text + "\t" + "\t" + textfine.Text  + "\n" + "\n");
            richTextBox1.AppendText(lblsem.Text + "\t" + txtsem.Text + "\n" + "\n");
            richTextBox1.AppendText(lblemail.Text + "\t" +txtemail.Text + "\n" + "\n");
            richTextBox1.AppendText(lblcontact.Text + "\t" + txtemail.Text + "\n" + "\n");
            richTextBox1.AppendText(lblbname.Text + "\t" + txtBookName.Text + "\n" + "\n");
            richTextBox1.AppendText(lblidate.Text + "\t" + txtidate.Text+ "\n" + "\n");
            richTextBox1.AppendText(lblrdate.Text+ "\t" +redate.Value.ToString() + "\n" + "\n");




        }

        private void btntotal_Click(object sender, EventArgs e)

        {
            try
            { 
            //time different betwent two time 
            // string d1 = "05/06/2021";
            string issdate = Convert.ToString(txtidate.Text);
            DateTime issuedate= Convert.ToDateTime(issdate);

            // string d2 = "03/29/2021";
            string d2 =redate.Value.ToString();

            DateTime returndate =Convert.ToDateTime(d2);

            System.TimeSpan datediff = returndate.Subtract(issuedate);
                txttotalday.Text = datediff.Days.ToString();
                int temp = 15;
                int fine = 0;
               int  perday_fine = 2;
                int total;
             
                while (datediff.Days > temp)
                {


                    fine = fine + 1;
                    temp++;
                }
                textfineday.Text =Convert.ToString(fine);
                textperfin.Text = Convert.ToString(perday_fine);
                total = fine * perday_fine;
                textfine.Text = Convert.ToString(total);

                //texperfin.Text = perdayfin;
                //textfine.Text = tfine;



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Library fine", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
