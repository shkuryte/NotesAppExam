using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp2.Areas.Identity.Data;
using NotesApp2.Model;
using NotesApp2.Repositories;
using NotesApp2.Services;

namespace NotesApp2.Pages.Notes
{
    public class CreateModel : PageModel
    {
        
        private readonly NotesRepository _repository;
        private readonly UserService _userService;



        [BindProperty]
        public Note Note { get; set; }

        public CreateModel(NotesRepository repository, UserService userService)
        {
            
            _repository = repository;
            _userService = userService;
        }

        public void OnGet()
        {
        }

        

        public IActionResult OnPost()
        {
            Note.NotesApp2UserId = _userService.GetUserId();
            ModelState["Note.NotesApp2UserId"].ValidationState = ModelValidationState.Valid;

            if (ModelState.IsValid)
            {
                
                _repository.CreateNote(Note);
                            
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
