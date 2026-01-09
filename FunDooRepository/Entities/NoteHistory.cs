using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDooRepository.Entities
{
    public class NoteHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteHistoryId { get; set; }

        [ForeignKey(nameof(Note))]
        public int NoteId { get; set; }

        public string OldTitle { get; set; } = string.Empty;
        public string OldContent { get; set; } = string.Empty;

        public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Note Note { get; set; } = null!;
    }
}
