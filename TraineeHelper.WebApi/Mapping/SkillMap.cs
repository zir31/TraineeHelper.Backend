using AutoMapper;
using TraineeHelper.Application.Commands;
using TraineeHelper.Domain.Entities;
using TraineeHelper.WebApi.Models;

namespace TraineeHelper.WebApi.Mapping;

public class SkillMap : Profile
{
    public SkillMap()
    {
        CreateMap<CreateSkillDTO, CreateSkillCommand>()
            .ForMember(sCommand => sCommand.SkillName,
            opt => opt.MapFrom(sDTO => sDTO.SkillName))
            .ForMember(sCommand => sCommand.TechnologyId,
            opt => opt.MapFrom(sDTO => sDTO.TechnologyId));

        CreateMap<Skill, SkillResponse>()
            .ForMember(sResponse => sResponse.Id,
            opt => opt.MapFrom(skill => skill.Id));
    }
}
