using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Insert
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TRADITIONAL CRUD
            InsertRecordSample(); //C
            ReadRecordSample();   //R
            UpdateRecordSample(); //U
            DeleteRecordSample(); //D
            
            //ENTITY FRAMEWORK


        }

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
