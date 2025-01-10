namespace Data.Entities.Procedure
{
    public class DepartmentStudentCountProc
    {
        public int DID { get; set; }
        public string? Dname { get; set; }

        public int StudentCount { get; set; }
    }
    public class DepartmentStudentCountProcParameters
    {
        public int DID { get; set; } = 0;
    }
}
