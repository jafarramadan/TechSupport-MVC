namespace TechSupport.Models
{
    public class KnowledgeBaseArticle
    {
        public int Id { get; set; } // Primary Key
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
