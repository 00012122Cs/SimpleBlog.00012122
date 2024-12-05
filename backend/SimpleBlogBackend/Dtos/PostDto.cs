namespace SimpleBlogBackend.Dtos
{
    public class PostDto
    {
        public int UserId { get; set; } // ID of the user creating the post
        public string Title { get; set; } = string.Empty; // Post title
        public string Content { get; set; } = string.Empty; // Post content
    }
}
