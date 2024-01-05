using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudyBuddy.Model
{
    public class Unit : Observer<Unit>
    {
        public int Id {  get; set; }
        public string name { get; set; }
        public int IDUser { get; set; }
        public static int count;
        public Unit() {
            Id = 1;
            name = "main";
            IDUser = 1;
        }
        public void SetCount()
        {
            string connectionString = "Data Source=THIRASWORLD;Initial Catalog=Study Buddy;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Perform insert operation using SqlCommand
                    using (SqlCommand countCommand = new SqlCommand("SELECT COUNT(*) FROM Unit", connection))
                    {
                        int numberOfEntries = (int)countCommand.ExecuteScalar();

                        count = numberOfEntries;
                    }

                    // Perform select operation to verify the insertion

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail");

                }

            }
        }
        public void CreateNew()
        {
            string connectionString = "Data Source=THIRASWORLD;Initial Catalog=Study Buddy;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Perform insert operation using SqlCommand
                    using (SqlCommand insertCommand = new SqlCommand(
                        "INSERT INTO Unit (ID,Name,IDUser) VALUES (@C1, @C2,@C3)", connection))
                    {
                        // Use parameters to prevent SQL injection
                        insertCommand.Parameters.AddWithValue("@C1", Id);
                        insertCommand.Parameters.AddWithValue("@C2", name);
                        insertCommand.Parameters.AddWithValue("@C3", IDUser);
                       

                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        MessageBox.Show("Cool");
                    }

                    // Perform select operation to verify the insertion

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail");
                }
            }
        }

        public void CreateObjectFromReader(SqlDataReader reader)
        {
            Id = (int)reader["ID"];
            name = (string)reader["Name"];
            IDUser = (int)reader["IDUser"];

        }

        public bool GetById(int objectIdUser)
        {
            string connectionString = "Data Source=THIRASWORLD;Initial Catalog=Study Buddy;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Perform insert operation using SqlCommand
                    using (SqlCommand command = new SqlCommand(
                        "Select* from Unit where IDUser=@C1", connection))
                    {
                        // Use parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@C1", objectIdUser);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {
                                CreateObjectFromReader(reader);
                            }
                            return reader.Read();

                        }


                    }

                    // Perform select operation to verify the insertion

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail");
                    return false;
                }

            }
        }

        public bool GetByName(string objectName)
        {
            string connectionString = "Data Source=THIRASWORLD;Initial Catalog=Study Buddy;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Perform insert operation using SqlCommand
                    using (SqlCommand command = new SqlCommand(
                        "Select * from Unit where Name=@C1", connection))
                    {
                        // Use parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@C1", objectName);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            return reader.Read();

                        }


                    }

                    // Perform select operation to verify the insertion

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail");
                    return false;
                }

            }
        }

        public void Update(Unit obj)
        {
            if (Id == obj.Id)
            {
                name = obj.name;
                IDUser=obj.IDUser;
            }
        }
    }
}
