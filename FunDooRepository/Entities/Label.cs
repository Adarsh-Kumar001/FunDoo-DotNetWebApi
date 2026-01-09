using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDooRepository.Entities
{
    public class Label
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LabelId { get; set; }

        [Required]
        [MaxLength(100)]
        public string LabelName { get; set; } = string.Empty;

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        // Navigation
        public User User { get; set; } = null!;
        public ICollection<Note> Notes { get; set; } = new List<Note>();
     

        public ICollection<LabelNote> LabelNotes { get; set; }
    }
}
