using System;
using AutoMapper;
using MediatR;
using TraineeHelper.Domain.Contracts;
using TraineeHelper.Domain.Entities;
using TraineeHelper.Persistence.Abstractions;

namespace TraineeHelper.Application.Commands;
//TODO+ response from int to generic
public class CreateLearningSessionCommandHandler
    : IRequestHandler<CreateLearningSessionCommand, LearningSessionResponse>
{
    //TODO+ repo instead of dbcontext
    //private readonly ILearningSessionsDbContext _dbContext;
    private readonly ICommandRepository<LearningSession, Guid> _lsRepository;
    private readonly IQueryRepository<User, Guid> _userRepository;
    private readonly IQueryRepository<Skill, Guid> _skillRepository;
    private readonly IMapper _mapper;
    //public CreateLearningSessionCommandHandler(ILearningSessionsDbContext dbContext) =>
    //    _dbContext = dbContext;
    public CreateLearningSessionCommandHandler(ICommandRepository<LearningSession, Guid> lsRepository,
        IQueryRepository<User, Guid> userRepository, IQueryRepository<Skill, Guid> skillRepository, IMapper mapper)
    {
        _lsRepository = lsRepository;
        _userRepository = userRepository;
        _skillRepository = skillRepository;
        _mapper = mapper;
    }

    public async Task<LearningSessionResponse> Handle(CreateLearningSessionCommand command,
        CancellationToken cancellationToken)
    {
        var trainee = await _userRepository.FirstOrDefaultAsync(t => t.Id == command.TraineeId);
        var personalSkills = new List<PersonalSkill>();
        foreach (var skillId in command.SkillsToLearnIds)
        {//TODO+ 
            personalSkills.Add(new PersonalSkill(trainee as Trainee, _skillRepository.FirstOrDefault(s => s.Id == skillId)));

        }

        var learningSession = new LearningSession(trainee as Trainee, personalSkills);
        //await _dbContext.LearningSessions.AddAsync(learningSession, cancellationToken);
        //await _dbContext.SaveChangesAsync(cancellationToken);
        var response = await _lsRepository.AddAsync(learningSession, cancellationToken);
        await _lsRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<LearningSessionResponse>(response);
    }
}
