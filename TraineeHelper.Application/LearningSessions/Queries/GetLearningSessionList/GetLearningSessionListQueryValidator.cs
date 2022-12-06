using System;
using FluentValidation;

namespace TraineeHelper.Application.LearningSessions.Queries.GetLearningSessionList;
public class GetLearningSessionListQueryValidator  : AbstractValidator<GetLearningSessionsListQuery>
{
    public GetLearningSessionListQueryValidator()
    {
        RuleFor(getLSList =>
            getLSList.TraineeId).NotEqual(Guid.Empty);
    }
}
