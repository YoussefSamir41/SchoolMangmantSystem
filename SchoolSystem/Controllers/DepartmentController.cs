using Core.Features.Department.Queries.Models;
using Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BaseController;

namespace SchoolSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.DepartmentRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await mediator.Send(new GetDepartmentByIdQuery(id));
            return NewResult(response);
        }

        [HttpGet(Router.DepartmentRouting.GetDepartmentStudentsCount)]
        public async Task<IActionResult> GetDepartmentStudentsCount()
        {
            return NewResult(await mediator.Send(new GetDepartmentStudentListCountQuery()));
        }

        [HttpGet(Router.DepartmentRouting.GetDepartmentStudentsCountById)]
        public async Task<IActionResult> GetDepartmentStudentsCountById([FromRoute] int id)
        {
            return NewResult(await mediator.Send(new GetDepartmentStudentCountByIDQuery() { DID = id }));
        }

    }
}
