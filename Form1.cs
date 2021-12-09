using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace SweetMemory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //connect the sqlserver in this section
        SqlConnection con = new SqlConnection("Data Source=RAKIBUL-ERP;Initial Catalog=sweetMemory;Integrated Security=True");
        public int sweetMemory;

        private void button1_Click(object sender, EventArgs e)
        {
            //pass the date into memory table
            SqlCommand cmd = new SqlCommand("INSERT INTO memory (date,text) VALUES('" + dateTimePicker1.Value.ToString("yyyy-MM-dd")+"','"+ richTextBox1.Text+ "')",con);
            cmd.CommandType = CommandType.Text;
         
            //Add with values for form to databae table and we pass the data 
           
            //open and close the 
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //When we save the momory than show the message above the form
            MessageBox.Show("Save Youe SweetMemory", "save", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            //clear the text box
            richTextBox1.Text = "";

        }

        private void richTextBox2_Click(object sender, EventArgs e)
        {

            if(richTextBox2.Text == "See your memory...")
            {
                richTextBox2.Text = "";
            }
           
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text == "Write your memory...")
            {
                richTextBox1.Text = "";
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //search the date wise memory 
            SqlCommand cmd = new SqlCommand("select text from memory where date = '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") +"'and userID = 1",con);
            DataTable dt = new DataTable();
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            richTextBox2.Text =(string) dt.Rows[0]["text"];
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();
            //When we save the momory than show the message above the form
            MessageBox.Show("Show the memory", "SEE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
        }
    }
}
