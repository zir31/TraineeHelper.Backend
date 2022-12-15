using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TraineeHelper.Persistence;
using TraineeHelper.Tests.Common;
using TraineeHelper.Application.LearningSessions.Queries.GetLearningSessionDetails;
using Shouldly;

namespace TraineeHelper.Tests.LearningSessions.Queries;

[Collection("QueryCollection")]
public class GetLearningSessionDetailsQueryHandlerTests
{
    private readonly LearningSessionsDbContext Context;
    private readonly IMapper Mapper;

    public GetLearningSessionDetailsQueryHandlerTests(QueryTestFixture fixture)
    {
        Context = fixture.Context;
        Mapper = fixture.Mapper;
    }

    [Fact]
    public async Task GetLearningSessionDetailsQueryHandler_Success()
    {
        // Arrange
        var handler = new GetLearningSessionDetailsQueryHandler(Context, Mapper);

        // Act
        var result = await handler.Handle(
            new GetLearningSessionDetailsQuery
            {
                TraineeId = LearningSessionsContextFactory.UserBId,
                Id = Guid.Parse("CA3BB9F3-E621-41C1-9140-AB823E0F6577")
            },
            CancellationToken.None);

        // Assert
        result.ShouldBeOfType<LearningSessionDetailsVm>();
        result.TraineeName.ShouldBe("Boris");
        result.CreationDate.ShouldBe(DateTime.Today);
    }
}
