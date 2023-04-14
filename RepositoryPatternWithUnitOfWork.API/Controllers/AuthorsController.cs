using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUnitOfWork.Core;
using RepositoryPatternWithUnitOfWork.Core.Models;
using RepositoryPatternWithUnitOfWork.Core.Repositories;

namespace RepositoryPatternWithUnitOfWork.API.Controllers
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

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Authors.GetAll());
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _unitOfWork.Authors.GetAllAsync());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Authors.GetById(id));
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _unitOfWork.Authors.GetByIdAsync(id));
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            return Ok(_unitOfWork.Authors.Find(x=> x.Name == name));
        }

        [HttpGet("GetByNameAsync")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            return Ok(await _unitOfWork.Authors.FindAsync(x => x.Name == name));
        }

        [HttpGet("GetAllByPartOfName")]
        public IActionResult GetAllByPartOfName(string name)
        {
            return Ok(_unitOfWork.Authors.FindAll(x => x.Name.Contains(name)));
        }

        [HttpGet("GetAllByPartOfNameAsync")]
        public async Task<IActionResult> GetAllByPartOfNameAsync(string name)
        {
            return Ok(await _unitOfWork.Authors.FindAllAsync(x => x.Name.Contains(name)));
        }


        [HttpPost("AddOne")]
        public IActionResult Add(string Name)
        {
            // here no need to accept entity as is because the id is auto increment

           var author = _unitOfWork.Authors.Add(new Author { Name = Name });
            _unitOfWork.Complete();
            return Ok(author);
        }

        [HttpPost("AddOneAsync")]
        public async Task<IActionResult> AddAsync(string Name)
        {
            var author = await _unitOfWork.Authors.AddAsync(new Author { Name = Name });
            await _unitOfWork.CompleteAsync();
            return Ok(author);
        }
    }
}
