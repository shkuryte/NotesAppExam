using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NotesApp2.Areas.Identity.Data;
using NotesApp2.Repositories;
using NotesApp2.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("NotesApp2IdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'NotesApp2IdentityContextConnection' not found.");


builder.Services.AddDbContext<NotesApp2IdentityContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<NotesApp2User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<NotesApp2IdentityContext>();;

builder.Services.AddTransient<NotesRepository>();
builder.Services.AddTransient<UserService>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
