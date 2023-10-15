using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models.BaseEntity;

namespace DAL.Models
{
    public class Book : BaseEntity.BaseEntity
    {
        public Book()
        {
        }

        public Book(string title)
        {
            Title = title;
        }

        public string Title { get; set; }

        public DateTime Year { get; set; }


    }
}
