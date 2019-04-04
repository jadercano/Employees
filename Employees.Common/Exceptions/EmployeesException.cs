using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Common.Exceptions
{
    /// <summary>
    /// Custom exception class for Employees application
    /// </summary>
    public class EmployeesException : ApplicationException
    {
        public EmployeesException()
        {
        }

        public EmployeesException(string message) : base(message)
        {
        }

        public EmployeesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmployeesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
