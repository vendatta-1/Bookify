using Bookify.Application.Abstractions.Exceptions;
using Bookify.Application.Abstractions.Messaging;
using FluentValidation;
using MediatR;
using ValidationException = Bookify.Application.Abstractions.Exceptions.ValidationException;

namespace Bookify.Application.Abstractions.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand
{

    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);
        var validatorErrors = _validators
            .Select(v => v.Validate(context))
            .Where(vError => vError.Errors.Any())
            .SelectMany(vResult => vResult.Errors)
            .Select(vFailure => new ValidationError(

                vFailure.PropertyName,
                vFailure.ErrorMessage,
                vFailure.ErrorCode
            )).ToList();
        if (validatorErrors.Any())
        {
            throw new ValidationException(validatorErrors);
        }
        return await next();
    }
}