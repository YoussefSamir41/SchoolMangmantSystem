using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Ins_Subject
    {

        public int Id { get; set; }
        public int InsId { get; set; }
        public int SubId { get; set; }

        [ForeignKey(nameof(InsId))]

        public Instructor? instructor { get; set; }

        [ForeignKey(nameof(SubId))]

        public Subjects? Subject { get; set; }
    }
}
