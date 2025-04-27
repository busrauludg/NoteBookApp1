using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteBookApp.Models;

namespace NoteBookApp.Controllers
{
    public class NotesController : Controller
    {
        private readonly NotebookAppDbContext _context;

        public NotesController(NotebookAppDbContext context)
        {
            _context = context;
        }
        
        //Get tir
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Content,Category")]Note note)
        {
            if(ModelState.IsValid)
            {
                _context.Add(note);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Note saved successfully.Şimdi başarıyla ındexe gidebilirsin";
                return RedirectToAction(nameof(Create));
            }
            return View(note);
        }

        public async Task<IActionResult> Index()
        {
            var notes=await _context.Notes.ToListAsync();
            return View(notes);
        }
        public async Task<IActionResult>Delete(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var note=await _context.Notes 
                .FirstOrDefaultAsync(m=>m.Id==id);
            if(note==null)
            {
                return NotFound();
            }
            return View(note);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>DeleteConfirmend(int id)
        {
            var note=await _context.Notes.FindAsync(id);
            if(note==null)
            {
                return NotFound();
            }
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
