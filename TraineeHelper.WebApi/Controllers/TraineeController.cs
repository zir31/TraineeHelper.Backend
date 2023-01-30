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

namespace TraineeHelper.WebApi.Controllers;

[Route("api/[controller]/[action]")]
public class TraineeController : BaseController
{
    private readonly IMapper _mapper;
    public TraineeController(IMapper mapper)
    {
        _mapper = mapper;
    }
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<LearningSessionListVm>> GetAll()
    {
        var query = new GetLearningSessionsListQuery()
        {
            TraineeId = TraineeId
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<LearningSessionDetailsVm>> Get(int id)
    {
        var query = new GetLearningSessionDetailsQuery()
        {
            TraineeId = TraineeId,
            Id = id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    //[HttpGet]
    //[Authorize]
    //public async Task<ActionResult<List<RequiredSkill>>> GetRequiredSkills()
    //{
    //    var query = new GetRequiredSkillsQuery()
    //    {
    //        TraineeId = TraineeId,
    //        Id = id
    //    }

    //}

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<int>> CreateLearningSession([FromBody] CreateLearningSessionDTO createLearningSessionDTO)
    {
        //var sampleMentor = new Mentor() { Id = Guid.NewGuid(), FullName = "Alex" };
        //var createLearningSessionDTO = new CreateLearningSessionDTO() { SkillsToLearn = personalSkills };
        var command = _mapper.Map<CreateLearningSessionCommand>(createLearningSessionDTO);
        command.Trainee = new Trainee("Bob",new Technology() { Name = "Default Tech"}, null);
        command.Trainee.Id = TraineeId;

        var lsId = await Mediator.Send(command);
        return Ok(lsId);
    }
}
