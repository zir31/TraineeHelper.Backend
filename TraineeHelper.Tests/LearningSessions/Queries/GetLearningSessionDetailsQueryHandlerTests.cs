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
using TraineeHelper.Application.LearningSessions.Commands.CreateLearningSession;
using TraineeHelper.Domain;

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
        var createHandler = new CreateLearningSessionCommandHandler(Context);
        var getHandler = new GetLearningSessionDetailsQueryHandler(Context, Mapper);
        var tech = new Technology() { Name = ".NET" };
        var trainee = new Trainee("Daniel", tech, null);

        // Act
        var createHandlerId = await createHandler.Handle(new CreateLearningSessionCommand
        {
            Trainee = trainee
        }, CancellationToken.None);

        var result = await getHandler.Handle(
            new GetLearningSessionDetailsQuery
            {
                TraineeId = trainee.Id,
                Id = createHandlerId
            },
            CancellationToken.None);

        // Assert
        result.ShouldBeOfType<LearningSessionDetailsVm>();
        result.TraineeName.ShouldBe("Daniel");
        result.CreationDate.ShouldBe(DateTime.Today);
    }
}
