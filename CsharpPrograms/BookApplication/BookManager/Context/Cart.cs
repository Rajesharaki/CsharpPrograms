using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookManager.Context
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public Guid BookId { get; set; }

        public string UserName { get; set; }

    }
}
