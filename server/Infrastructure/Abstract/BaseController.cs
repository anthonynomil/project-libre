using System.Net;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Enum;
using Models.Interface;

namespace Infrastructure.Abstract;

public abstract class BaseController : ControllerBase
{
    protected IActionResult SendEnvelop(IResult result)
    {
        return StatusCode(
            (int)HttpStatusCodeFromResult[result.ApplicationResultCodeCode],
            Envelop.From(result)
        );
    }

    protected IActionResult SendEnvelopWithValue<T>(IResult<T> result)
        where T : class
    {
        return StatusCode(
            (int)HttpStatusCodeFromResult[result.ApplicationResultCodeCode],
            Envelop<T>.From(result)
        );
    }

    private static readonly IReadOnlyDictionary<
        ApplicationResultCodeEnum,
        HttpStatusCode
    > HttpStatusCodeFromResult = new Dictionary<ApplicationResultCodeEnum, HttpStatusCode>
    {
        { ApplicationResultCodeEnum.Unknown, HttpStatusCode.InternalServerError },
        { ApplicationResultCodeEnum.Retrieved, HttpStatusCode.OK },
        { ApplicationResultCodeEnum.Created, HttpStatusCode.Created },
        { ApplicationResultCodeEnum.Updated, HttpStatusCode.NoContent },
        { ApplicationResultCodeEnum.Deleted, HttpStatusCode.NoContent },
        { ApplicationResultCodeEnum.InvalidCredentials, HttpStatusCode.BadRequest },
        { ApplicationResultCodeEnum.ValidationError, HttpStatusCode.BadRequest },
        { ApplicationResultCodeEnum.AlreadyExists, HttpStatusCode.Conflict },
        { ApplicationResultCodeEnum.PopulationError, HttpStatusCode.UnprocessableEntity },
        { ApplicationResultCodeEnum.FileSystemError, HttpStatusCode.InternalServerError },
        { ApplicationResultCodeEnum.DatabaseError, HttpStatusCode.InternalServerError },
        {
            ApplicationResultCodeEnum.ThirdPartyServiceUnavailable,
            HttpStatusCode.ServiceUnavailable
        },
        { ApplicationResultCodeEnum.Unauthorized, HttpStatusCode.Unauthorized },
        { ApplicationResultCodeEnum.NotFound, HttpStatusCode.NotFound },
        { ApplicationResultCodeEnum.MissingDependency, HttpStatusCode.FailedDependency }
    };

    private class Envelop : IEnvelop
    {
        public DateTimeOffset GeneratedAt { get; init; }
        public string? Message { get; init; }
        public IEnumerable<string> Warnings { get; init; }

        protected Envelop(string? message, IEnumerable<string> warning)
        {
            GeneratedAt = DateTimeOffset.Now;
            Message = message;
            Warnings = warning;
        }

        public static Envelop From(IResult result) =>
            new(result.Message, ExtractErrorMessages(result.NestedResults));
    }

    private class Envelop<T> : Envelop, IEnvelop<T>
        where T : class
    {
        public T? Value { get; init; }

        private Envelop(string? message, IEnumerable<string> warnings, T? value)
            : base(message, warnings)
        {
            Value = value;
        }

        public static Envelop<T> From(IResult<T> result) =>
            new(result.Message, ExtractErrorMessages(result.NestedResults), result.Value);
    }

    private static IEnumerable<string> ExtractErrorMessages(IEnumerable<IResult> results)
    {
        return results
            .Where(result => result.IsSuccessful == false)
            .Select(result => result.Message);
    }
}
