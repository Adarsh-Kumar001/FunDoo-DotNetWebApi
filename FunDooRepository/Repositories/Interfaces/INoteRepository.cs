using FunDooRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FunDooRepository.Repositories.Interfaces
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetNotesByUser(int userId);
        Note GetById(int noteId, int userId);
        Note Add(Note note);
        void Update(Note note);
        void Delete(Note note);
    }
}
