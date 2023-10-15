using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Author : BaseEntity.BaseEntity
    {
        public Author()
        {
        }

        public Author(string name, string country, ICollection<Book> books)
        {
            Name = name;
            Country = country;
            Books = books;
        }

        public string Name { get; set; }

        public string Country { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
