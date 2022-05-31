using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NotesApp2.Areas.Identity.Data;
using NotesApp2.Model;

namespace NotesApp2.Areas.Identity.Data;

public class NotesApp2IdentityContext : IdentityDbContext<NotesApp2User>
{
    public NotesApp2IdentityContext(DbContextOptions<NotesApp2IdentityContext> options)
        : base(options)
    {
    }

    public DbSet<Note> Notes { get; set; }
    public DbSet<Category> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
