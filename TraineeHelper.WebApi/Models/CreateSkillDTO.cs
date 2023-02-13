using AutoMapper;
using TraineeHelper.Application.Commands;

namespace TraineeHelper.WebApi.Models;

public class CreateSkillDTO
{
    //public Guid MentorId { get; set; }
    //public Dictionary<string, bool> SkillsLearned { get; set; }
    public string SkillName { get; set; }
    public Guid TechnologyId { get; set; }
    //public List<Skill> SkillsLearned { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateSkillDTO, CreateSkillCommand>()
            //.ForMember(sCommand => sCommand.MentorId,
            //opt => opt.MapFrom(sDTO => sDTO.MentorId))
            .ForMember(sCommand => sCommand.SkillName,
            opt => opt.MapFrom(sDTO => sDTO.SkillName))
            .ForMember(sCommand => sCommand.TechnologyId,
            opt => opt.MapFrom(sDTO => sDTO.TechnologyId));
        //.ForMember(sCommand => sCommand.SkillsLearned,
        //opt => opt.MapFrom(lsDTO => lsDTO.SkillsLearned))
    }
}
