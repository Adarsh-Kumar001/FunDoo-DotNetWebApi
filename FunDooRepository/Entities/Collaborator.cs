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
        [MaxLength(150)]
        public string CollaboratorEmail { get; set; } = string.Empty;

        [Required]
        public int NoteId { get; set; }

        [Required]
        public int OwnerUserId { get; set; }   // who owns the note

        // Navigation
        public Note Note { get; set; } = null!;
        public User Owner { get; set; } = null!;
    }
}
