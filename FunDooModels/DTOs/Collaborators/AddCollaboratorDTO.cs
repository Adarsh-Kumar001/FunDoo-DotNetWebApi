using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDooModels.DTOs.Collaborators
{
    public class AddCollaboratorDTO
    {
        [Required]
        [EmailAddress]
        public string CollaboratorEmail { get; set; } = string.Empty;

        [Required]
        public int NoteId { get; set; }
    }
}
