using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Instructor
    {

        public Instructor()
        {

            Ins_Subjects = new HashSet<Ins_Subject>();

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Name { get; set; }


        public string? Address { get; set; }

        public string? Position { get; set; }

        public int? SupervisorId { get; set; }

        public decimal? Salary { get; set; }



        public int DID { get; set; }

        [ForeignKey(nameof(DID))]
        public Department? department { get; set; }

        //public Department? departmentManager { get; set; }

        //[ForeignKey(nameof(SupervisorId))]

        //[InverseProperty("Instructors")]

        //public Instructor Supervisoir { get; set; }
        //[InverseProperty("Supervisoir")]
        //public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }

    }
}
