using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MergeSort
{
    public class DatabaseService : IBaseService
    {
        public void ConsoleRun()
        {
            var cnn = OpenConnect();
            Console.WriteLine(cnn.State);
            var sql = @"SELECT EmployeeID, Name, Salary, ExperienceYears FROM Employee";
            var command = new SqlCommand(sql, cnn);
            var reader = command.ExecuteReader();
            DisplayEmployeeData(reader);
        }

        public static SqlConnection OpenConnect()
        {
            var connetionString = @"Data Source=CLASSYPENGUIN\LOCAL;Initial Catalog=CodingProblems;User ID=CPUser;Password=AbdUEsB*6K7bB%Yv2$H; Trusted_Connection=True;";
            var cnn = new SqlConnection(connetionString);
            cnn.Open();
            return cnn;
        }

        public static void DisplayEmployeeData(SqlDataReader reader)
        {
            var outputs = new List<string>();
            var input = "y";

            while (input.ToLower() == "y")
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var output = reader.GetValue(i);
                        outputs.Add(output.ToString());
                    }
                }

                Thread.Sleep(3000);

                Console.WriteLine($"Count: {outputs.Count}");
                Console.WriteLine("------");
                Console.WriteLine("Get employee data? Y/exit");
                input = Console.ReadLine();
            }
        }
        

        public int MyMethod(int[] arr, int v)
        {
            return 0;
        }
    }

    [TestFixture]
    public class DatabaseServiceTests
    {
        public DatabaseService service = new DatabaseService();

        //[Test]
        //public void DatabaseServiceTest1()
        //{
        //    var given = 1;
        //    var expected = 0;
        //    Assert.AreEqual(expected, service.MyMethod(given));
        //}

        //[Test]
        //public void DatabaseServiceTest2()
        //{
        //    var given = 1;
        //    var expected = 0;

        //    Assert.AreEqual(expected, service.MyMethod(given));
        //}

        //[Test]
        //public void DatabaseServiceTest3()
        //{
        //    var given = 1;
        //    var expected = 0;
        //    Assert.AreEqual(expected, service.MyMethod(given));
        //}
    }
}
