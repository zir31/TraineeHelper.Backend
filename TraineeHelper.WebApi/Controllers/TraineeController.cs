using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TraineeHelper.WebApi.Models;
using MediatR;
using TraineeHelper.Application.Commands;

namespace TraineeHelper.WebApi.Controllers;

[Route("api/[controller]")]
public class TraineeController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public TraineeController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    /// <summary>
    /// Create LearningSession entity
    /// </summary>
    /// <param name="createLearningSessionDTO">DTO for creation</param>
    /// <returns><see cref="ActionResult"/></returns>
    /// <remarks>
    /// Sample request
    /// {
    ///     "traineeId": "293BD878-4BE0-45EB-9BFE-B00E7D61B6A0",
    ///     "skillsToLearnIds": 
    ///     [ "3CA7F061-1E16-4258-8251-28D98AE1A5A7"]
    /// }
    /// </remarks>
    [HttpPost]
    [Authorize]
    public async Task<ActionResult> CreateLearningSession([FromBody] CreateLearningSessionDTO createLearningSessionDTO)
    {
        var command = _mapper.Map<CreateLearningSessionCommand>(createLearningSessionDTO);
        //command.Trainee = new Trainee("Bob",new Technology() { Name = "Default Tech"}, null);
        //command.Trainee.Id = TraineeId;

        var lsId = await _mediator.Send(command);
        return Ok(lsId);
    }
    //TODO summary+

    /// <summary>
    /// Update LearningSession entity
    /// </summary>
    /// <param name="updateLearningSessionDTO">DTO for update</param>
    /// <returns><see cref="ActionResult"/></returns>
    /// <remarks>
    [HttpPut]
    [Authorize]
    public async Task<ActionResult> UpdateLearningSession([FromBody] UpdateLearningSessionDTO updateLearningSessionDTO)
    {
        //var sampleMentor = new Mentor() { Id = Guid.NewGuid(), FullName = "Alex" };
        //var createLearningSessionDTO = new CreateLearningSessionDTO() { SkillsToLearn = personalSkills };
        var command = _mapper.Map<UpdateLearningSessionCommand>(updateLearningSessionDTO);
       //command.Trainee = new Trainee("Bob", new Technology() { Name = "Default Tech" }, null);
       // command.Trainee.Id = TraineeId;

        var lsId = await _mediator.Send(command);
        return Ok(lsId);
    }
}
