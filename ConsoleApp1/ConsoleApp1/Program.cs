using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {

            EmployeeBuilder builder = new EmployeeBuilder();
            Employee employee = Employee.CreateBuilder().SetFisrtname("Kolya").SetSurname("Nikol").SetAge(48).SetPosition("Accountant").SetPosition("Programmist");
            Console.WriteLine(employee);

            Console.ReadKey();
        }
    }

    public class Employee
    {

        public string SurName { set; get; }
        public string FirstName { set; get; }
        public int Age { set; get; }

        public List<string> PositionList { set; get; } = new List<string>();

        public static EmployeeBuilder CreateBuilder()
        {
            return new EmployeeBuilder();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (!string.IsNullOrEmpty(FirstName))
                builder.AppendLine($"Firstname: {this.FirstName}");
            if (!string.IsNullOrEmpty(SurName))
                builder.AppendLine($"Surname: {this.SurName}");
            if (Age !=0)
                builder.AppendLine($"Age: {this.Age}");

            if (PositionList.Count != 0)
            {
                builder.AppendLine($"Previously occupied positions:");
                foreach (string item in PositionList)
                {
                    builder.AppendLine(item);
                }
            }

            return builder.ToString();
        }
    }


    public class EmployeeBuilder
    {
        Employee employee = new Employee();

        public EmployeeBuilder SetSurname(string surname)
        {
            employee.SurName = surname;
            return this;
        }

        public EmployeeBuilder SetFisrtname(string firstName)
        {
            employee.FirstName = firstName;
            return this;
        }

        public EmployeeBuilder SetAge(int age)
        {
            employee.Age = age;
            return this;
        }


        public EmployeeBuilder SetPosition(string type)
        {
            employee.PositionList.Add(type);
            return this;
        }


        public Employee GetEmployee()
        {
            return employee;
        }

        public static implicit operator Employee(EmployeeBuilder employeeBuilder)
        {
            return employeeBuilder.GetEmployee();
        }
    }

}