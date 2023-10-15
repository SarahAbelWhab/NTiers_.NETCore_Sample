using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors();
        //Task<Author> GetByName(string firstName);
        void AddAuthor(Author author);
    }
}
