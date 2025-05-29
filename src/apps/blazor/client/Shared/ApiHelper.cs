using MudBlazor;
using PayCom.Blazor.Infrastructure.Api;
using Microsoft.AspNetCore.Components;

namespace PayCom.Blazor.Client.Shared;

public static class InnovApiHelper
{
    public static async Task<T> ExecuteCallGuardedAsync<T>(
        Func<Task<T>> apiCall,
        ISnackbar snackbar,
        NavigationManager? navigationManager = null,
        string? errorMessage = null,
        string? successMessage = null)
    {
        try
        {
            var result = await apiCall();
            
            if (!string.IsNullOrEmpty(successMessage))
            {
                snackbar.Add(successMessage, Severity.Success);
            }
            
            return result;
        }
        catch (ApiException ex)
        {
            if (ex.StatusCode == 401)
            {
                snackbar.Add("Vous n'êtes pas authentifié ou votre session a expiré.", Severity.Warning);
                navigationManager?.NavigateTo("/login");
                throw;
            }

            if (ex.StatusCode == 403)
            {
                snackbar.Add("Vous n'avez pas les permissions nécessaires pour effectuer cette action.", Severity.Warning);
                throw;
            }

            snackbar.Add(errorMessage ?? $"Une erreur s'est produite: {ex.Message}", Severity.Error);
            throw;
        }
        catch (Exception ex)
        {
            snackbar.Add(errorMessage ?? $"Une erreur s'est produite: {ex.Message}", Severity.Error);
            throw;
        }
    }
} 
