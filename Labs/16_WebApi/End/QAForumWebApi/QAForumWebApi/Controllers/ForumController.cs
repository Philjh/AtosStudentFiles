using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QAForum.EF;
using QAForum.Models;
using QAForumWebApi.DTOs;

namespace QAForumWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumController : ControllerBase
    {
        private readonly ForumDbContext context;

        public ForumController(ForumDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<ForumDTO> Get()
        {
            return ForumDTO.FromFourms(context.Forums);
        }

        [HttpGet("{id}")]
        public ActionResult<ForumDTO> Get(int id)
        {
            var forum = context.Forums.SingleOrDefault(f => f.ForumId == id);

            if (forum == null)
            {
                return NotFound();
            }


            return ForumDTO.FromForum(forum);
        }

        [HttpPost]
        public ActionResult<ForumDTO> Post(ForumDTO ForumDTO)
        {
            Forum newForum = new Forum() { Title= ForumDTO.Title };
            
            context.Add(newForum);
            context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = ForumDTO.ForumId }, ForumDTO);
        }


    }
}
