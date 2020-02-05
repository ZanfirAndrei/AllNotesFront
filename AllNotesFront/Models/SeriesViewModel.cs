﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllNotesFront.Models
{
    public class SeriesViewModel
    {
        public int Id { get; set; }
        public int Repeats { get; set; }
        public float Weights { get; set; }
        public int ExerciseId { get; set; }
    }
}
