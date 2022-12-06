using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TraineeHelper.Application.Common.Mappings;
using TraineeHelper.Domain;

namespace TraineeHelper.Application.LearningSessions.Queries.GetLearningSessionDetails;
public class LearningSessionDetailsVm : IMapWith<LearningSession>
{
    public Guid Id { get; set; }
    public string TraineeName { get; set; }
    public Dictionary<string, bool> SkillsLearned { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? EditDate { get; set; }
    public DateTime? FinishingDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<LearningSession, LearningSessionDetailsVm>()
            .ForMember(lsVm => lsVm.Id,
            opt => opt.MapFrom(ls => ls.Id))
            .ForMember(lsVm => lsVm.TraineeName,
            opt => opt.MapFrom(ls => ls.TraineeName))
            .ForMember(lsVm => lsVm.SkillsLearned,
            opt => opt.MapFrom(ls => ls.SkillsLearned))
            .ForMember(lsVm => lsVm.CreationDate,
            opt => opt.MapFrom(ls => ls.CreationDate))
            .ForMember(lsVm => lsVm.EditDate,
            opt => opt.MapFrom(ls => ls.EditDate))
            .ForMember(lsVm => lsVm.FinishingDate,
            opt => opt.MapFrom(ls => ls.FinishingDate));
    }
}
