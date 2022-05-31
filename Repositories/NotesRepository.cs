using Microsoft.EntityFrameworkCore;
using NotesApp2.Areas.Identity.Data;
using NotesApp2.Model;

namespace NotesApp2.Repositories
{
    public class NotesRepository
    {
        private readonly NotesApp2IdentityContext _context;

        public NotesRepository(NotesApp2IdentityContext context)
        {
            _context = context;
        }

        public List<Note> GetNotes()
        {
            return _context.Notes.ToList();
        }

        
        public List<Note> GetNotesByUserId(string id)
        {
            return _context.Notes.Where(note => note.NotesApp2UserId == id).ToList();
        }

        public Note GetNote(int id)
        {
            return _context.Notes.FirstOrDefault(note => note.Id == id);
        }
        public void CreateNote(Note note)
        {
            _context.Add(note);
            _context.SaveChanges();
        }

        public void UpdateNote(Note note)
        {
            _context.Entry(note).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteNote(int id)
        {
            var note = _context.Notes.FirstOrDefault(note => note.Id == id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }
        }

        

        public void CreateCategory(Category category)
        {
            
            _context.Add(category);
            _context.SaveChanges();
        }

        


    }
}
