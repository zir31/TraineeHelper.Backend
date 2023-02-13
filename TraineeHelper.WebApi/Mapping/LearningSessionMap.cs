using AutoMapper;
using TraineeHelper.Application.Commands;
using TraineeHelper.Domain.Entities;
using TraineeHelper.WebApi.Models;

namespace TraineeHelper.WebApi.Mapping;

public class LearningSessionMap : Profile
{
    public LearningSessionMap()
    {
        //    CreateMap<int, PersonalSkill>()
        //      .ForMember(ps => ps.SkillId,
        //      opt => opt.MapFrom(i => i));

        CreateMap<CreateLearningSessionDTO, CreateLearningSessionCommand>()
            //.ForMember(lsCommand => lsCommand.Trainee,
            //opt => opt.MapFrom(lsDTO => lsDTO.Trainee))
            .ForMember(lsCommand => lsCommand.SkillsToLearnIds,
            opt => opt.MapFrom(lsDTO => lsDTO.SkillsToLearnIds));

        CreateMap<UpdateLearningSessionDTO, UpdateLearningSessionCommand>()
            .ForMember(lsCommand => lsCommand.SkillsLearnedIds,
            opt => opt.MapFrom(lsDTO => lsDTO.SkillsLearnedIds))
            .ForMember(lsCommand => lsCommand.LearningSessionState,
            opt => opt.MapFrom(lsDTO => lsDTO.LearningSessionState));

        CreateMap<LearningSession, LearningSessionResponse>()
            .ForMember(lsResponse => lsResponse.Id,
            opt => opt.MapFrom(ls => ls.Id));
    }
    
}
