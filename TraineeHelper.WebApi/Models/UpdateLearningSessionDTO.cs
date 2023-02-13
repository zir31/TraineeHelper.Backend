using AutoMapper;
using TraineeHelper.Application.Commands;
using TraineeHelper.Domain.Entities;
using TraineeHelper.Domain.Status;

namespace TraineeHelper.WebApi.Models;

public class UpdateLearningSessionDTO
{
    //public Trainee Trainee { get; set; }
    public List<Guid> SkillsLearnedIds { get; set; }
    public LearningSessionState LearningSessionState { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<int, PersonalSkill>()
            .ForMember(ps => ps.SkillId,
            opt => opt.MapFrom(i => i));
        profile.CreateMap<UpdateLearningSessionDTO, UpdateLearningSessionCommand>()
            .ForMember(lsCommand => lsCommand.LearningSessionState,
            opt => opt.MapFrom(lsDTO => lsDTO.LearningSessionState))
            .ForMember(lsCommand => lsCommand.SkillsLearnedIds,
            opt => opt.MapFrom(lsDTO => lsDTO.SkillsLearnedIds));
    }
}
