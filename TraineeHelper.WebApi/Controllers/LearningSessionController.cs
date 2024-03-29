﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TraineeHelper.Application.LearningSessions.Commands.CreateLearningSession;
using TraineeHelper.Application.LearningSessions.Commands.DeleteLearnignSession;
using TraineeHelper.Application.LearningSessions.Commands.UpdateLearningSession;
using TraineeHelper.Application.LearningSessions.Queries.GetLearningSessionDetails;
using TraineeHelper.Application.LearningSessions.Queries.GetLearningSessionList;
using TraineeHelper.WebApi.Models;

namespace TraineeHelper.WebApi.Controllers;

[Route("api/[controller] ")]
public class LearningSessionController : BaseController
{
    private readonly IMapper _mapper;
    public LearningSessionController(IMapper mapper)
    {
        _mapper = mapper;
    }
    [HttpGet]
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
    public async Task<ActionResult<LearningSessionDetailsVm>> Get(Guid id)
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
    public async Task<ActionResult<Guid>> Create([FromBody] CreateLearningSessionDTO createLSDTO)
    {
        var command = _mapper.Map<CreateLearningSessionCommand>(createLSDTO);
        command.TraineeId = TraineeId;
        var lsId = await Mediator.Send(command);
        return Ok(lsId);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLearningSessionDTO updateLSDTO)
    {
        var command = _mapper.Map<UpdateLearningSessionCommand>(updateLSDTO);
        command.TraineeId = TraineeId;
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteLearningSessionCommand()
        {
            Id = id,
            TraineeId = TraineeId
        };
        await Mediator.Send(command);
        return NoContent();
    }
}
