using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp2.Model;
using NotesApp2.Repositories;
using NotesApp2.Services;

namespace NotesApp2.Pages.Notes
{
    public class EditModel : PageModel
    {
        public readonly NotesRepository _notesRepository;
        private readonly UserService _userService;

        public EditModel(NotesRepository notesRepository, UserService userService)
        {
            _notesRepository = notesRepository;
            _userService = userService;

        }
        [BindProperty]
        public Note Note { get; set; }

        public void OnGet(int id)
        {
            Note = _notesRepository.GetNote(id);
        }

        public IActionResult OnPost()
        {
            Note.NotesApp2UserId = _userService.GetUserId();
            ModelState["Note.NotesApp2UserId"].ValidationState = ModelValidationState.Valid;
            if (ModelState.IsValid)
            {
                var noteFromDb = _notesRepository.GetNote(Note.Id);

                noteFromDb.Title = Note.Title;
                noteFromDb.Content = Note.Content;

                _notesRepository.UpdateNote(noteFromDb);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }







            
        }

    }
}
