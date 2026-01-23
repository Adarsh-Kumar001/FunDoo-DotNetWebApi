using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunDooModels.DTOs.Labels;

namespace FunDooModels.DTOs.Notes
{
  
        public class NoteResponseDTO
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public bool IsPinned { get; set; }
            public bool IsArchived { get; set; }
            public bool IsDeleted { get; set; }
            public string Color { get; set; }

            public List<LabelDTO> Labels { get; set; } = new();
        }

        public class LabelDTO
        {
            public int LabelId { get; set; }
            public string LabelName { get; set; }
        }


}
