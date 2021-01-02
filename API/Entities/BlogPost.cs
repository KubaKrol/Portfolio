namespace API.Entities
{
    public class BlogPost
    {
        public int Id { get; set; }
        public AppUser AppUser { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Contents { get; set; }
    }
}