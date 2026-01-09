using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDooNotesModel
{
    public class Note
    {
        public long NoteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public bool IsArchived { get; set; }
        public bool IsTrashed { get; set; }

        public DateTime? Reminder { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }
    }
}
