using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace StudyBuddy.Model
{
    public class Person : Observer<Person>
    {
        public int Id { get; set; }
  
        public string name { get; set; }
        public string password { get; set; }
        public int strikes { get; set; }
        public static int count;
        public Observer<Person> observer { get; set; }
        public Person() {
            SetCount();
            name = "k";
            password = "m";
            
            strikes = 0;
            count++;
            Id = count;
            
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
                    using (SqlCommand countCommand = new SqlCommand("SELECT COUNT(*) FROM Persons", connection))
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
        public void AddPersonToDatabase()
        {
            string connectionString = "Data Source=THIRASWORLD;Initial Catalog=Study Buddy;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Perform insert operation using SqlCommand
                    using (SqlCommand insertCommand = new SqlCommand(
                        "INSERT INTO Persons (ID,names,passwords,strikes) VALUES (@C1, @C2,@C3,@C4)", connection))
                    {
                        // Use parameters to prevent SQL injection
                        insertCommand.Parameters.AddWithValue("@C1", Id);
                        insertCommand.Parameters.AddWithValue("@C2", name);
                        insertCommand.Parameters.AddWithValue("@C3", password);
                        insertCommand.Parameters.AddWithValue("@C4", strikes);

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


        public override bool GetById(int objectId)
        {
            string connectionString = "Data Source=THIRASWORLD;Initial Catalog=Study Buddy;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Perform insert operation using SqlCommand
                    using (SqlCommand command = new SqlCommand(
                        "Select* from Persons where ID=@C1", connection))
                    {
                        // Use parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@C1", objectId);


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

        public override bool GetByName(string username)
        {
            string connectionString = "Data Source=THIRASWORLD;Initial Catalog=Study Buddy;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Perform insert operation using SqlCommand
                    using (SqlCommand command = new SqlCommand(
                        "Select names,passwords from Persons where names=@C1", connection))
                    {
                        // Use parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@C1", username);


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

        public override void CreateNew()
        {
            string connectionString = "Data Source=THIRASWORLD;Initial Catalog=Study Buddy;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Perform insert operation using SqlCommand
                    using (SqlCommand insertCommand = new SqlCommand(
                        "INSERT INTO Persons (ID,names,passwords,strikes) VALUES (@C1, @C2,@C3,@C4)", connection))
                    {
                        // Use parameters to prevent SQL injection
                        insertCommand.Parameters.AddWithValue("@C1", Id);
                        insertCommand.Parameters.AddWithValue("@C2", name);
                        insertCommand.Parameters.AddWithValue("@C3", password);
                        insertCommand.Parameters.AddWithValue("@C4", strikes);

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
        public  bool UserLogIn(string name, string password)
        {
            try
            {
                string connectionString = "Data Source=THIRASWORLD;Initial Catalog=Study Buddy;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Login query
                    string loginQuery = "SELECT * FROM Persons WHERE names = @name AND passwords = @password";

                    using (SqlCommand command = new SqlCommand(loginQuery, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("LogIn done");
                                CreateObjectFromReader(reader);
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Failure");
                                return false;
                            }
                        }
                    }
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }

        }
    
        public void AddStrike(string name)
        {
            try

            {
                strikes++;
                string connectionString = "Data Source=THIRASWORLD;Initial Catalog=Study Buddy;Integrated Security=True";
                // Establish database connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Write SQL Update Command
                    string updateCommand = "UPDATE Persons SET strikes = @C2 WHERE names=@C1";

                    // Execute SQL Command
                    using (SqlCommand command = new SqlCommand(updateCommand, connection))
                    {
                        // Replace parameters with actual values
                        command.Parameters.AddWithValue("@C2", strikes);
                        command.Parameters.AddWithValue("@C1", name);

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check the number of rows affected
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Column updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("No rows updated. Verify your condition.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public override void CreateObjectFromReader(SqlDataReader reader)
        {
            Id = (int)reader["ID"];
            name= (string)reader["names"];
            password= (string)reader["passwords"];
           
            
        }

        public override void Update(string propertyName, object newValue)
        {
            if (propertyName == "ID")
            {
                Id = (int)newValue;
            }

            if (propertyName == "name")
            {
                name = (string)newValue;
            }
            if (propertyName == "password")
            {
                password = (string)newValue;
            }
            if (propertyName == "strikes")
            {
                strikes = (int)newValue;
            }
        }
    }
    }

