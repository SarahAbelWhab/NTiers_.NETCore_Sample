using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }
        IRepository<Book> BookRepository { get; }
        IRepository<ActivityyyLog> ActivityLogRepository { get; }
        void Commit();
        void Rollback();
        //void setUserInfo(string currentUser, string ip);
    }
}
