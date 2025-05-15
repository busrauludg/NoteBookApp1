using Microsoft.EntityFrameworkCore;
using NoteBookApp.Models;

namespace NoteBookApp.Infrastructure.Data
{
    public class NotebookAppDbContext :DbContext
    {

        // DbContext constructor'ı doğru şekilde tanımlandı.
        public NotebookAppDbContext(DbContextOptions<NotebookAppDbContext> options) 
           : base(options)
        {
        }        
        public DbSet<Note> Notes {  get; set; }

    }
}
