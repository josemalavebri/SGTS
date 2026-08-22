using SGTS.Shared.Enums;

namespace SGTS.Shared.Exceptions;

public interface IApplicationException
{
    ErrorCode Code { get; }

    string Message { get; }
}