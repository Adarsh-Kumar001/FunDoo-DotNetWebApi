using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDooModels.DTOs.NoteHistory
{
    public class NoteHistoryResponseDTO
    {
        public int NoteHistoryId { get; set; }
        public int NoteId { get; set; }
        public string OldTitle { get; set; } = string.Empty;
        public string OldContent { get; set; } = string.Empty;
        public DateTime ModifiedAt { get; set; }
    }
}
