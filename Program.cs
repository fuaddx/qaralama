using System.Xml.Linq;
using Taskf.Exception;
using Taskf.Models;
using static Taskf.Models.Employee;

namespace Taskf
{
     public class Program
    {
        static void Main(string[] args)
        {

            Company company = new Company("ABC Inc.");
            EmployeeDatabase employees = new EmployeeDatabase();

            int option;
            do
            {
                Console.WriteLine("Choose from below options:");
                Console.WriteLine("1. Create employee");
                Console.WriteLine("2. Get employee details by id");
                Console.WriteLine("3. Get all employees");
                Console.WriteLine("4. Update employee details");
                Console.WriteLine("5. Delete employee records by id");
                Console.WriteLine("Select an option: ");
                option = Convert.ToInt32(Console.ReadLine());
                try
                {
                   
                    switch (option)
                    {

                        case 1:
                            CreateEmployee(company);
                            break;
                        case 2:
                            GetEmployeeById(company);
                            break;
                        case 3:
                            GetAllEmployees(company);
                            break;
                        case 4:
                            UpdateEmployeeDetails(company);
                            break;
                        case 5:
                            DeleteEmployeeById(company);
                            break;
                        default:
                            Console.WriteLine("Write Again");
                            break;
                    }
                }
                catch(EmployeeNotFound ex)
                {
                    
                    Console.WriteLine(ex.Message);
                    
                }
            } while (option != 0);
            

            static void CreateEmployee(Company company)
            {
                Console.WriteLine("Enter employee name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter employee surname: ");
                string surname = Console.ReadLine();
                Console.WriteLine("Enter employee age: ");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Salary : ");
                decimal salary = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter employee position: ");
                string position = Console.ReadLine();
                Console.WriteLine("Enter employee gender (Male/Female/Other): ");
                Console.WriteLine($"M - Male\n" +
                    $"F - Female\n" +
                    $"O - other\n");
                char gender;
                do
                {
                    gender = Convert.ToChar(Console.ReadLine());
                    switch (gender)
                    {
                        case (char)Models.Gender.Male:
                            Console.WriteLine("Male");
                            break;
                        case (char)Models.Gender.Female:
                            Console.WriteLine("Female");
                            break;

                        case (char)Models.Gender.Other:
                            Console.WriteLine("Other");
                            break;
                            
                        default:
                            Console.WriteLine("Please choose from options");
                        break;
                    }
                    break;
                } while (gender != 'M' || gender != 'F' || gender != 'O');

                Employee employee = new Employee(name, surname, age, salary, position);
                company.AddEmployee(employee);
                Console.WriteLine("Employee created successfully.");
                Console.WriteLine($"{employee.Fullname()}");
            }

            static void GetEmployeeById(Company company)
            {
                Console.WriteLine("Enter employee ID: ");
                int id = Convert.ToInt32(Console.ReadLine());
                if (id>=0)
                {
                    try
                    {
                        
                        Employee employee = company.GetEmployeeById(id);
                        Console.WriteLine($"Employee ID: {employee.Id}");
                        Console.WriteLine($"Name: {employee.Name}");
                        Console.WriteLine($"Surname: {employee.Surname}");
                        Console.WriteLine($"Age: {employee.Age}");
                        Console.WriteLine($"Salary: {employee.Salary}");
                        Console.WriteLine($"Position: {employee.Position}");
                        Console.WriteLine($"Gender: {employee.gender}");
                    }
                    catch (EmployeeNotFound ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID input. Please enter a valid number.");
                }
            }

            static void DeleteEmployeeById(Company company)
            {
                Console.WriteLine("Enter employee ID to delete: ");

                int id = Convert.ToInt32(Console.ReadLine());
                if (id>=0)
                {
                    try
                    {
                        Employee employee = company.GetEmployeeById(id);
                        company.RemoveEmployee(employee);
                        Console.WriteLine("Employee deleted successfully.");
                    }
                    catch (EmployeeNotFound)
                    {
                        Console.WriteLine("Employee not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID input. Please enter a valid number.");
                }
            }


            static void GetAllEmployees(Company company)
            {
                List<Employee> employees = company.GetEmployees();
                if (employees.Count > 0)
                {
                    Console.WriteLine("All Employees:");
                    foreach (var employee in employees)
                    {
                        Console.WriteLine($"{employee.Fullname()}");
                    }
                }
                else
                {
                    Console.WriteLine("No employees found.");
                }
            }

            static void UpdateEmployeeDetails(Company company)
            {
                Console.WriteLine("Enter employee ID to update: ");
                int id = Convert.ToInt32(Console.ReadLine());
                if (id>=0)
                {
                    try
                    {
                        Employee existingEmployee = company.GetEmployeeById(id);

                        Console.WriteLine("What do you want to update?");
                        Console.WriteLine("1. Name");
                        Console.WriteLine("2. Gender");
                        Console.WriteLine("3. Salary");
                        Console.WriteLine("4. Position");
                        Console.WriteLine("Select an option: ");

                        int uptadeOption = Convert.ToInt32(Console.ReadLine());
                        if (uptadeOption>=0)
                        {
                            switch (uptadeOption)
                            {
                                case 1:
                                    Console.WriteLine("Enter new name: ");
                                    existingEmployee.Name = Console.ReadLine();
                                    break;
                                case 2:
                                    Console.WriteLine("Enter employee gender (Male/Female/Other): ");
                                    Console.WriteLine($"M - Male\n" +
                                        $"F - Female\n" +
                                        $"O - other\n");
                                    char gender;
                                    do
                                    {
                                        gender = Convert.ToChar(Console.ReadLine());
                                        switch (gender)
                                        {
                                            case (char)Models.Gender.Male:
                                                Console.WriteLine("Male");
                                                break;
                                            case (char)Models.Gender.Female:
                                                Console.WriteLine("Female");
                                                break;
                                            case (char)Gender.Other:
                                                Console.WriteLine("Other");
                                                break;

                                            default:
                                                Console.WriteLine("Please choose from options");
                                                break;

                                        }
                                    } while (gender != 'M' || gender != 'F' || gender != 'O');
                                    break;
                                case 3:
                                    Console.WriteLine("Enter new salary: ");
                                    decimal salary = Convert.ToInt64(Console.ReadLine());
                                    if (salary>=0)
                                    {
                                        existingEmployee.Salary = salary;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid salary input. Salary not updated.");
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine("Enter new position: ");
                                    existingEmployee.Position = Console.ReadLine();
                                    break;
                                default:
                                    Console.WriteLine("Invalid option. No updates were made.");
                                    break;
                            }

                            Console.WriteLine("Employee details updated successfully.");
                        }
                    }
                    catch (EmployeeNotFound ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    throw new EmployeeNotFound("Invalid ID input. Please enter a valid number.");
                }

            }
            }
    }
}