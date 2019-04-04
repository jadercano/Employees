using Employees.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.TO
{
    /// <summary>
    /// Concrete Employee factory
    /// </summary>
    public class ConcreteEmployeeFactory : EmployeeFactory
    {
        public override Employee GetEmployee(string contractType)
        {
            switch (contractType)
            {
                case ContractType.HourlySalary:
                    return new HourlySalaryEmployee();
                case ContractType.MonthlySalary:
                    return new MonthlySalaryEmployee();
                default:
                    throw new Exception(string.Format(Messages.Error_Employees_InvalidContractType, contractType));
            }
        }
    }
}
