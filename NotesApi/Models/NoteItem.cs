namespace NotesApi.Models
{
    public class NoteItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? highlightLine { get; set; }
        public bool ReadOrNot { get; set; }
    }
}
