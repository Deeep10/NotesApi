using Microsoft.AspNetCore.Mvc;
using NotesApi.Models;

namespace NotesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private static readonly List<NoteItem> Notes = new()
    {
        new NoteItem
        {
            Id = 1,
            Title = "1st Note",
            Content = "Bikes",
            ReadOrNot = false
        },
        new NoteItem
        {
            Id = 2,
            Title = "2nd Notes",
            Content = "Cars",
            ReadOrNot = false
        }
    };

        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(Notes);
        }

        [HttpPost]
        public IActionResult CreateNote(NoteItem note)
        {
            note.Id = Notes.Count + 1;

            Notes.Add(note);

            return CreatedAtAction(
                nameof(note),
                new { id = note.Id },
                note);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateNote(int id, NoteItem updatedNote)
        {
            var note = Notes.FirstOrDefault(x => x.Id == id);

            if (note == null)
            {
                return NotFound();
            }

            note.Title = updatedNote.Title;
            note.Content = updatedNote.Content;
            note.ReadOrNot = updatedNote.ReadOrNot;

            return Ok(note);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            var note = Notes.FirstOrDefault(x => x.Id == id);

            if (note == null)
            {
                return NotFound();
            }

            Notes.Remove(note);

            return NoContent();
        }
    }
}
