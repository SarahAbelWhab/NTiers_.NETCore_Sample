using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<Author> GetByName(string firstName);
    }
}
