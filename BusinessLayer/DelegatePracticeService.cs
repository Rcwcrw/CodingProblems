using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public delegate void MyDelegate(string message);
    public delegate bool IsPromotable(Employee employee);
    public delegate void SampleDelegate(out int outValue);


    public class DelegatePracticeService : IBaseService
    {
        public void ConsoleRun2()
        {
            //var myDelegate = new MyDelegate(MyFunction);

            //myDelegate("Hello from my delegate");

            //MyCaller(myDelegate);


            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee() { ID = 101, Name = "Mary", Salary = 5000, Experience = 5 });
            employees.Add(new Employee() { ID = 101, Name = "John", Salary = 6000, Experience = 6 });
            employees.Add(new Employee() { ID = 101, Name = "Todd", Salary = 3000, Experience = 3 });
            employees.Add(new Employee() { ID = 101, Name = "Mike", Salary = 4000, Experience = 4 });

            Employee.PromoteEmployee(employees, emp => emp.Experience >= 5);
        }

        public void ConsoleRun()
        {
            var del = new SampleDelegate(SampleMethodOne);
            del += SampleMethodTwo;
            var outValue = -1;

            del(out outValue);

            Console.WriteLine(outValue);
        }

        public static void SampleMethodOne(out int outValue)
        {
            outValue = 1;
        }
        public static void SampleMethodTwo(out int outValue)
        {
            outValue = 2;
        }

        public static void SampleMethodThree()
        {
            Console.WriteLine("SampleMethodThree Invoked");
        }
        public static void SampleMethodFour()
        {
            Console.WriteLine("SampleMethodFour Invoked");
        }


        public static bool Promote(Employee emp)
        {
            return emp.Experience >= 4;
        }

        public void MyCaller(Delegate del)
        {
            del.DynamicInvoke("Hello from my caller");
        }

        //public string MyMethod(Func<string> func)
        //{
        //    return func.Invoke();
        //}

        public void MyFunction(string message)
        {
            Console.WriteLine($"MyFunction: {message}");            
        }
    }


    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Experience { get; set; }

        public static void PromoteEmployee(List<Employee> employees, IsPromotable isPromotable)
        {
            foreach (var employee in employees)
            {
                if (isPromotable(employee))
                    Console.WriteLine($"{employee.Name}: promoted");
            }
        }

        public static void PromoteEmployeeOld(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                if (employee.Experience > 5)
                    Console.WriteLine($"{employee.Name}: promoted");
            }
        }
    }

    [TestFixture]
    public class DelegatePracticeServiceTests
    {
        public DelegatePracticeService service = new DelegatePracticeService();

        [Test]
        public void DelegatePracticeServiceTest1()
        {
            //var given = "Hello from my delegate";
            //var expected = "MyFunction: Hello from my delegate";
            //var del = new MyDelegate(service.MyFunction);
            //Assert.AreEqual(expected, del(given));
        }
    }
}
