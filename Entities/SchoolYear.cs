using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NationalExamReporter.Entities
{
    public partial class SchoolYear
    {
        public SchoolYear()
        {
            Students = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }
        [Column ("Name")]
        public string Name { get; set; }
        [Column ("ExamYear")]
        public int? ExamYear { get; set; }
        [Column ("Status")]
        public bool? Status { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
