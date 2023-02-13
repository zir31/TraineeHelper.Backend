using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TraineeHelper.WebApi.Models;
using MediatR;
using TraineeHelper.Application.Commands;

namespace TraineeHelper.WebApi.Controllers;

[Route("api/[controller]")]
public class MentorController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public MentorController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    /// <summary>
    /// Create Skill entity
    /// </summary>
    /// <param name="createSkillDTO">DTO for creation</param>
    /// <returns><see cref="ActionResult"/></returns>
    /// <remarks>
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<int>> CreateSkill([FromBody] CreateSkillDTO createSkillDTO)
    {
        var command = _mapper.Map<CreateSkillCommand>(createSkillDTO);
        //command.Mentor.Id = TraineeId;

        var lsId = await _mediator.Send(command);
        return Ok(lsId);
    }
}
