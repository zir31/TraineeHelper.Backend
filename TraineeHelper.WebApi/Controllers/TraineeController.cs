using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TraineeHelper.Application.LearningSessions.Commands.CreateLearningSession;
using TraineeHelper.Application.LearningSessions.Commands.DeleteLearnignSession;
using TraineeHelper.Application.LearningSessions.Commands.UpdateLearningSession;
using TraineeHelper.Application.LearningSessions.Queries.GetLearningSessionDetails;
using TraineeHelper.Application.LearningSessions.Queries.GetLearningSessionList;
using TraineeHelper.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TraineeHelper.Application.LearningSessions.Commands.CreateSkill;
using TraineeHelper.Domain;
using MediatR;

namespace TraineeHelper.WebApi.Controllers;

[Route("api/[controller]")]
public class TraineeController : BaseController
{
    private readonly IMapper _mapper;

    public TraineeController(IMapper mapper) : base()
    {
        _mapper = mapper;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<int>> CreateLearningSession([FromBody] CreateLearningSessionDTO createLearningSessionDTO)
    {
        var command = _mapper.Map<CreateLearningSessionCommand>(createLearningSessionDTO);
        command.Trainee = new Trainee("Bob",new Technology() { Name = "Default Tech"}, null);
        command.Trainee.Id = TraineeId;

        var lsId = await Mediator.Send(command);
        return Ok(lsId);
    }
    //TODO summary
    [HttpPut]
    [Authorize]
    public async Task<ActionResult> UpdateLearningSession([FromBody] UpdateLearningSessionDTO updateLearningSessionDTO)
    {
        //var sampleMentor = new Mentor() { Id = Guid.NewGuid(), FullName = "Alex" };
        //var createLearningSessionDTO = new CreateLearningSessionDTO() { SkillsToLearn = personalSkills };
        var command = _mapper.Map<UpdateLearningSessionCommand>(updateLearningSessionDTO);
       //command.Trainee = new Trainee("Bob", new Technology() { Name = "Default Tech" }, null);
       // command.Trainee.Id = TraineeId;

        var lsId = await Mediator.Send(command);
        return Ok(lsId);
    }
}
