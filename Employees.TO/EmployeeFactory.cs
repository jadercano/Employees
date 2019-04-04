using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.TO
{
    public abstract class EmployeeFactory
    {
        public abstract Employee GetEmployee(string contractType);
    }
}
