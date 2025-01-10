using Data.Entities;
using Infrastructure.Abstracts;
using Infrastructure.Context;
using Infrastructure.InfrastructureBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class StudentRepository : GenericRepositoryAsync<Student> , IStudentRepository
    {
        private readonly DbSet<Student> studentsRepository;

        public StudentRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            studentsRepository = dbContext.Set<Student>(); //students = DbContext.Student 
            
        }


        #region Handles Function
        public async Task<List<Student>> GetStudentsAsync()
        {
           return await studentsRepository.Include(S=>S.Department).ToListAsync();
        }
       

        #endregion
    }
}
