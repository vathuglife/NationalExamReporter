using System;
using System.Collections.Generic;

namespace NationalExamReporter.Entities
{
    public partial class SchoolYear
    {
        public SchoolYear()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ExamYear { get; set; }
        public bool? Status { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
