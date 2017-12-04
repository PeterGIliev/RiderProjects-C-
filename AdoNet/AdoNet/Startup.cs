using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AdoNet
{
    internal class Startup
    {
        public static void Main(string[] args)
        {
            
            SqlConnection connection = new SqlConnection(
            "Server=initialdb.database.windows.net;" +
            "Database=SoftUni;" +
            "User Id=piliev333;" +
            "Password=Peter@76545759;");
            
            //First Connection
            
//            connection.Open();
//            using (connection)
//            {
//                var query = "SELECT COUNT (*) FROM Employees";
//                
//                SqlCommand command = new SqlCommand(query, connection);
//                int employeesCount = (int) command.ExecuteScalar();
//                Console.WriteLine("Emploeey count {0}", employeesCount);
//            }
            
            //Second Connection
            
            connection.Open();
            using (connection)
            {
                string query = "SELECT * FROM Employees";
                SqlCommand command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();

                using (reader)
                {
                    
                    int count = reader.FieldCount;
                   
                    while (reader.Read())
                    {
                        for (int i = 0; i < count; i++)
                        {
                            Console.Write(reader[i] + " ");
                        }
                        Console.WriteLine();
                    }

                }
            }
            
        }
    }
}