using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int studentID;
        String studentName;
        int age;
        double gpa;
        String Address;
        string connetionString;
        SqlConnection connection;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Star the connection
            connetionString = getConnectionString();
            connection = new SqlConnection(connetionString);
            connection.Open();
            
            // MessageBox.Show("Connection Open  !");
            
            studentName = TxtName.Text;
            studentID = Int32.Parse(TxtID.Text);
            age= Int32.Parse(txtAge.Text);
            gpa = Convert.ToDouble(txtGPA.Text);
            Address = txtAddress.Text;

            // insert query
            string query = "INSERT INTO dbo.student values (@studentID, @studentName, @age, @gpa, @Address)";

            SqlCommand myCommand = new SqlCommand(query, connection);
            myCommand.Parameters.AddWithValue("@studentName", studentName);
            myCommand.Parameters.AddWithValue("@studentID", studentID);
            myCommand.Parameters.AddWithValue("@age",age);
            myCommand.Parameters.AddWithValue("@gpa",gpa);
            myCommand.Parameters.AddWithValue("@Address", Address);

            // execute insert query
            myCommand.ExecuteNonQuery();

            // Close the connection
            connection.Close();

            TxtName.Text="";
            TxtID.Text = "";
            txtAge.Text = "";
            txtGPA.Text = "";
            Address = txtAddress.Text;

            // Getting data to table
            loadData();
        }

        public void loadData()
        {
            // Star the connection
            connetionString = getConnectionString();
            connection = new SqlConnection(connetionString);
            connection.Open();

            // Select all data query
            String sql = "select * From dbo.student";
            
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, connection);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            // adding data to table
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dataGridView1.DataSource = table;

            // dataGridView1.d;

            // Close the connection
            connection.Close();
        }

        // Get the databse connection
        public string getConnectionString()
        {
            string conString;
         
            conString = @"Data Source=PARADOCX-PC;Initial Catalog=Student;Integrated Security=True";

            return conString;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {          
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

// Database Creation Query
// Create Database as Student

// Create table
// CREATE TABLE Student(
// ID INT PRIMARY KEY,
// Name VARCHAR (50),
// Age INT,
// GPA FLOAT,
// Address VARCHAR(50));
