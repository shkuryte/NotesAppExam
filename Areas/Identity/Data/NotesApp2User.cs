using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NotesApp2.Model;

namespace NotesApp2.Areas.Identity.Data;

// Add profile data for application users by adding properties to the NotesApp2User class
public class NotesApp2User : IdentityUser
{
    public List<Note> Notes { get; set; }

    public List<Category> Categories { get; set; }

}

