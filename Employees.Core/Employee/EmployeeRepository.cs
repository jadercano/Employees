using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.TO;

namespace Employees.Core.Employee
{
    /// <summary>
    /// Implement operations for the Employees Service
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeFactory employeeFactory;

        public EmployeeRepository()
        {
            employeeFactory = new ConcreteEmployeeFactory();
        }

        /// <summary>
        /// Instance DAO for Employees
        /// </summary>
        public IEmployeeDAO EmployeeDAO { get; set; }

        /// <see cref="Employees.Core.Employee.IEmployeeRepository.GetEmployee(int)"
        public TO.Employee GetEmployee(int id)
        {
            //Get employees list from data source
            var employees = EmployeeDAO.GetEmployees();

            //Find employe by id
            var employee = employees.FirstOrDefault(e => e.Id.Equals(id));

            //Create a concrete employee by contract type
            var emp = employeeFactory.GetEmployee(employee.ContractTypeName);
            emp.Id = employee.Id;
            emp.Name = employee.Name;
            emp.ContractTypeName = employee.ContractTypeName;
            emp.RoleId = employee.RoleId;
            emp.RoleName = employee.RoleName;
            emp.RoleDescription = employee.RoleDescription;
            emp.HourlySalary = employee.HourlySalary;
            emp.MonthlySalary = employee.MonthlySalary;

            return emp;
        }

        /// <see cref="Employees.Core.Employee.IEmployeeRepository.GetEmployees"
        public List<TO.Employee> GetEmployees()
        {
            //Get employees list from data source
            var employees = EmployeeDAO.GetEmployees();

            if (employees == null || employees.Count <= 0)
            {
                return null;
            }

            //Create a employees list with the concrete employee by contract type
            var result = new List<TO.Employee>();
            foreach (var employee in employees)
            {
                var emp = employeeFactory.GetEmployee(employee.ContractTypeName);
                emp.Id = employee.Id;
                emp.Name = employee.Name;
                emp.ContractTypeName = employee.ContractTypeName;
                emp.RoleId = employee.RoleId;
                emp.RoleName = employee.RoleName;
                emp.RoleDescription = employee.RoleDescription;
                emp.HourlySalary = employee.HourlySalary;
                emp.MonthlySalary = employee.MonthlySalary;
                result.Add(emp);
            }

            return result;
        }
    }
}
