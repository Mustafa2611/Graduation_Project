using Final_Project.Core.Dtos.NewsDtos;
using FinalProject.Core.Models;
using FinalProject.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public NewsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("/Create_News")]
        public IActionResult Create(CreateNewsDto NewsDto)
        {
            News News = new News()
            {
                Name = NewsDto.Name,
                Description = NewsDto.Description,
                News_Date = NewsDto.News_Date
            };
            if (_unitOfWork.News.Create(News) == null)
                return BadRequest("Bad Request");
            _unitOfWork.Complete();
            return Ok(News);
        }

        [HttpGet("/Get_News_By_Id/{id}")]
        public IActionResult Get(int id)
        {
            News News = _unitOfWork.News.Get(id);
            if (News == null)
                return NotFound();

            return Ok(News);
        }

        [HttpGet("/Get_All_News")]
        public IActionResult GetAll()
        {
            IEnumerable<News> News = _unitOfWork.News.GetAll();
            if (News == null)
                return NotFound();

            return Ok(News);
        }

        [HttpPut("/Update_News")]
        public IActionResult Update(UpdateNewsDto NewsDto)
        {

            News News = new()
            {
                NewsId = NewsDto.NewsId,
                Name = NewsDto.Name,
                Description = NewsDto.Description,
                News_Date = NewsDto.News_Date
            };
            if (_unitOfWork.News.Get(News.NewsId) == null)
                return NotFound();

            _unitOfWork.News.Update(News);
            _unitOfWork.Complete();
            return Ok(News);
        }

        [HttpDelete("/Delete_News/{id}")]
        public IActionResult Delete(int id)
        {
            News News = _unitOfWork.News.Get(id);
            if (News == null)
                return NotFound("News Not Found");

            _unitOfWork.News.Delete(id);
            _unitOfWork.Complete();
            return Ok(News);
        }
    }
}
