using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositroyPatternWithUOW.Core;
using RepositroyPatternWithUOW.Core.Interfaces;
using RepositroyPatternWithUOW.Core.Models;
using RepositroyPatternWithUOW.EF.Repositories;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetById() 
        {
            return Ok(_unitOfWork.Authors.GetById(1));
        }

    }
}
