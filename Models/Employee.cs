using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskf.Models
{
    internal class Employee: Person
    {
        public decimal Salary { get; set; }
        public string Position { get; set; }

        public Gender gender;
        

        public Employee(string name, string surname, int age, decimal salary, string position)
        : base(name, surname, age)
        {
            Salary = salary;
            Position = position;
        }
        public enum Gender
        {
            Male = 'M',   
            Female = 'F',   
            Other = 'O'    
        };


        public override string Fullname()
        {
            return $"Name:  {Name}\nAge:  {Age}\nId:  {Id}\nSalary: {Salary}\nPosition:  {Position}";
        }
        
    }
}
