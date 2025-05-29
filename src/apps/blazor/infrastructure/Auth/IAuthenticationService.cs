using PayCom.Blazor.Infrastructure.Api;

namespace PayCom.Blazor.Infrastructure.Auth;

public interface IAuthenticationService
{

    void NavigateToExternalLogin(string returnUrl);

    Task<bool> LoginAsync(string tenantId, TokenGenerationCommand request);

    Task LogoutAsync();

    Task ReLoginAsync(string returnUrl);
}
