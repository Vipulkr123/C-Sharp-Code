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
using static System.Net.Mime.MediaTypeNames;

namespace AdoConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetStudentCont();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string ConStr = @"Data Source=SF-CPU-015\SQLEXPRESS;Initial Catalog=mydb;User ID=Vipul;Password=123";
            SqlConnection con = new SqlConnection(ConStr);
            try
            {
                string SqlQuery = "SELECT id as Id, student_name as Name FROM [mydb].[dbo].[students];";
                SqlCommand sqlcmd = new SqlCommand(SqlQuery, con);

                // Connection Open
                con.Open();
                //SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);
                //DataSet ds = new DataSet();
                //adapter.Fill(ds);
                //dataGridView.DataSource = ds.Tables[0];
                //dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;  

                SqlDataReader rdr = sqlcmd.ExecuteReader();
                while (rdr.Read())
                {
                    textId.Text = rdr.GetInt32(0).ToString();
                    textName.Text = rdr.GetString(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }    
        }

        private void GetStudentCont()
        {
            string ConStr = @"Data Source=SF-CPU-015\SQLEXPRESS;Initial Catalog=mydb;User ID=Vipul;Password=123";
            using (SqlConnection sqlConnection = new SqlConnection(ConStr))
            {
                try
                {
                    sqlConnection.Open();
                    string GetStudentCount = "SELECT COUNT(id) AS 'TotalStudent' FROM [mydb].[dbo].[students]";
                    SqlCommand sqlCommand = new SqlCommand(GetStudentCount, sqlConnection);
                    int StudentCount = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    if (StudentCount > 0)
                    {
                        lblTotalStudents.Text = "Total Number of Students are " + StudentCount;
                    }
                    else
                    {
                        lblTotalStudents.Text = "No student Available ";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string ConStr = @"Data Source=SF-CPU-015\SQLEXPRESS;Initial Catalog=mydb;User ID=Vipul;Password=123";
            using (SqlConnection sqlConnection = new SqlConnection(ConStr))
            {
                try
                {
                    sqlConnection.Open();
                    string AddStudent = $"INSERT INTO students(id,student_name) VALUES ({textId.Text.ToString()}, \'{textName.Text}\')";
                    SqlCommand sqlCommand = new SqlCommand(AddStudent, sqlConnection);
                    int RowAffected = sqlCommand.ExecuteNonQuery();
                    if (RowAffected > 0)
                    {
                        MessageBox.Show("Record Inserted");
                    }
                    else
                    {
                        MessageBox.Show("Record Not Inserted! try Again");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string ConStr = @"Data Source=SF-CPU-015\SQLEXPRESS;Initial Catalog=mydb;User ID=Vipul;Password=123";
            using (SqlConnection sqlConnection = new SqlConnection(ConStr))
            {
                try
                {
                    sqlConnection.Open();
                    string DltStudent = $"DELETE FROM students WHERE id = {textId.Text}";
                    SqlCommand sqlCommand = new SqlCommand(DltStudent, sqlConnection);
                    int RowAffected = sqlCommand.ExecuteNonQuery();
                    if (RowAffected > 0)
                    {
                        MessageBox.Show("Record Deleted");
                    }
                    else
                    {
                        MessageBox.Show("Record Not Deleted! try Again");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textId.Text = "Enter Id";
            textId.ForeColor = Color.Gray;
            textName.Text = "Enter Name";
            textName.ForeColor = Color.Gray;
        }

        private void textId_Enter(object sender, EventArgs e)
        {
            if (textId.Text == "Enter Id")
            {
                textId.Text = String.Empty;
                textId.ForeColor = Color.Black;
            }
        }

        private void textId_Leave(object sender, EventArgs e)
        {
            textId.Text = textId.Text;
            textId.ForeColor = Color.Black;
        }

        private void textName_Enter(object sender, EventArgs e)
        {
            if (textName.Text == "Enter Name")
            {
                textName.Text = String.Empty;
                textName.ForeColor = Color.Black;
            }

        }

        private void textName_Leave(object sender, EventArgs e)
        {
            textName.Text = textName.Text;
            textName.ForeColor = Color.Black;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string ConStr = @"Data Source=SF-CPU-015\SQLEXPRESS;Initial Catalog=mydb;User ID=Vipul;Password=123";
            using (SqlConnection sqlConnection = new SqlConnection(ConStr))
            {
                try
                {
                    sqlConnection.Open();
                    string UpdateStudent = $"Update students SET student_name = \'{textName.Text}\' WHERE id = {textId.Text}";
                    SqlCommand sqlCommand = new SqlCommand(UpdateStudent, sqlConnection);
                    int RowAffected = sqlCommand.ExecuteNonQuery();
                    if (RowAffected > 0)
                    {
                        MessageBox.Show("Record Updated");
                    }
                    else
                    {
                        MessageBox.Show("Record Not Updated! try Again");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
