using Data.Entities;
using System.Linq.Expressions;

namespace Service.Abstracts
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);

        public Task<string> AddAsync(Student student);

        public Task<bool> IsNameExistExccludeSelf(string name, int id);

        public Task<string> EditAsync(Student student);
        public Task<string> RemoveAsync(Student student);

        IQueryable<Student> GetStudentQuerable();

        IQueryable<Student> GetStudentByDepartmentIdQuerable(int DID);



        IQueryable<Student> SearchByName(string name);
        IQueryable<Student> OrderByName(Expression<Func<Student, string>> order);
    }
}
