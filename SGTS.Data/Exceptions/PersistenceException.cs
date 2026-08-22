using SGTS.Shared.Enums;
using SGTS.Shared.Exceptions;

namespace SGTS.Data.Exceptions;

public class PersistenceException
    : Exception, IApplicationException
{
    public ErrorCode Code => ErrorCode.Persistence;

    public PersistenceException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }
}