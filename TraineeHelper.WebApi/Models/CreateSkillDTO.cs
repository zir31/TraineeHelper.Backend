using AutoMapper;
using TraineeHelper.Application.Common.Mappings;
using TraineeHelper.Application.LearningSessions.Commands.CreateLearningSession;
using TraineeHelper.Application.LearningSessions.Commands.CreateSkill;
using TraineeHelper.Domain;

namespace TraineeHelper.WebApi.Models;

public class CreateSkillDTO : IMapWith<CreateSkillCommand>
{
    public Mentor Mentor { get; set; }
    //public Dictionary<string, bool> SkillsLearned { get; set; }
    public string SkillName { get; set; }
    public Technology Technology { get; set; }
    //public List<Skill> SkillsLearned { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateSkillDTO, CreateSkillCommand>()
            .ForMember(sCommand => sCommand.Mentor,
            opt => opt.MapFrom(sDTO => sDTO.Mentor))
            .ForMember(sCommand => sCommand.SkillName,
            opt => opt.MapFrom(sDTO => sDTO.SkillName))
            .ForMember(sCommand => sCommand.Technology,
            opt => opt.MapFrom(sDTO => sDTO.Technology));
        //.ForMember(sCommand => sCommand.SkillsLearned,
        //opt => opt.MapFrom(lsDTO => lsDTO.SkillsLearned))
    }
}
