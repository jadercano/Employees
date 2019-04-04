﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.TO
{
    /// <summary>
    /// Class that represent an employee entity from data source
    /// </summary>
    public class EmployeeTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContractTypeName { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string RoleDescription { get; set; }

        public double HourlySalary { get; set; }

        public double MonthlySalary { get; set; }
    }
}
