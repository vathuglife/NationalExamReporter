using System;
using System.Collections.Generic;

namespace NationalExamReporter.Entities
{
    public partial class Score
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public float? Score1 { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
