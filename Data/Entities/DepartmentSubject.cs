using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class DepartmentSubject
    {
        
            public int Id { get; set; }
            public int DID { get; set; }
            public int SubID { get; set; }

            [ForeignKey("DID")]
           
            public virtual Department? Department { get; set; }

            [ForeignKey("SubID")]
           
            public virtual Subjects? Subject { get; set; }
        
    }
}
