using Microsoft.AspNetCore.Mvc;
using SimpleBlogBackend;
using SimpleBlogBackend.Models;
using SimpleBlogBackend.Dtos; // Correct namespace for PostDto

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
            // Return a simplified list of posts with basic details
            var posts = _context.Posts
                .Select(p => new
                {
                    p.Id,
                    p.Title,
                    p.Content,
                    p.CreatedAt,
                    p.UserId
                })
                .ToList();

            return Ok(posts);
        }

        // GET: api/Post/{id}
        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            // Find the post by ID
            var post = _context.Posts
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    p.Id,
                    p.Title,
                    p.Content,
                    p.CreatedAt,
                    p.UserId
                })
                .FirstOrDefault();

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        // POST: api/Post
        [HttpPost]
        public IActionResult CreatePost([FromBody] PostDto postDto)
        {
            // Validate the input
            if (string.IsNullOrWhiteSpace(postDto.Title) || string.IsNullOrWhiteSpace(postDto.Content))
                return BadRequest("Title and Content are required.");

            // Verify that the user exists
            var userExists = _context.Users.Any(u => u.Id == postDto.UserId);
            if (!userExists)
                return BadRequest("Invalid User ID.");

            // Create and save the new post
            var post = new Post
            {
                Title = postDto.Title,
                Content = postDto.Content,
                CreatedAt = DateTime.Now,
                UserId = postDto.UserId
            };

            _context.Posts.Add(post);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, new
            {
                post.Id,
                post.Title,
                post.Content,
                post.CreatedAt,
                post.UserId
            });
        }

        // PUT: api/Post/{id}
        [HttpPut("{id}")]
        public IActionResult UpdatePost(int id, [FromBody] PostDto postDto)
        {
            // Validate the input
            if (string.IsNullOrWhiteSpace(postDto.Title) || string.IsNullOrWhiteSpace(postDto.Content))
                return BadRequest("Title and Content are required.");

            // Find the existing post
            var post = _context.Posts.Find(id);
            if (post == null)
                return NotFound();

            // Verify that the user exists
            var userExists = _context.Users.Any(u => u.Id == postDto.UserId);
            if (!userExists)
                return BadRequest("Invalid User ID.");

            // Update the post details
            post.Title = postDto.Title;
            post.Content = postDto.Content;
            post.UserId = postDto.UserId;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Post/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            // Find the post to delete
            var post = _context.Posts.Find(id);
            if (post == null)
                return NotFound();

            _context.Posts.Remove(post);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
