using Microsoft.EntityFrameworkCore;
using NoteBookApp.Infrastructure.Data;
using NoteBookApp.Models;
using Repositories.Concrete;
using Repositories.Interfaces; // INoteRepository'nin bulunduðu namespace



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NotebookAppDbContext>(options =>
{
    options.UseSqlite(
        builder.Configuration.GetConnectionString("sqlconnection"),
        b => b.MigrationsAssembly("Infrastructure")  // Burada migrations assembly olarak Infrastructure belirtiyoruz
    );
});


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<INoteRepository, NoteRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Repositoryyi DI'ye ekliyoruz

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
