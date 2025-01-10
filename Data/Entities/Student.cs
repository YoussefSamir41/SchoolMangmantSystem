﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Student
    {
        public Student()
        {
            StudentSubject = new HashSet<StudentSubject>();
        }

        [Key]
     
        public int StudID { get; set; }

     

        public string? Name { get; set; }

        [StringLength(500)]
        public string? Address { get; set; }

        [StringLength(500)]
        public string? Phone { get; set; }

        public int? DID { get; set; }

        [ForeignKey("DID")]
       
        public virtual Department? Department { get; set; }

       
        public virtual ICollection<StudentSubject> StudentSubject { get; set; }
    }
}
