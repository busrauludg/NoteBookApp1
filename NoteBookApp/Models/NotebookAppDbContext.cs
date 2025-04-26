using Microsoft.EntityFrameworkCore;

namespace NoteBookApp.Models
{
    public class NotebookAppDbContext :DbContext
    {
        public DbSet<Note> Notes {  get; set; }
        
        public NotebookAppDbContext(DbContextOptions<NotebookAppDbContext> options):base(options) 
        {
            
        }
    }
}
