using DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UoWController : ControllerBase
    {
        private readonly ILogger<UoWController> _logger;
        private IUnitOfWork _unitOfWork;

        public UoWController(ILogger<UoWController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("")]
        public Task<Author> CommitUoW()
        {
            Book gambler = new Book("The Gambler");
            Author fyodor = new Author("Fyodor Dostoyevsky", "Russia", new List<Book>() { gambler });

            try
            {
                _unitOfWork.BookRepository.Insert(gambler);
                _unitOfWork.AuthorRepository.Insert(fyodor);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error when creating uow transaction, thereby reverting back. Error: {}", ex.Message);
                _unitOfWork.Rollback();
                return Task.FromResult(new Author());
            }

            return _unitOfWork.AuthorRepository.GetByName(fyodor.Name);
        }
    }
}
