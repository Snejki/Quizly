using FluentValidation;
using MediatR;

namespace Quizly.Shared.Infrastructure.Mediatr.PipelineBehaviors;

public class ValidationPipelineBehavior<TQuery, TResult> : IPipelineBehavior<TQuery, TResult>
    where TQuery : class, IRequest<TResult>
{
    private readonly IEnumerable<IValidator<TQuery>> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TQuery>> validators)
    {
        _validators = validators;
    }

    public async Task<TResult> Handle(TQuery request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var validationFailures = _validators
                .Select(validator => validator.Validate(request))
                .SelectMany(validationResult => validationResult.Errors)
                .Where(validationFailure => validationFailure != null)
                .ToList();

            if (validationFailures.Any())
            {
                throw new ValidationException(validationFailures);
            }
        }

        return await next();
    }
}