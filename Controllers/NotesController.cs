using Microsoft.AspNetCore.Mvc;
using controllermvc.Models;

namespace controllermvc.Controllers
{
    public class NotesController : Controller
    {
        
        private static List<Note> notes = new List<Note>();

        
        public IActionResult Index()
        {
            return View(notes);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(Note note)
        {
            note.Id = notes.Count + 1;
            note.CreatedDate = DateTime.Now;

            notes.Add(note);

            return RedirectToAction("Index");
        }

        
        public IActionResult Edit(int id)
        {
            var note = notes.FirstOrDefault(x => x.Id == id);
            return View(note);
        }

        
        [HttpPost]
        public IActionResult Edit(Note updatedNote)
        {
            var note = notes.FirstOrDefault(x => x.Id == updatedNote.Id);

            note.Title = updatedNote.Title;
            note.Content = updatedNote.Content;

            return RedirectToAction("Index");
        }

        
        public IActionResult Delete(int id)
        {
            var note = notes.FirstOrDefault(x => x.Id == id);
            notes.Remove(note);

            return RedirectToAction("Index");
        }
    }
}