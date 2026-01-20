using FunDooRepository.Entities;

public interface INoteRepository
{
    IEnumerable<Note> GetNotesByUser(int userId, bool deleted);
    Note GetById(int noteId, int userId);
    Note Add(Note note);
    void Update(Note note);
    void HardDelete(Note note);
}
