using Microsoft.Extensions.Localization;

namespace Hope.Application.Common;

public abstract class BaseService
{
    protected readonly IStringLocalizer _localizer;

    protected BaseService(IStringLocalizer localizer)
    {
        _localizer = localizer;
    }

    protected string L(string key) => _localizer[key];
    
    protected string L(string key, params object[] args) => _localizer[key, args];
} 