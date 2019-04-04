using System;
using Employees.Core.Employee;
using Employees.DAO.Employee;
using LightInject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Employees.Core.Test
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        public static ServiceContainer Container { get; set; }

        [ClassInitialize]
        public static void EmployeeRepositoryTest_Initialize(TestContext testContext)
        {
            //Se registra el encargado de resolver las instancias y dependencias
            //Service Container
            Container = new ServiceContainer();
            Container.Register<IEmployeeDAO, EmployeeDAO>();
            Container.Register<IEmployeeRepository, EmployeeRepository>();
        }

        [TestMethod]
        public void GetAll()
        {
            var _employeeRepository = Container.GetInstance<IEmployeeRepository>();
            var employees = _employeeRepository.GetEmployees();

            Assert.IsNotNull(employees);
            Assert.IsTrue(employees.Count > 0);
        }

        [TestMethod]
        public void GetById()
        {
            var _employeeRepository = Container.GetInstance<IEmployeeRepository>();
            var employeeId = 1;
            var employee = _employeeRepository.GetEmployee(employeeId);

            Assert.IsNotNull(employee);
            Assert.AreEqual(employeeId, employee.Id);
        }
    }
}
