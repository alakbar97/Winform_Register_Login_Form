using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11_29_19LAB
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //qosul SQLConnection
            //query SqlCommand
            //response SqlDataReader
            

            string connectionString = ConfigurationManager.ConnectionStrings["myDb"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Students", sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        List<Student> students = new List<Student>();
                        while (sqlDataReader.Read())
                        {
                            students.Add(new Student
                            {
                                Id = (int)sqlDataReader["Id"],
                                Name = (string)sqlDataReader["Name"],
                                Surname = (string)sqlDataReader["Surname"],
                                Email = (string)sqlDataReader["Email"],
                                Age = (byte)sqlDataReader["Age"],
                            });
                        }
                        dataGridView1.DataSource = students;
                    }      
                }
                

               
            }

            
            
      

     
        }
    }
}
