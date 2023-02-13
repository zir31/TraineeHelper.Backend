using System;
using FluentValidation;

namespace TraineeHelper.Application.Queries;
public class GetLearningSessionListQueryValidator : AbstractValidator<GetLearningSessionsListQuery>
{
    public GetLearningSessionListQueryValidator()
    {
        RuleFor(getLSList =>
            getLSList.TraineeId).NotEqual(Guid.Empty);
    }
}
