using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DesignPatterns.Reflection
{
    public class Custmor
    {
        public string EmployeeName;
        public string CompanyName;
        public long PhoneNumber;
        public string ID { get; set; }
        public Custmor()
        {

        }
        public Custmor(string Employee, string CompanyName, long PhoneNumber)
        {
            this.EmployeeName = Employee;
            this.CompanyName = CompanyName;
            this.PhoneNumber = PhoneNumber;
        }
        public string GetCompany()
        {
            return this.CompanyName;
        }
        public  void PrintName()
        {
            Console.WriteLine(this.EmployeeName);
        }
        public long GetNumber(long PhoneNumber)
        {
            return this.PhoneNumber;
        }
    }
    public class Reflection
    {
        //Refelction is used for inspecting the assembly metadata
        static void Main()
        {
            Type t = Type.GetType("DesignPatterns.Reflection.Custmor");
            Console.WriteLine("Get Fields....................\n");
            FieldInfo[] fields=t.GetFields();
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine(field.ToString());
            }
            Console.WriteLine("\nGetProperties................ ");
            Console.WriteLine(t.GetProperty("ID"));
            Console.WriteLine("\nGetMethods.............................\n");
            MethodInfo[] methods = t.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.ToString());
            }
            Console.WriteLine("\nConstructors..............................\n");
            ConstructorInfo [] Constructors=t.GetConstructors();
            foreach(ConstructorInfo Constructor in Constructors)
            {
                Console.WriteLine(Constructor.ToString());
            }
        }
    }
}
