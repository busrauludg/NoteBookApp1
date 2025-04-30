namespace NoteBookApp.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = new DateTime(
         DateTime.Now.Year,
         DateTime.Now.Month,
         DateTime.Now.Day,
         DateTime.Now.Hour,
         DateTime.Now.Minute,
         DateTime.Now.Second
        );

        public DateTime? UpdateDate { get; set; }//// Nullable olmalı, çünkü başlangıçta update yapılmamış olabilir.
         // Category ilişkisi                                          // Category ilişkisi
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
