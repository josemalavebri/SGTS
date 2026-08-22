using SGTS.Shared.Enums;
using SGTS.Shared.Exceptions;

namespace SGTS.Business.Exceptions;

public class BusinessException
    : Exception, IApplicationException
{
    public ErrorCode Code { get; }

    public BusinessException(
        ErrorCode code,
        string message)
        : base(message)
    {
        Code = code;
    }

    public BusinessException(
        ErrorCode code,
        string message,
        Exception innerException)
        : base(message, innerException)
    {
        Code = code;
    }
}