using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllNotesFront.Models
{
    public class CheckListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsComplete { get; set; }
        public ScheduleViewModel? Schedule { get; set; }
        public ICollection<CheckBoxViewModel> CheckBoxes { get; set; }
    }
}
