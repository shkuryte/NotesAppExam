using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp2.Areas.Identity.Data;
using NotesApp2.Model;
using NotesApp2.Repositories;
using NotesApp2.Services;

namespace NotesApp2.Pages.Notes
{
    public class CreateCategoryModel : PageModel
    {
        private readonly NotesRepository _repository;
        private readonly NotesApp2IdentityContext _context;


        [BindProperty]
        public Category Category { get; set; }
        public Note Note { get; set; }

        public List<Category> Categories { get; set; }

        public CreateCategoryModel(NotesRepository repository, NotesApp2IdentityContext context)
        {

            _repository = repository;
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            ModelState["Category.Notes"].ValidationState = ModelValidationState.Valid;
            
            if (ModelState.IsValid)
            {
               
                _repository.CreateCategory(Category);

                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
