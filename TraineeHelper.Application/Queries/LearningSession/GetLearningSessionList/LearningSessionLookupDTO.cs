﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TraineeHelper.Domain.Entities;

namespace TraineeHelper.Application.Queries;
public class LearningSessionLookupDTO
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<LearningSession, LearningSessionLookupDTO>()
            .ForMember(lsDTO => lsDTO.Id,
            opt => opt.MapFrom(ls => ls.Id))
            .ForMember(lsDTO => lsDTO.CreationDate,
            opt => opt.MapFrom(ls => ls.CreationDate));
    }
}