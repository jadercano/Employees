using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.TO
{
    /// <summary>
    /// Class that represent an employee entity whit a monthly salary contract
    /// </summary>
    public class MonthlySalaryEmployee : Employee
    {
        public override double AnnualSalary => MonthlySalary * 12;
    }
}
