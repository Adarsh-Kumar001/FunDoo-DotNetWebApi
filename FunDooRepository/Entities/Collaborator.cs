using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDooRepository.Entities
{
    public class Collaborator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CollaboratorId { get; set; }

        [Required]
        [EmailAddress]
        public string CollaboratorEmail { get; set; } = string.Empty;

        [ForeignKey(nameof(Note))]
        public int NoteId { get; set; }

        // Navigation
        public Note Note { get; set; } = null!;
    }
}
