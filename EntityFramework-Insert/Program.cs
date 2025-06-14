using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Insert
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TRADITIONAL CRUD
            /*
            InsertRecordSample(); //C
            ReadRecordSample();   //R
            UpdateRecordSample(); //U
            DeleteRecordSample(); //D
            */

            //ENTITY FRAMEWORK
            //InsertRecordWithEF();
            //ReadRecordWithEF();
            //UpdateRecordWithEF();
            //DeleteRecordWithEF();
        }

        #region Entity Framework
        private static void DeleteRecordWithEF()
        {
            var db = new SampleDatabaseEntities();
            User user = db.Users.Find("mchibaka");
            db.Users.Remove(user);
            db.SaveChanges();
            Console.WriteLine("Delete with EF successful!");
        }

        private static void UpdateRecordWithEF()
        {
            var db = new SampleDatabaseEntities();
            User user = db.Users.First();
            user.Gender = "F";
            user.Surname = "Chirwa";
            db.SaveChanges();
            Console.WriteLine("Update with EF successful!");
        }

        private static void ReadRecordWithEF()
        {
            var db = new SampleDatabaseEntities();
            User user = db.Users.Find("mchibaka");
            Console.WriteLine("Firstname : " + user.Firstname);
            Console.WriteLine("Surname : " + user.Surname);
            Console.WriteLine("Read record with EF!");
        }

        private static void InsertRecordWithEF()
        {
            User user = new User()
            {
                Username = "mchibaka",
                DateOfBirth = DateTime.Now,
                Firstname = "Mike",
                Gender = "M",
                Password = "password123!",
                Remarks = "Test Remarks",
                Surname = "Chibaka"
            };
            var db = new SampleDatabaseEntities();
            db.Users.Add(user);
            db.SaveChanges();
            Console.WriteLine("Insert record with EF successful!");
        }
        #endregion


        #region TraditionalCRUD

        private static void DeleteRecordSample()
        {
            SqlConnection connection = new SqlConnection("Data Source=.;User Id=test;Password=test;Database=SampleDatabase;");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM users WHERE username = 'jchibaka'";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
            Console.WriteLine("Record deleted successfully");
        }

        private static void UpdateRecordSample()
        {
            SqlConnection connection = new SqlConnection("Data Source=.;User Id=test;Password=test;Database=SampleDatabase;");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE users SET surname = 'Gondwe' WHERE username = 'jchibaka'";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
            Console.WriteLine("Record updated successfully");
        }

        private static void ReadRecordSample()
        {
            SqlConnection connection = new SqlConnection("Data Source=.;User Id=test;Password=test;Database=SampleDatabase;");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT firstname, surname FROM users";
            cmd.Connection = connection;
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Console.WriteLine("Firstname : " + reader["firstname"]);
                Console.WriteLine("Surname : " + reader["surname"]);
            }
            else
            {
                Console.WriteLine("No data found!");
            }
            Console.WriteLine("Record read successfully");
        }

        private static void InsertRecordSample()
        {
            SqlConnection connection = new SqlConnection("Data Source=.;User Id=test;Password=test;Database=SampleDatabase;");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Users ([Username],[Firstname],[Surname]," +
                "[Password],[DateOfBirth],[Gender],[Remarks])" +
                "VALUES('jchibaka','John','Chibaka'," +
                "'testpassword123','1 January 1982','M'," +
                "'Test user')";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
            Console.WriteLine("Record inserted successfully");
        }
        #endregion

    }
}
