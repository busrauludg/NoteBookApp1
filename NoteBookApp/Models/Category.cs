namespace NoteBookApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CateName { get; set; }

        // Notlarla bire-çok ilişkisi
        public ICollection<Note> Notes { get; set; }
    }
}
