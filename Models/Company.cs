using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Taskf.Exception;

namespace Taskf.Models 

{
    internal class Company 
    {
        public string Name { get; set; }

        public List<Employee> Employees = new List<Employee>();
        public Company(string name)
        {
            Name = name;
            Employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
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
        public List<Employee> GetEmployees()
        {
            return Employees;
        }
    }
}
