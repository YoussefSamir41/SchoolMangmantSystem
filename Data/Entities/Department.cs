using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Department
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }



        [StringLength(200)]
        public string? DName { get; set; }

        public int InsManager { get; set; }

        public virtual ICollection<Student> Students { get; set; }


        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; }
        //[ForeignKey(nameof(InsManager))]
        //[InverseProperty("departmentManager")]
        //public virtual Instructor Instructor { get; set; }
    }
}
