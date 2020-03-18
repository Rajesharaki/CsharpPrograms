using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.DependencyInjection
{
    public class Employee
    {
        public string EmployeeName { get; set; }
        public string DepartMent { get; set; }
        public Employee(String EmpName,String Dept)
        {
            this.EmployeeName = EmpName;
            this.DepartMent = Dept;
        }
    }
}
