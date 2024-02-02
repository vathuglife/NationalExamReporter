using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NationalExamReporter.Entities
{
    public partial class Subject
    {
        public Subject()
        {
            Scores = new HashSet<Score>();
        }
        
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Score> Scores { get; set; }
    }
}
