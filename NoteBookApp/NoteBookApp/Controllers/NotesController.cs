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
        public async Task<IActionResult> Create([Bind("Title,Content")] Note note)
        {
            if (ModelState.IsValid)
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
            var notes = await _context.Notes
            .OrderByDescending(n => n.CreatedDate)
            .ToListAsync();


            return View(notes);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var note = await _context.Notes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmend(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: Notes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            // Notu veritabanından bulalım.
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound(); // Not bulunamazsa 404 döneriz.
            }

            // Bulunan notu düzenleme sayfasında gösterelim.
            return View(note);
        }

        // POST: Notes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Note note)
        {
            if (id != note.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var existingNote = await _context.Notes.AsNoTracking().FirstOrDefaultAsync(n => n.Id == id);
                    if (existingNote == null) return NotFound();

                    note.CreatedDate = existingNote.CreatedDate; // ✳️ Eski tarih korunuyor
                    note.UpdateDate = DateTime.Now;

                    _context.Update(note);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Notes.Any(n => n.Id == note.Id)) return NotFound();
                    throw;
                }
            }
            return View(note);
        }



        public async Task<IActionResult> Details(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
                return NotFound();
            return View(note);

        }



    }
}
