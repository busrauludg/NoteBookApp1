using NoteBookApp.Infrastructure.Data;
using NoteBookApp.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositories.Concrete
{
    public class NoteRepository :INoteRepository
    {
        private readonly NotebookAppDbContext _context;

        public NoteRepository(NotebookAppDbContext context)
        {
            _context = context;
        }
        public List<Note> GetAll()
        {
            return _context.Notes.ToList(); // Veritabanından alıyoruz
        }

        public Note GetById(int id)
        {
            return _context.Notes.FirstOrDefault(n => n.Id == id);
        }

        public void Add(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges(); // Veritabanına kaydet
        }

        public void Update(Note note)
        {
            _context.Notes.Update(note);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var note = _context.Notes.FirstOrDefault(n => n.Id == id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }
        }

    }
}
