using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QAForum.DTOs;
using QAForum.EF;
using QAForum.Models;

namespace QAForum.ApiControllers
{
    [Route("api/[controller]", Order = 10)]
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
        public ActionResult<ForumDTO> Post(ForumDTO dto)
        {
            var forum = new Forum
            {
                Title = dto.Title
            };

            context.Forums.Add(forum);
            context.SaveChanges();

            // Create a new DTO, to reflect the ID that was asigned on save
            return CreatedAtAction
                ("Get", new { id = forum.ForumId }, ForumDTO.FromForum(forum));
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, ForumDTO dto)
        {
            if (id != dto.ForumId)
            {
                return BadRequest("The forum id in the body must match the id in the URL");
            }

            var forum = context.Forums.SingleOrDefault(f => f.ForumId == id);
            if (forum == null)
            {
                return NotFound();
            }

            forum.Title = dto.Title;
            context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<ForumDTO> Delete(int id)
        {
            var forum = context.Forums.SingleOrDefault(f => f.ForumId == id);
            if (forum == null)
            {
                return NotFound();
            }

            context.Forums.Remove(forum);
            context.SaveChanges();

            return ForumDTO.FromForum(forum);
        }
    }
}