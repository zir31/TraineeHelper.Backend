using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TraineeHelper.Domain.Entities;

namespace TraineeHelper.Application.Queries;
public class LearningSessionDetailsVm
{
    public Guid Id { get; set; }
    public string TraineeName { get; set; }
    public List<Skill> SkillsToLearn { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? EditDate { get; set; }
    public DateTime? FinishingDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<LearningSession, LearningSessionDetailsVm>()
            .ForMember(lsVm => lsVm.Id,
            opt => opt.MapFrom(ls => ls.Id))
            //.ForMember(lsVm => lsVm.TraineeName,
            //opt => opt.MapFrom(ls => ls.Trainee.FullName))
            .ForMember(lsVm => lsVm.SkillsToLearn,
            opt => opt.MapFrom(ls => ls.PersonalSkills))
            .ForMember(lsVm => lsVm.CreationDate,
            opt => opt.MapFrom(ls => ls.CreationDate))
            .ForMember(lsVm => lsVm.FinishingDate,
            opt => opt.MapFrom(ls => ls.FinishingDate));
    }
}
