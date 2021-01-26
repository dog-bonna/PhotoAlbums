namespace PhotoAlbums.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

    }
}