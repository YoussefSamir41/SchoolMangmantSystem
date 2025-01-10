using Data.Entities.Procedure;
using Infrastructure.Abstracts.Procedure;
using Infrastructure.Context;
using StoredProcedureEFCore;

namespace Infrastructure.Repository.ProcedureRepository
{
    public class DepartmentStudentCountProcRepository : IDepartmentStudentCountProcRepository
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion
        #region Constructors
        public DepartmentStudentCountProcRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion
        #region Handle Functions
        public async Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcs(DepartmentStudentCountProcParameters parameters)
        {
            var rows = new List<DepartmentStudentCountProc>();
            await _context.LoadStoredProc(nameof(DepartmentStudentCountProc))
                   .AddParam(nameof(DepartmentStudentCountProcParameters.DID), parameters.DID)
                   .ExecAsync(async r => rows = await r.ToListAsync<DepartmentStudentCountProc>());
            return rows;
        }
        #endregion

    }
}
