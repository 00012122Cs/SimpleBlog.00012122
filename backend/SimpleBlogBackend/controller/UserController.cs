using Microsoft.AspNetCore.Mvc;
using SimpleBlogBackend;
using SimpleBlogBackend.Models;
using SimpleBlogBackend.Dtos;


namespace SimpleBlogBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SimpleBlogContext _context;

        public UserController(SimpleBlogContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST: api/User
       [HttpPost]
public IActionResult CreateUser([FromBody] UserDto userDto)
{
    if (string.IsNullOrWhiteSpace(userDto.Username) || string.IsNullOrWhiteSpace(userDto.Email))
        return BadRequest("Username and Email are required.");

    var user = new User
    {
        Username = userDto.Username,
        Email = userDto.Email
    };

    _context.Users.Add(user);
    _context.SaveChanges();

    return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
}

// PUT: api/User/{id}
[HttpPut("{id}")]
public IActionResult UpdateUser(int id, [FromBody] UserDto userDto)
{
    var existingUser = _context.Users.Find(id);
    if (existingUser == null)
        return NotFound();

    existingUser.Username = userDto.Username;
    existingUser.Email = userDto.Email;

    _context.SaveChanges();
    return NoContent();
}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
