using System.Runtime.Serialization;

namespace Taskf.Exception
{
    internal class EmployeeNotFound : System.Exception
    {
        public EmployeeNotFound()
        {
        }

        public EmployeeNotFound(string? message) : base(message)
        {
        }
    }
}