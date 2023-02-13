using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TraineeHelper.Application.Interfaces;
using TraineeHelper.Persistence;

namespace TraineeHelper.Tests.Common;
public class QueryTestFixture : IDisposable
{
    public LearningSessionsDbContext Context;
    public IMapper Mapper;

    public QueryTestFixture()
    {
        Context = LearningSessionsContextFactory.Create();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            //cfg.AddProfile(new AssemblyMappingProfile(
            //    typeof(ILearningSessionsDbContext).Assembly));
        });
        Mapper = configurationProvider.CreateMapper();
    }

    public void Dispose()
    {
        LearningSessionsContextFactory.Destroy(Context);
    }
}

[CollectionDefinition("QueryCollection")]
public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
