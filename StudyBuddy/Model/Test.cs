using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace StudyBuddy.Model
{
    public class Test : Observer<Test>
    {
        public int ID {  get; set; }
        public int score {  get; set; }
        public int IDUnit {  get; set; }
        public static int count;
        public Test()
        {
            SetCount();
            
            count++;
            ID=count;
            IDUnit = 1;
            score = 0;
        }
        public Test(int IdUnit)
        {
            SetCount();
            
            count++;
            ID = count;
            IDUnit = IdUnit;
            score = 0;
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
                    using (SqlCommand countCommand = new SqlCommand("SELECT COUNT(*) FROM Test", connection))
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
                        "INSERT INTO Test (ID,score,IDUnit) VALUES (@C1, @C2,@C3)", connection))
                    {
                        // Use parameters to prevent SQL injection
                        insertCommand.Parameters.AddWithValue("@C1", ID);
                        insertCommand.Parameters.AddWithValue("@C2", score);
                        insertCommand.Parameters.AddWithValue("@C3", IDUnit);


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
            score = (int)reader["score"];
            IDUnit = (int)reader["IDUnit"];

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
                        "Select* from Test where ID=@C1", connection))
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

        public override bool GetByName(string objectName)
        {
            return false;
        }

        public override void Update(string propertyName, object newValue)
        {
            if (propertyName == "ID")
            {
                ID = (int)newValue;
            }

            if (propertyName == "IDUnit")
            {
                IDUnit = (int)newValue;
            }
            if (propertyName == "score")
            {
                score = (int)newValue;
            }
        }
    }
}
