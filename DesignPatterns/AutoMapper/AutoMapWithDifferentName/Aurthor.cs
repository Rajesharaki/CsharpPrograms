using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.AutoMapper.AutoMapWithDifferentName
{
    public class Aurthor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public Aurthor(String FirstName, String LastName, long PhoneNumber)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PhoneNumber = PhoneNumber;
        }
    }
}
