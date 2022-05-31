using System.ComponentModel.DataAnnotations;

namespace NotesApp2.Model
{
    public class Note
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        
        public string NotesApp2UserId { get; set; }
        
    }
}
