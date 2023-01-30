using AutoMapper;
using TraineeHelper.Application.Common.Mappings;
using TraineeHelper.Application.LearningSessions.Commands.CreateLearningSession;
using TraineeHelper.Domain;

namespace TraineeHelper.WebApi.Models;

public class CreateLearningSessionDTO : IMapWith<CreateLearningSessionCommand>
{
    //public Trainee Trainee{ get; set; }
    public List<int> SkillsToLearn { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<int, PersonalSkill>()
            .ForMember(ps => ps.SkillId,
            opt => opt.MapFrom(i => i));
        profile.CreateMap<CreateLearningSessionDTO, CreateLearningSessionCommand>()
            //.ForMember(lsCommand => lsCommand.Trainee,
            //opt => opt.MapFrom(lsDTO => lsDTO.Trainee))
            .ForMember(lsCommand => lsCommand.SkillsToLearn,
            opt => opt.MapFrom(lsDTO => lsDTO.SkillsToLearn));
    }
}
