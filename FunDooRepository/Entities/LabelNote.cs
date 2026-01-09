using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDooRepository.Entities
{
    public class LabelNote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NoteId { get; set; }

        [Required]
        public int LabelId { get; set; }

        [ForeignKey("NoteId")]
        public Note Note { get; set; }

        [ForeignKey("LabelId")]
        public Label Label { get; set; }
    }
}
