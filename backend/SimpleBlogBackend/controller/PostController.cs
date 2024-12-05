using Microsoft.AspNetCore.Mvc;
using SimpleBlogBackend;
using SimpleBlogBackend.Models;

namespace SimpleBlogBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly SimpleBlogContext _context;

        public PostController(SimpleBlogContext context)
        {
            _context = context;
        }

        // GET: api/Post
        [HttpGet]
        public IActionResult GetPosts()
        {
            var posts = _context.Posts.ToList();
            return Ok(posts);
        }

        // GET: api/Post/{id}
        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null)
                return NotFound();

            return Ok(post);
        }

        // POST: api/Post
        [HttpPost]
        public IActionResult CreatePost([FromBody] Post post)
        {
            if (post == null)
                return BadRequest();

            _context.Posts.Add(post);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
        }

        // PUT: api/Post/{id}
        [HttpPut("{id}")]
        public IActionResult UpdatePost(int id, [FromBody] Post updatedPost)
        {
            if (id != updatedPost.Id)
                return BadRequest();

            var existingPost = _context.Posts.Find(id);
            if (existingPost == null)
                return NotFound();

            existingPost.Title = updatedPost.Title;
            existingPost.Content = updatedPost.Content;
            existingPost.CreatedAt = updatedPost.CreatedAt;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Post/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null)
                return NotFound();

            _context.Posts.Remove(post);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
