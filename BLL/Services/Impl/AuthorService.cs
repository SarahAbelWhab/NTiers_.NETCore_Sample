using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Impl
{
    public class AuthorService : IAuthorService
    {
        private IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        { _unitOfWork = unitOfWork; }

        public IEnumerable<Author> GetAllAuthors() => _unitOfWork.AuthorRepository.GetAll();

        public void AddAuthor(Author author)
        {
            _unitOfWork.AuthorRepository.Insert(author);
                      

            _unitOfWork.Commit();
        }
    }
}
