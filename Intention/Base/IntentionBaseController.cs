using Business;
using Microsoft.AspNetCore.Mvc;

namespace Intention.Base;

public class IntentionBaseController : ControllerBase
{
    public IntentionBaseController()
    {

    }

    internal static readonly string[] ScopeRequiredByApi = { "access_as_user", "user.read" };

    public IWebHostEnvironment Host { get; internal set; }

    public ServiceResponse<object> ServiceResponse { get; set; }
    public IntentionBaseController(
        IWebHostEnvironment host)
    {
        Host = host ?? throw new ArgumentNullException(nameof(host));
    }
    public CancellationToken Token;

}
