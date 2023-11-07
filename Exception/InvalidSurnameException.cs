using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskf.Exception
{
    internal class InvalidSurnameException: System.Exception
    {
        public InvalidSurnameException()
        {
            
        }
        public InvalidSurnameException(string? message) : base(message)
        {
            
        }
    }
}
