using Employees.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Employee
{
    /// <summary>
    /// Interface with operations for the Employees Service
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>List of <see cref="Employees.TO.Employee"/></returns>
        List<TO.Employee> GetEmployees();

        /// <summary>
        /// Get an employee by id
        /// </summary>
        /// <param name="id">Employee Id</param>
        /// <returns>Instance of <see cref="Employees.TO.Employee"/> with Employee information</returns>
        TO.Employee GetEmployee(int id);
    }
}
