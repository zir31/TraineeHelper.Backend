using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TraineeHelper.WebApi.Models;
using MediatR;
using TraineeHelper.Persistence.Abstractions;
using TraineeHelper.Domain.Entities;
using System.Security.Claims;
using TraineeHelper.Application.Commands;
using TraineeHelper.Application.Queries;

namespace TraineeHelper.WebApi.Controllers;

[Route("api/[controller]")]
public class LearningSessionController : ControllerBase
{
    public LearningSessionController(IMapper mapper, IMediator mediator, IQueryRepository<User, Guid> queryRepository)
    {
        _mapper = mapper;
        _mediator = mediator;
        _userRepo = queryRepository;
    }

    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IQueryRepository<User, Guid> _userRepo;
    //private readonly User _user;
    internal Guid UserId => !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User?.FindFirstValue("sub"));

    /// <summary>
    /// Get all LearningSession entities
    /// </summary>
    /// <returns><see cref="ActionResult"/></returns>
    /// <remarks>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<LearningSessionListResponse>> GetAll()
    {
        var query = new GetLearningSessionsListQuery()
        {
            TraineeId = UserId
        };
        //var vm = await Mediator.Send(query);
        var vm = await _mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Get specific LearningSession entity
    /// </summary>
    /// <param name="id">Id of LearningSession</param>
    /// <returns><see cref="ActionResult"/></returns>
    /// <remarks>
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<LearningSessionResponse>> Get(Guid id)
    {
        var query = new GetLearningSessionDetailsQuery()
        {
            TraineeId = UserId,
            Id = id
        };
        //var vm = await Mediator.Send(query);
        var vm = await _mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Create LearningSession entity
    /// </summary>
    /// <param name="createLSDTO">DTO for create</param>
    /// <returns><see cref="ActionResult"/></returns>
    /// <remarks>
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<LearningSessionResponse>> Create([FromBody] CreateLearningSessionDTO createLSDTO)
    {
        //createLSDTO.TraineeId = UserId;
        var command = _mapper.Map<CreateLearningSessionCommand>(createLSDTO);
        

        //var lsId = await Mediator.Send(command);
        var lsId = await _mediator.Send(command);
        return Ok(lsId);
    }

    /// <summary>
    /// Update LearningSession entity
    /// </summary>
    /// <param name="updateLSDTO">DTO for update</param>
    /// <returns><see cref="ActionResult"/></returns>
    /// <remarks>
    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] UpdateLearningSessionDTO updateLSDTO)
    {
        var command = _mapper.Map<UpdateLearningSessionCommand>(updateLSDTO);
        //command.Trainee.Id = UserId;
        //await Mediator.Send(command);
        var lsId = await _mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Delete LearningSession entity
    /// </summary>
    /// <param name="id">Id of LearningSession to delete</param>
    /// <returns><see cref="ActionResult"/></returns>
    /// <remarks>
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteLearningSessionCommand()
        {
            Id = id,
            TraineeId = UserId
        };
        //await Mediator.Send(command);
        var lsId = await _mediator.Send(command);
        return NoContent();
    }
}
