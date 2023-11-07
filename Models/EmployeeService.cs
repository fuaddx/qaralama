using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Taskf.Exception;

namespace Taskf.Models
{

    internal class EmployeeService
    {
        

       public void AddEmployee(Employee employee)
        {

            EmployeeDatabase.Employees.Add(employee);
        }


        public Employee GetEmployeeById(int id)
        {
            foreach (var employee in Employees)
            {
                if (employee.Id == id)
                {
                    return employee;
                }

            }
            throw new EmployeeNotFound("Employe not found!!!");

        }


        public void UptadeEmployee(Employee employee)
        {
            for (int i = 0; i < Employees.Count; i++)
            {
                if (Employees[i].Id == employee.Id)
                {
                    Employees[i] = employee;
                    return;
                }
            }
            throw new EmployeeNotFound();
        }

        public void RemoveEmployee(Employee employee)
        {
            if (!Employees.Remove(employee))
            {
                throw new EmployeeNotFound();
            }
        }


        public void  GetEmployees()
        {
            EmployeeDatabase.Employees.ForEach(x => Console.WriteLine(x));
        }

        public static List<Employee> GetEmployeesByValue(string value)
        {
            return EmployeeDatabase.Employees.FindAll(e => e.Name.Contains(value));
        }
        public static List<Employee> GetLatestEmployees()
        {
            /*var c = DateTimeFormatInfo.CurrentInfo.Calendar;
            return EmployeeDatabase.Employees.FindAll(e=>
            {
                int now = c.GetWeekOfYear(DateTime.Now);
            })*/
        }


    }
}
