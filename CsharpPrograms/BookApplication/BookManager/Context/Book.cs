using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookManager.Context
{
    public class Book
    {
        [Key]
        public Guid BookId { get; set; }
        public string Email { get; set; }
        public string BookName { get; set; }
        public string ContentType { get; set; }
        public int Price { get; set; }
        public string Author { get; set; }
        public int Stock { get; set; }

        public string CoverPhoto { get; set; }
    }
}
