using AutoMapper;
using TraineeHelper.Application.Common.Mappings;
using TraineeHelper.Application.LearningSessions.Commands.CreateLearningSession;
using TraineeHelper.Application.LearningSessions.Commands.UpdateLearningSession;

namespace TraineeHelper.WebApi.Models;

public class UpdateLearningSessionDTO : IMapWith<UpdateLearningSessionCommand>
{
    public string TraineeName { get; set; }
    public Dictionary<string, bool> SkillsLearned { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateLearningSessionDTO, UpdateLearningSessionCommand>()
            .ForMember(lsCommand => lsCommand.TraineeName,
            opt => opt.MapFrom(lsDTO => lsDTO.TraineeName))
            .ForMember(lsCommand => lsCommand.SkillsLearned,
            opt => opt.MapFrom(lsDTO => lsDTO.SkillsLearned));
    }
}
