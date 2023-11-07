using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskf.Models
{
    public abstract class Person
    {
        public static int _id = 1;
        public int Id { get=>_id;}
        public string Name { get; set; }
        public string Surname { get; set; }

        public int Age { get; set; }

        public Person()
        {
            _id++;
            _id = Id;
        }
        public Person(string name,string surname,int age)
        {
            
            Name = name;
            Surname = surname;
            Age = age;
        }
        
        
        public virtual string Fullname()
        {
            return $"{Name} {Surname}  ";
        }
    }
}
