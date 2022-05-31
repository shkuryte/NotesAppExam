using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp2.Model;
using NotesApp2.Repositories;
using NotesApp2.Services;
using System.Security.Claims;

namespace NotesApp2.Pages.Notes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly NotesRepository _repository;

        private readonly UserService _userService;


        public List<Note> Notes { get; set; }

        public IndexModel(NotesRepository repository, UserService userService)
        {
            _repository = repository;

            _userService = userService;
        }
        public void OnGet()
        {
            var userId = _userService.GetUserId();
            
            Notes = _repository.GetNotesByUserId(userId);
        }

        public IActionResult OnPostDelete(int id)
        {
            var note = _repository.GetNote(id);
            if (note == null)
            {
                return NotFound();
            }

            _repository.DeleteNote(id);
            return RedirectToPage("Index");
        }
    }
}
