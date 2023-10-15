using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Impl
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(DatabaseContext context) : base(context) { }

        public Task<Author> GetByName(string name)
        {
            return context.Set<Author>().FirstOrDefaultAsync(author => author.Name == name);
            // return FirstOrDefault(author => author.Name == name);
        }
    }
}
