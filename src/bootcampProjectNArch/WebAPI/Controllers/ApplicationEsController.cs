using Application.Features.ApplicationEs.Commands.Create;
using Application.Features.ApplicationEs.Commands.Delete;
using Application.Features.ApplicationEs.Commands.Update;
using Application.Features.ApplicationEs.Queries.GetById;
using Application.Features.ApplicationEs.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationEsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateApplicationECommand createApplicationECommand)
    {
        CreatedApplicationEResponse response = await Mediator.Send(createApplicationECommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateApplicationECommand updateApplicationECommand)
    {
        UpdatedApplicationEResponse response = await Mediator.Send(updateApplicationECommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedApplicationEResponse response = await Mediator.Send(new DeleteApplicationECommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdApplicationEResponse response = await Mediator.Send(new GetByIdApplicationEQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListApplicationEQuery getListApplicationEQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListApplicationEListItemDto> response = await Mediator.Send(getListApplicationEQuery);
        return Ok(response);
    }
}
