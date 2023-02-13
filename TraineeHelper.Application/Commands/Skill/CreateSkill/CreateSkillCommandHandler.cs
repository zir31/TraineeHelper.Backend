using AutoMapper;
using MediatR;
using TraineeHelper.Domain.Contracts;
using TraineeHelper.Domain.Entities;
using TraineeHelper.Persistence.Abstractions;

namespace TraineeHelper.Application.Commands;
public class CreateSkillCommandHandler
    : IRequestHandler<CreateSkillCommand, SkillResponse>
{
    //private readonly ILearningSessionsDbContext _dbContext;
    private readonly ICommandRepository<Skill, Guid> _skillRepository;
    private readonly IQueryRepository<Technology, Guid> _techRepository;
    private readonly IMapper _mapper;
    public CreateSkillCommandHandler(ICommandRepository<Skill, Guid> skillRepository, IQueryRepository<Technology, Guid> techRepository,
        IMapper mapper)
    {
        _skillRepository = skillRepository;
        _techRepository = techRepository;
        _mapper = mapper;
    }


    public async Task<SkillResponse> Handle(CreateSkillCommand command,
        CancellationToken cancellationToken)
    {
        var tech = await _techRepository.FirstOrDefaultAsync(tech => tech.Id == command.TechnologyId);
        if (tech == null)
            throw new ArgumentException("Technology doesn't exist");

        var skill = new Skill(command.SkillName, tech);
        //await _dbContext.Skills.AddAsync(skill, cancellationToken);
        //await _dbContext.SaveChangesAsync(cancellationToken);
        var response = await _skillRepository.AddAsync(skill, cancellationToken);
        await _skillRepository.SaveChangesAsync(cancellationToken);
        //return skill.Id;
        return _mapper.Map<SkillResponse>(response);
    }
}
