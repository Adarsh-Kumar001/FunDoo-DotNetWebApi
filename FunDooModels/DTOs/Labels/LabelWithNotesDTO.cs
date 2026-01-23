using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDooModels.DTOs.Labels
{
    public class LabelWithNotesDTO
    {
        public int LabelId { get; set; }
        public string LabelName { get; set; } = string.Empty;
        public List<int> NoteIds { get; set; } = new();
    }

}
