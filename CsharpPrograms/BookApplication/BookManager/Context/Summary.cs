using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookManager.Context
{
    public class Summary
    {
        [Key]
        public int ID { get; set; }
        public string AccountUserName { get; set; }
        public Guid BookID { get; set; }
        public Guid AddressID { get; set; }
    }
}
