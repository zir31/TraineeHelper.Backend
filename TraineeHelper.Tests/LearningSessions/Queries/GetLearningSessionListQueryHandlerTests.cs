using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shouldly;
using TraineeHelper.Application.LearningSessions.Queries.GetLearningSessionList;
using TraineeHelper.Persistence;
using TraineeHelper.Tests.Common;

namespace TraineeHelper.Tests.LearningSessions.Queries;
[Collection("QueryCollection")]
public class GetLearningSessionListQueryHandlerTests
{
    private readonly LearningSessionsDbContext Context;
    private readonly IMapper Mapper;

    public GetLearningSessionListQueryHandlerTests(QueryTestFixture fixture)
    {
        Context = fixture.Context;
        Mapper = fixture.Mapper;
    }

    [Fact]
    public async Task GetLearningSessionListQueryHandler_Success()
    {
        // Arrange
        var handler = new GetLearningSessionListQueryHandler(Context, Mapper);

        // Act
        var result = await handler.Handle(
            new GetLearningSessionsListQuery
            {
                TraineeId = LearningSessionsContextFactory.Trainee2.Id
            },
            CancellationToken.None);

        // Assert
        result.ShouldBeOfType<LearningSessionListVm>();
        result.LearningSessions.Count.ShouldBe(2);
    }
}
