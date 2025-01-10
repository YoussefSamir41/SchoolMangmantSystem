using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class StudentSubject
    {
        public int Id { get; set; }
        public int StudID { get; set; }
        public int SubID { get; set; }
        public decimal? grade { get; set; }

        [ForeignKey("StudID")]
       
        public virtual Student? Student { get; set; }

        [ForeignKey("SubID")]
       
        public virtual Subjects? Subject { get; set; }

    }
}
