using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NationalExamReporter.Entities
{
    public partial class Student
    {
        public Student()
        {
            Scores = new HashSet<Score>();
        }
        
        public int Id { get; set; }
        public int SchoolYearId { get; set; }
        public string StudentCode { get; set; }
        public bool? Status { get; set; }
        public virtual SchoolYear SchoolYear { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
            = new List<Score>();
    }
}
