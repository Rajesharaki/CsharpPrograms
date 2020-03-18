using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.DependencyInjection
{
    class EmployeeDataBase
    {
        private static void Main(String[]args)
        {
            EmployeeDeatails EmpDetail1= new EmployeeDeatails(new Employee("Rajesha","Developer"));
            EmpDetail1.GetDetails();
            EmployeeDeatails EmpDetail2 = new EmployeeDeatails(new Employee("Sanju","Tester"));
            EmployeeDeatails EmpDetail3 = new EmployeeDeatails(new Employee("Madan","Team Leader"));
            EmpDetail2.GetDetails();
            EmpDetail3.GetDetails();
        }
    }
}
