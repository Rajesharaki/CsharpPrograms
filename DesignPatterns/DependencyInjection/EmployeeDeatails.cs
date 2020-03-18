using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.DependencyInjection
{
    public class EmployeeDeatails
    {
        Employee emp;
        public EmployeeDeatails(Employee emp)
        {
            this.emp = emp;
        }
        public void GetDetails()
        {
            Console.WriteLine($"EmployeName: {emp.EmployeeName}\nDepartMent: {emp.DepartMent}");
            Console.WriteLine("----------------------------------------------------------------");
        }
    }
}
