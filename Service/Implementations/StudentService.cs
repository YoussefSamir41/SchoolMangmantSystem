using Data.Entities;
using Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using Service.Abstracts;
using System.Linq.Expressions;

namespace Service.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }


        #region Handle Function
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await studentRepository.GetStudentsAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {

            //var srudent = await studentRepository.GetByIdAsync(id);
            //return srudent;


            var student = studentRepository.GetTableNoTracking()
                .Include(x => x.Department)
                .Where(s => s.StudID == id)
                .FirstOrDefault();

            return student;
        }

        public async Task<string> AddAsync(Student student)
        {
            await studentRepository.AddAsync(student);
            return "Success";
        }

        public async Task<bool> IsNameExistExccludeSelf(string name, int id)
        {
            var student = await studentRepository.GetTableAsTracking()
                .Where(s => s.Name == name && !s.StudID.Equals(id))
                .FirstOrDefaultAsync();

            if (student == null)
                return false;
            return true;

        }

        public async Task<string> EditAsync(Student student)
        {
            await studentRepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> RemoveAsync(Student student)
        {
            var transaction = studentRepository.BeginTransaction();
            try
            {
                await studentRepository.DeleteAsync(student);
                await transaction.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {

                transaction.Rollback();
                return "Failed";

            }

        }

        public IQueryable<Student> GetStudentQuerable()
        {
            return studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
        }

        public IQueryable<Student> SearchByName(string search)
        {
            return studentRepository.GetTableNoTracking().Where(x => x.Name.Contains(search));
        }

        public IQueryable<Student> OrderByName(Expression<Func<Student, string>> order)
        {
            return studentRepository.GetTableNoTracking().OrderBy(order);
        }

        public IQueryable<Student> GetStudentByDepartmentIdQuerable(int DID)
        {
            return studentRepository.GetTableNoTracking().Where(x => x.DID == DID).AsQueryable();
        }



        #endregion

    }
}
