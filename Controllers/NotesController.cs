using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using controllermvc.Models;
using controllermvc.Data;

namespace controllermvc.Controllers
{
    public class NotesController : Controller
    {
        private readonly NoteDbContext _context;

        public NotesController(NoteDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var notes = await _context.Notes.ToListAsync();
            return View(notes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Note note)
        {
            note.CreatedDate = DateTime.Now;

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null) return NotFound();

            return View(note);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Note updatedNote)
        {
            var note = await _context.Notes.FindAsync(updatedNote.Id);
            if (note == null) return NotFound();

            note.Title = updatedNote.Title;
            note.Content = updatedNote.Content;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var note = await _context.Notes.FindAsync(id);

            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}