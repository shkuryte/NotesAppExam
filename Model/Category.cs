using System.ComponentModel.DataAnnotations;

namespace NotesApp2.Model
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public List<Note> Notes { get; set; }

        
    }
}
