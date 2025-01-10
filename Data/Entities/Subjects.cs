﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Subjects
    {
        public Subjects()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
            DepartmentsSubjects = new HashSet<DepartmentSubject>();

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubID { get; set; }

        [StringLength(500)]
        public string? SubjectName { get; set; }

        public string? SubjectNameEn { get; set; }

        public DateTime Period { get; set; }


        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }


        public virtual ICollection<DepartmentSubject> DepartmentsSubjects { get; set; }


        [InverseProperty("Subject")]
        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }
    }
}
