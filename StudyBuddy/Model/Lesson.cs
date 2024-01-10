using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace StudyBuddy.Model
{
    public class Lesson : Observer<Lesson>
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int IDUnit {  get; set; }
        public static int count;
        public Lesson()
        {
            count++;
            ID =count;
            
            Name = "lesson";
            Content = "Here it is";
            IDUnit = 1;
        }
        public Lesson(int idUnit)
        {
            count++;
            ID = count;

            Name = "lesson";
            Content = "Here it is";
            IDUnit = 1;
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
                    using (SqlCommand countCommand = new SqlCommand("SELECT COUNT(*) FROM Lesson", connection))
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
                        "INSERT INTO Lesson (ID,names,IDUnit,Content) VALUES (@C1, @C2,@C3,@C4)", connection))
                    {
                        // Use parameters to prevent SQL injection
                        insertCommand.Parameters.AddWithValue("@C1", ID);
                        insertCommand.Parameters.AddWithValue("@C2", Name);
                        insertCommand.Parameters.AddWithValue("@C3", IDUnit);
                        insertCommand.Parameters.AddWithValue("@C4", Content);

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

        public override void CreateObjectFromReader(SqlDataReader reader)
        {
            ID = (int)reader["ID"];
            Name = (string)reader["names"];
            IDUnit = (int)reader["IDUnit"];
            Content = (string)reader["Content"];
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
                        "Select * from Lesson where ID=@C1", connection))
                    {
                        // Use parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@C1", objectId);


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

        public override bool GetByName(string objectName)
        {
            string connectionString = "Data Source=THIRASWORLD;Initial Catalog=Study Buddy;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Perform insert operation using SqlCommand
                    using (SqlCommand command = new SqlCommand(
                        "Select * from Lesson where names=@C1", connection))
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

        public override void Update(string propertyName, object newValue)
        {
            if (propertyName == "ID")
            {
                ID = (int)newValue;
            }

            if (propertyName == "Name")
            {
                Name = (string)newValue;
            }
            if (propertyName == "IDUnit")
            {
                IDUnit = (int)newValue;
            }
            if(propertyName == "Content")
            {
                Content = (string)newValue;
            }
        }
    }
}
