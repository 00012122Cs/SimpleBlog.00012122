namespace SimpleBlogBackend.Models
{
    public class Post
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public int UserId { get; set; } // ID of the user creating the post
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Default to current time

    }
}
