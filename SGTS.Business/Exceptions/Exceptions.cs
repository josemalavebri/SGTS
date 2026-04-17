using SGTS.Shared.Const;

namespace SGTS.Business.Exceptions;

public abstract class BusinessException(string code, string message)
    : Exception(message)
{
    public string Code { get; } = code;
}

public class NotFoundException(string resource)
    : BusinessException(ErrorCodes.NOT_FOUND, $"{resource} no encontrado");

public class ConflictException(string message)
    : BusinessException(ErrorCodes.CONFLICT, message);

public class ForbiddenOperationException(string message)
    : BusinessException(ErrorCodes.FORBIDDEN, message);

public class ValidationException(string message)
    : BusinessException(ErrorCodes.VALIDATION, message);

public class BusinessRuleException(string message)
    : BusinessException(ErrorCodes.BUSINESS_RULE, message);