using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MergeSort
{
    public class AnonLamdaFuncService : IBaseService
    {
        public void ConsoleRun()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee() { ID = 101, Name = "Mary", Salary = 5000, Experience = 5 });
            employees.Add(new Employee() { ID = 102, Name = "John", Salary = 6000, Experience = 6 });
            employees.Add(new Employee() { ID = 103, Name = "Todd", Salary = 3000, Experience = 3 });
            employees.Add(new Employee() { ID = 104, Name = "Mike", Salary = 4000, Experience = 4 });

            //   var emp102 = employees.Find(emp => emp.ID == 102);

            Predicate<Employee> empPredicate = new Predicate<Employee>(FindEmployee);

            var emp102 = employees.Find(emp => FindEmployee(emp));

            var count = employees.Count(x => x.Name.StartsWith('M'));

            //Console.WriteLine(count);

            //Console.WriteLine($"Employee 102: {emp102.Name}");

            //Console.WriteLine($"Employee 104: {employees.Find(delegate(Employee emp) { return emp.ID == 104; })?.Name}");

            //Console.WriteLine($"Employee 103: {employees.Find(emp => emp.ID == 103)?.Name}");

            //Console.WriteLine($"Employee 105: {employees.Find(delegate (Employee emp) { return emp.ID == 105; }).Name}");

            
            var names = employees.Select(employee => "Name = " + employee.Name);

            foreach (var name in names)
                Console.WriteLine(name);

        }

        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Salary { get; set; }
            public int Experience { get; set; }
        }

        public static bool FindEmployee(Employee emp)
        {
            return emp.ID == 102;
        }
    }

    [TestFixture]
    public class AnonLamdaFuncServiceTests
    {
        public AnonLamdaFuncService service = new AnonLamdaFuncService();

        //[Test]
        //public void AnonLamdaFuncServiceTest1()
        //{
        //    var given = 1;
        //    var expected = 0;
        //    Assert.AreEqual(expected, service.MyMethod(given));
        //}

        //[Test]
        //public void AnonLamdaFuncServiceTest2()
        //{
        //    var given = 1;
        //    var expected = 0;

        //    Assert.AreEqual(expected, service.MyMethod(given));
        //}

        //[Test]
        //public void AnonLamdaFuncServiceTest3()
        //{
        //    var given = 1;
        //    var expected = 0;
        //    Assert.AreEqual(expected, service.MyMethod(given));
        //}
    }
}
