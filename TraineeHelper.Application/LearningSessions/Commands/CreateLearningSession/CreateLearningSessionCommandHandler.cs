using MediatR;
using TraineeHelper.Application.Interfaces;
using TraineeHelper.Domain;

namespace TraineeHelper.Application.LearningSessions.Commands.CreateLearningSession;
//TODO response from int to generic
public class CreateLearningSessionCommandHandler
    : IRequestHandler<CreateLearningSessionCommand, int>
{
    //TODO repo instead of dbcontext
    private readonly ILearningSessionsDbContext _dbContext;
    public CreateLearningSessionCommandHandler(ILearningSessionsDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<int> Handle(CreateLearningSessionCommand command, 
        CancellationToken cancellationToken)
    {
        var personalSkills = new List<PersonalSkill>();
        foreach (var skill in command.SkillsToLearn)
        {//TODO 
            personalSkills.Add(new PersonalSkill(command.Trainee, _dbContext.Skills.FindAsync(skill.SkillId).Result));
        }
        var learningSession = new LearningSession(command.Trainee, personalSkills);
        await _dbContext.LearningSessions.AddAsync(learningSession, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return learningSession.Id;
    }
}
