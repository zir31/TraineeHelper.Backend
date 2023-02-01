using AutoMapper;
using TraineeHelper.Application.Common.Mappings;
using TraineeHelper.Application.LearningSessions.Commands.CreateLearningSession;
using TraineeHelper.Application.LearningSessions.Commands.UpdateLearningSession;
using TraineeHelper.Domain;
using TraineeHelper.Domain.Status;

namespace TraineeHelper.WebApi.Models;

public class UpdateLearningSessionDTO : IMapWith<UpdateLearningSessionCommand>
{
    //public Trainee Trainee { get; set; }
    public List<int> SkillsLearned { get; set; }
    public LearningSessionState LearningSessionState { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<int, PersonalSkill>()
            .ForMember(ps => ps.SkillId,
            opt => opt.MapFrom(i => i));
        profile.CreateMap<UpdateLearningSessionDTO, UpdateLearningSessionCommand>()
            .ForMember(lsCommand => lsCommand.LearningSessionState,
            opt => opt.MapFrom(lsDTO => lsDTO.LearningSessionState))
            .ForMember(lsCommand => lsCommand.SkillsLearned,
            opt => opt.MapFrom(lsDTO => lsDTO.SkillsLearned));
    }
}
