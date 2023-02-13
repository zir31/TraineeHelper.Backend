using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TraineeHelper.Application.Queries;
public class GetLearningSessionDetailsQueryValidator : AbstractValidator<GetLearningSessionDetailsQuery>
{
    public GetLearningSessionDetailsQueryValidator()
    {
        RuleFor(getLSDetails =>
            getLSDetails.Id).NotEqual(null);
        RuleFor(getLSDetails =>
            getLSDetails.TraineeId).NotEqual(Guid.Empty);
    }
}
