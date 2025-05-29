using PayCom.Blazor.Client.Components;
using PayCom.Blazor.Infrastructure.Api;
using PayCom.Shared.Authorization;
using Microsoft.AspNetCore.Components;

namespace PayCom.Blazor.Client.Pages.Auth;

public partial class ForgotPassword
{
    private readonly ForgotPasswordCommand _forgotPasswordRequest = new();
    private FshValidation? _customValidation;
    private bool BusySubmitting { get; set; }

    [Inject]
    private IApiClient UsersClient { get; set; } = default!;

    private string Tenant { get; set; } = TenantConstants.Root.Id;

    private async Task SubmitAsync()
    {
        BusySubmitting = true;

        await ApiHelper.ExecuteCallGuardedAsync(
            () => UsersClient.ForgotPasswordEndpointAsync(Tenant, _forgotPasswordRequest),
            Toast,
            Navigation,
            _customValidation);

        BusySubmitting = false;
    }
}
