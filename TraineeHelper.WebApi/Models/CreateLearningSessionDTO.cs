namespace TraineeHelper.WebApi.Models;

public class CreateLearningSessionDTO
{
    public Guid TraineeId{ get; set; }
    public List<Guid> SkillsToLearnIds { get; set; }
}
