using Employees.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Employee
{
    /// <summary>
    /// Interface with data access methods for the Employees Service
    /// </summary>
    public interface IEmployeeDAO
    {
        /// <summary>
        /// Get and return all employees
        /// </summary>
        /// <returns>List of <see cref="Employees.TO.EmployeeTO"/></returns>
        List<EmployeeTO> GetEmployees();
    }
}
