using Application.Domain.Response;
using FluentValidation;
using MediatR;

namespace Application.Helpers
{
  public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : BaseResponse , new()
  {
    private readonly IValidator<TRequest>[] _validators;

    public ValidationBehavior(IValidator<TRequest>[] validators)
    {
      _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
      if (_validators.Length > 0)
      {
        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

        if (failures.Count > 0)
        {
          // Crear un DataResponse con errores y devolverlo
          var response = new DataResponse<TResponse>
          {
            success = false,
            message = string.Join("; ", failures.Select(f => f.ErrorMessage))
          };

          return response as TResponse;
        }
      }

      return await next();
    }
  }
}
