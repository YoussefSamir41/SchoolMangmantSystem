using Core.Features.Students.Commands.Models;
using Core.Features.Students.Queries.Models;
using Data.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BaseController;

namespace SchoolSystem.Controllers
{

    [ApiController]
    [Authorize]
    public class StudentController : AppControllerBase
    {


        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudent()
        {
            var response = await mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }




        [HttpGet(Router.StudentRouting.Paginated)]
        public async Task<IActionResult> GetPaginatedStudent([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(response);
        }

        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddStudentCommand command)
        {
            var response = await mediator.Send(command);
            return NewResult(response);
        }


        [HttpPut(Router.StudentRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditStudentCommand command)
        {
            var response = await mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var response = await mediator.Send(new DeleteStudentCommand(id));
            return NewResult(response);
        }


    }
}
