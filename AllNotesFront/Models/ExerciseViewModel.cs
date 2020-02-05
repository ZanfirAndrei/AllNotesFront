using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllNotesFront.Models
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryViewModel Category { get; set; }
        public ScheduleViewModel? Schedule { get; set; }
        public ICollection<SeriesViewModel> Series { get; set; }
    }
}
