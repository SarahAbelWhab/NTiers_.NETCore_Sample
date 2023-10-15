using BLL.Services;
using DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : BaseController
    {
        private readonly IAuthorService authorService;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorController(IUnitOfWork unitOfWork, IAuthorService authorService)
        {
            _unitOfWork = unitOfWork;
            this.authorService = authorService; 
        }

        [HttpGet("")]
        public IEnumerable<Author> GetAllAuthors() => authorService.GetAllAuthors();

        //[HttpGet("{authorName}")]
        //public Task<Author> GetAuthorByName(String authorName) => authorService.GetByName(authorName);

        [HttpPost("")]
        public void AddAuthor([FromBody] Author author)
        {
            authorService.AddAuthor(author);

            ActivityyyLog activityLog = new ActivityyyLog
            {
                IPAddress = UserIP,
                UserName = currentUserName,
                Action = "Add",
                URL = ""
            };

            _unitOfWork.ActivityLogRepository.Insert(activityLog);
            _unitOfWork.Commit();
        }

    }
}
