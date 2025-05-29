using PayCom.Blazor.Infrastructure.Api;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Text.Json;

namespace PayCom.Blazor.Client.Components;

public static class ApiHelper
{
    public static async Task<T?> ExecuteCallGuardedAsync<T>(
        Func<Task<T>> call,
        ISnackbar snackbar,
        NavigationManager navigationManager,
        FshValidation? customValidation = null,
        string? successMessage = null)
    {
        customValidation?.ClearErrors();
        try
        {
            var result = await call();

            if (!string.IsNullOrWhiteSpace(successMessage))
            {
                snackbar.Add(successMessage, Severity.Success);
            }

            return result;
        }
        catch (ApiException ex)
        {
            if (ex.StatusCode == 401)
            {
                snackbar.Add("Votre session a expiré. Veuillez vous reconnecter.", Severity.Warning);
                navigationManager.NavigateTo("/logout");
                return default;
            }
            
            var userFriendlyMessage = GetUserFriendlyErrorMessage(ex);
            snackbar.Add(userFriendlyMessage, Severity.Error);
            
            // Mettre à jour les validations si applicable
            if (customValidation != null && ex.Response != null)
            {
                try
                {
                    var jsonDoc = JsonDocument.Parse(ex.Response);
                    if (jsonDoc.RootElement.TryGetProperty("errors", out var errorsElement))
                    {
                        if (errorsElement.ValueKind == JsonValueKind.Array)
                        {
                            // Erreurs sous forme de liste
                            var errors = new List<string>();
                            foreach (var error in errorsElement.EnumerateArray())
                            {
                                if (error.ValueKind == JsonValueKind.String)
                                {
                                    errors.Add(error.GetString() ?? string.Empty);
                                }
                            }
                            
                            if (errors.Count > 0)
                            {
                                // Convertir la liste en dictionnaire pour FshValidation
                                var errorDict = new Dictionary<string, ICollection<string>>
                                {
                                    { "General", errors }
                                };
                                customValidation.DisplayErrors(errorDict);
                            }
                        }
                        else if (errorsElement.ValueKind == JsonValueKind.Object)
                        {
                            // Erreurs sous forme de dictionnaire par champ
                            var errorDict = new Dictionary<string, ICollection<string>>();
                            
                            foreach (var property in errorsElement.EnumerateObject())
                            {
                                var fieldName = property.Name;
                                var fieldErrors = new List<string>();
                                
                                if (property.Value.ValueKind == JsonValueKind.Array)
                                {
                                    foreach (var error in property.Value.EnumerateArray())
                                    {
                                        if (error.ValueKind == JsonValueKind.String)
                                        {
                                            fieldErrors.Add(error.GetString() ?? string.Empty);
                                        }
                                    }
                                }
                                else if (property.Value.ValueKind == JsonValueKind.String)
                                {
                                    fieldErrors.Add(property.Value.GetString() ?? string.Empty);
                                }
                                
                                if (fieldErrors.Count > 0)
                                {
                                    errorDict.Add(fieldName, fieldErrors);
                                }
                            }
                            
                            if (errorDict.Count > 0)
                            {
                                customValidation.DisplayErrors(errorDict);
                            }
                        }
                    }
                }
                catch (JsonException)
                {
                    // En cas d'erreur de parsing JSON, ne rien faire
                }
            }
        }
        catch (Exception ex)
        {
            snackbar.Add("Une erreur inattendue s'est produite. Veuillez réessayer ultérieurement.", Severity.Error);
            Console.WriteLine($"Exception non gérée: {ex.Message}");
        }

        return default;
    }

    public static async Task<bool> ExecuteCallGuardedAsync(
        Func<Task> call,
        ISnackbar snackbar,
        NavigationManager? navigationManager = null,
        FshValidation? customValidation = null,
        string? successMessage = null)
    {
        customValidation?.ClearErrors();
        try
        {
            await call();

            if (!string.IsNullOrWhiteSpace(successMessage))
            {
                snackbar.Add(successMessage, Severity.Success);
            }

            return true;
        }
        catch (ApiException ex)
        {
            if (ex.StatusCode == 401 && navigationManager != null)
            {
                snackbar.Add("Votre session a expiré. Veuillez vous reconnecter.", Severity.Warning);
                navigationManager.NavigateTo("/logout");
                return false;
            }
            
            var userFriendlyMessage = GetUserFriendlyErrorMessage(ex);
            snackbar.Add(userFriendlyMessage, Severity.Error);
            
            // Mettre à jour les validations si applicable
            if (customValidation != null && ex.Response != null)
            {
                try
                {
                    var jsonDoc = JsonDocument.Parse(ex.Response);
                    if (jsonDoc.RootElement.TryGetProperty("errors", out var errorsElement))
                    {
                        if (errorsElement.ValueKind == JsonValueKind.Array)
                        {
                            // Erreurs sous forme de liste
                            var errors = new List<string>();
                            foreach (var error in errorsElement.EnumerateArray())
                            {
                                if (error.ValueKind == JsonValueKind.String)
                                {
                                    errors.Add(error.GetString() ?? string.Empty);
                                }
                            }
                            
                            if (errors.Count > 0)
                            {
                                // Convertir la liste en dictionnaire pour FshValidation
                                var errorDict = new Dictionary<string, ICollection<string>>
                                {
                                    { "General", errors }
                                };
                                customValidation.DisplayErrors(errorDict);
                            }
                        }
                        else if (errorsElement.ValueKind == JsonValueKind.Object)
                        {
                            // Erreurs sous forme de dictionnaire par champ
                            var errorDict = new Dictionary<string, ICollection<string>>();
                            
                            foreach (var property in errorsElement.EnumerateObject())
                            {
                                var fieldName = property.Name;
                                var fieldErrors = new List<string>();
                                
                                if (property.Value.ValueKind == JsonValueKind.Array)
                                {
                                    foreach (var error in property.Value.EnumerateArray())
                                    {
                                        if (error.ValueKind == JsonValueKind.String)
                                        {
                                            fieldErrors.Add(error.GetString() ?? string.Empty);
                                        }
                                    }
                                }
                                else if (property.Value.ValueKind == JsonValueKind.String)
                                {
                                    fieldErrors.Add(property.Value.GetString() ?? string.Empty);
                                }
                                
                                if (fieldErrors.Count > 0)
                                {
                                    errorDict.Add(fieldName, fieldErrors);
                                }
                            }
                            
                            if (errorDict.Count > 0)
                            {
                                customValidation.DisplayErrors(errorDict);
                            }
                        }
                    }
                }
                catch (JsonException)
                {
                    // En cas d'erreur de parsing JSON, ne rien faire
                }
            }
        }
        catch (Exception ex)
        {
            snackbar.Add("Une erreur inattendue s'est produite. Veuillez réessayer ultérieurement.", Severity.Error);
            Console.WriteLine($"Exception non gérée: {ex.Message}");
        }

        return false;
    }
    
    /// <summary>
    /// Transforme le message d'erreur technique en message compréhensible pour l'utilisateur
    /// </summary>
    private static string GetUserFriendlyErrorMessage(ApiException ex)
    {
        // Extraire le détail de l'erreur de la réponse si possible
        string detailMessage = string.Empty;
        if (!string.IsNullOrEmpty(ex.Response))
        {
            try
            {
                var jsonDoc = JsonDocument.Parse(ex.Response);
                if (jsonDoc.RootElement.TryGetProperty("detail", out var detailElement) && 
                    detailElement.ValueKind == JsonValueKind.String)
                {
                    detailMessage = detailElement.GetString() ?? string.Empty;
                }
            }
            catch (JsonException)
            {
                // En cas d'erreur de parsing JSON, utiliser le message brut
                detailMessage = ex.Message;
            }
        }
        
        // Si le détail est vide, utiliser le message d'exception
        if (string.IsNullOrEmpty(detailMessage))
        {
            detailMessage = ex.Message;
        }
        
        // Transformer les messages techniques en messages utilisateur
        return detailMessage switch
        {
            var msg when msg.Contains("duplicate key") => "Un élément avec ces informations existe déjà dans le système.",
            var msg when msg.Contains("validation errors occurred") => "Veuillez vérifier les informations saisies.",
            var msg when msg.Contains("TypeError: Failed to fetch") => "Impossible de contacter le serveur. Vérifiez votre connexion.",
            var msg when msg.Contains("authentication failed") => "Authentification échouée. Veuillez vous reconnecter.",
            var msg when msg.Contains("403") => "Vous n'avez pas les permissions nécessaires pour effectuer cette action.",
            var msg when msg.Contains("404") => "La ressource demandée n'a pas été trouvée.",
            var msg when msg.Contains("500") => "Une erreur est survenue côté serveur. Veuillez réessayer plus tard.",
            _ => "Une erreur s'est produite lors de l'opération. Veuillez réessayer."
        };
    }
}
