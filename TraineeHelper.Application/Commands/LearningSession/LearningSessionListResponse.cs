using TraineeHelper.Domain.Entities;
public record LearningSessionListResponse
{
    public IEnumerable<LearningSession> LearningSessions { get; set; }
}
