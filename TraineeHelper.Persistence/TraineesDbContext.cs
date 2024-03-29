﻿using Microsoft.EntityFrameworkCore;
using TraineeHelper.Application.Interfaces;
using TraineeHelper.Domain;
using TraineeHelper.Persistence.EntityTypeConfigurations;

namespace TraineeHelper.Persistence;
public class TraineesDbContext : DbContext, ITraineesDbContext
{
    public DbSet<Trainee> Trainees { get; set; }
    public TraineesDbContext(DbContextOptions<TraineesDbContext> options) 
        : base(options) { }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TraineeConfiguration());
        base.OnModelCreating(builder);
    }
}
