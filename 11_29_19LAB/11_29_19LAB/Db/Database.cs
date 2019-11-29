using _11_29_19LAB.Classes;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Helpers;

namespace _11_29_19LAB.Db
{
    public class Database
    {
        private string connectionString;
        public Database(string databaseName)
        {
            connectionString = ConfigurationManager.ConnectionStrings[databaseName].ConnectionString;
        }

        internal void AddUser(User user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand($"INSERT INTO Users(Name,Surname,Password,Email,RoleType) " +
                    $"VALUES ('{user.Name}','{user.Surname}','{user.Password}','{user.Email}','{(int)user.RoleType}')", sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        internal bool CheckUser(string email, string pass)
        {
            bool isTrue = false;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM Users WHERE Email='{email}'", sqlConnection))
                {
                    using (SqlDataReader sqlData = sqlCommand.ExecuteReader())
                    {
                        while (sqlData.Read())
                        {
                            if (sqlData["Email"].ToString()==email&&Crypto.VerifyHashedPassword(sqlData["Password"].ToString(),pass))
                            {
                                isTrue = true;
                            }
                        }

                    }
                }
            }
            return isTrue;
        }

        internal bool IsUserExist(string email)
        {
            bool isFound = false;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand($"SELECT Id FROM Users WHERE Email='{email}'", sqlConnection))
                {
                    using (SqlDataReader sqlData = sqlCommand.ExecuteReader())
                    {
                        while (sqlData.Read())
                        {
                            if (sqlData["Id"] == null)
                            {
                                isFound = false;
                            }
                            else
                            {
                                isFound = true;
                            }
                        }

                    }
                }
            }
            return isFound;
        }
    }
}
