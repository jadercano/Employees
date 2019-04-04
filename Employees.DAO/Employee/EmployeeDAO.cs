using Employees.Common.Exceptions;
using Employees.Core.Employee;
using Employees.Resources;
using Employees.TO;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DAO.Employee
{
    /// <summary>
    /// Implementation of data access methods for the Employees Service
    /// </summary>
    public class EmployeeDAO : IEmployeeDAO
    {
        /// <see cref="Employees.Core.Employee.IEmployeeDAO.GetEmployees"/>
        public List<EmployeeTO> GetEmployees()
        {
            //TODO Cache this result
            //Get and validate Employees api url
            string employeesUrl = ConfigurationManager.AppSettings["Employees_UrlService"];

            if (string.IsNullOrWhiteSpace(employeesUrl))
            {
                throw new EmployeesException(string.Format(Messages.Error_AppSettingRequired, "Employees_UrlService"));
            }

            //Create client for requesting Employees list
            var client = new RestClient(employeesUrl);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new EmployeesException(Messages.Error_Employees_GetEmployees, response.ErrorException);
            }

            //Deserialize response and return employees list
            var employees = JsonConvert.DeserializeObject<List<EmployeeTO>>(response.Content);
            return employees;
        }
    }
}
