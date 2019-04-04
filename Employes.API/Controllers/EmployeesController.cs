using Employees.Core.Employee;
using Employees.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Employees.API.Controllers
{
    /// <summary>
    /// Controller for employees operations
    /// </summary>
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeRepository _employessRepository;

        /// <summary>
        /// Create a new instance of <see cref="Employees.API.Controllers.EmployeesController"/>
        /// </summary>
        /// <param name="employessRepository">Instance of IEmployeeRepository injected</param>
        public EmployeesController(IEmployeeRepository employessRepository)
        {
            _employessRepository = employessRepository;
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>List of <see cref="Employees.TO.Employee"/></returns>
        [HttpGet]
        [ResponseType(typeof(List<Employee>))]
        public IHttpActionResult Get(int? id = null)
        {
            var respuesta = id.HasValue ? new List<Employee> { _employessRepository.GetEmployee(id.Value) }  : _employessRepository.GetEmployees();
            return Ok(respuesta);
        }
    }
}