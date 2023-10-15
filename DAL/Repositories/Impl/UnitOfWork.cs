using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Impl
{
    public class UnitOfWork : IUnitOfWork
    {        
        private DatabaseContext _databaseContext;
        private IAuthorRepository _authorRepository;
        private IRepository<Book> _bookRepository;
        private IRepository<ActivityyyLog> _activityLogRepository;

        //private string CurrentUser;
        //private string ip;
        //private User CurrentUserObject;

        public UnitOfWork(DatabaseContext databaseContext)
        { _databaseContext = databaseContext; }

        public IAuthorRepository AuthorRepository
        {
            get { return _authorRepository = _authorRepository ?? new AuthorRepository(_databaseContext); }
        }

        public IRepository<Book> BookRepository
        {
            get { return _bookRepository = _bookRepository ?? new Repository<Book>(_databaseContext); }
        }

        public IRepository<ActivityyyLog> ActivityLogRepository
        {
            get { return _activityLogRepository = _activityLogRepository ?? new Repository<ActivityyyLog>(_databaseContext); }
        }

        public void Commit()
        { _databaseContext.SaveChanges(); }

        public void Rollback()
        { _databaseContext.Dispose(); }

        //public void setUserInfo(string currentUser, string ip)
        //{
        //    this.CurrentUser = currentUser;
        //    this.ip = ip;
        //    //this.CurrentUserObject = currentUser;
        //    _databaseContext = new DatabaseContext(CurrentUser, ip);
        //    //_databaseContext.Configuration.LazyLoadingEnabled = false;

        //}

    }
}
