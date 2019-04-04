using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.TO
{
    /// <summary>
    /// Class that represent an employee entity whit a hourly salary contract
    /// </summary>
    public class HourlySalaryEmployee : Employee
    {
        public override double AnnualSalary => 120 * HourlySalary * 12;
    }
}
