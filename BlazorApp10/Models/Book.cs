namespace BlazorApp10.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string PublicationYear { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
    }
}
