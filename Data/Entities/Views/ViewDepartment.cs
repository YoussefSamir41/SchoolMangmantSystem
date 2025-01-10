using Microsoft.EntityFrameworkCore;

namespace Data.Entities.Views
{
    [Keyless]
    public class ViewDepartment
    {
        public int DID { get; set; }
        public string? DName { get; set; }

        public int StudentCount { get; set; }
    }
}
