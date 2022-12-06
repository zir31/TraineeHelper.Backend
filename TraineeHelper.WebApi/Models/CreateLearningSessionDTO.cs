using AutoMapper;
using TraineeHelper.Application.Common.Mappings;
using TraineeHelper.Application.LearningSessions.Commands.CreateLearningSession;

namespace TraineeHelper.WebApi.Models;

public class CreateLearningSessionDTO : IMapWith<CreateLearningSessionCommand>
{
    public string TraineeName { get; set; }
    public Dictionary<string, bool> SkillsLearned { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateLearningSessionDTO, CreateLearningSessionCommand>()
            .ForMember(lsCommand => lsCommand.TraineeName,
            opt => opt.MapFrom(lsDTO => lsDTO.TraineeName))
            .ForMember(lsCommand => lsCommand.SkillsLearned,
            opt => opt.MapFrom(lsDTO => lsDTO.SkillsLearned));
    }
}
