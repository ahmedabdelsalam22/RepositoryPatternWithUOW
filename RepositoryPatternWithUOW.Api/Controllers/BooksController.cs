using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositroyPatternWithUOW.Core;
using RepositroyPatternWithUOW.Core.Consts;
using RepositroyPatternWithUOW.Core.Interfaces;
using RepositroyPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetById")]
        public IActionResult GetById() 
        {
         return Ok(_unitOfWork.Books.GetById(1));
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return  Ok( await _unitOfWork.Books.GetByIdAsync(1));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll() 
        {
            return Ok(_unitOfWork.Books.GetAll());
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            return Ok(_unitOfWork.Books.Find(b=>b.Title == "warGames", new[] { "Author" }));
        }



        [HttpGet("GetOrdered")]
        public IActionResult GetOrdered()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("New Book"), null, null, b => b.Id, OrderBy.Descending));
        }

        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            var book = _unitOfWork.Books.Add(new Book { Title = "Test 4", AuthorId = 1 });
            return Ok(book);
        }

    }
}
