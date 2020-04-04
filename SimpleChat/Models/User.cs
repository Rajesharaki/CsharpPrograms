﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.Models
{
    public class User
    {
        [Key]
        public int Id{ get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}
