using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace DesignPatterns.AutoMapper
{
    public class AutoMapper
    {
        /*static void Main()
        {
            Person person = new Person("Madan", "Kumar", 6565465411);
            //by using auto mapper we can tranfer or copy one class object content to the another class object coontent if content name is same
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<Person, Employee>(); });
            IMapper conf=config.CreateMapper();
            Employee emp=conf.Map<Person,Employee>(person);
            Console.WriteLine($"EmployeName: {emp.FirstName}\nLastName: {emp.LastName}\nPhoneNumber:{emp.PhoneNumber}");
        }*/
    }
}
