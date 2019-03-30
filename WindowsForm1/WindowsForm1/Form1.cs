using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WindowsForm1
{
    public partial class Form1 : Form
    {
        string imgPath; public String gender;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String source = @"Data Source=CE3COMP3\sqlexpress;Initial Catalog=DBstudent;Integrated Security=True;Pooling=False";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            String ins = "insert into Tbl1(fname,Middlename,Lname,gender,Date) values('"+fname.Text+"','"+ Middlename.Text+ "','" + Lname.Text + "','" +gender+"','"+ dateTimePicker1.Value.Date +"')"; 
            SqlCommand sc = new SqlCommand(ins, con);
            
            int i=sc.ExecuteNonQuery();
            if (i > -1)
            {
                MessageBox.Show("Entered into database");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Png|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imgPath = @"C:\Users\CRP\Desktop\Images\"+ openFileDialog1.SafeFileName;
               pictureBox.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void Male_CheckedChanged(object sender, EventArgs e)
        {
            
            if (Male.Checked)
            {
                gender = "Male";

            }
            else
            {
                gender = "Female";
            }
        }
    }
}
