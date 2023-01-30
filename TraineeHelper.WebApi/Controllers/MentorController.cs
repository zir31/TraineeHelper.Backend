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
public class MentorController : BaseController
{
    private readonly IMapper _mapper;
    public MentorController(IMapper mapper)
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

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<int>> CreateSkill(string  skillName, Technology technology)
    {
        var sampleMentor = new Mentor() { Id = Guid.NewGuid(), FullName = "Alex" };
        var createSkillDTO = new CreateSkillDTO() { SkillName = skillName , Mentor = sampleMentor, Technology = technology};
        var command = _mapper.Map<CreateSkillCommand>(createSkillDTO);
        //command.Mentor.Id = TraineeId;

        var lsId = await Mediator.Send(command);
        return Ok(lsId);
    }
}
