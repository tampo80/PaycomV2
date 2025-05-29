using Microsoft.AspNetCore.Components;

namespace PayCom.Blazor.Client.Components.Common;

// Classe utilitaire pour les dialogues
public class DialogBase : ComponentBase
{
    [Parameter] public string Title { get; set; } = "Dialogue";
    [Parameter] public string ContentText { get; set; } = "";
    
    protected void Close(bool result)
    {
        OnClose.InvokeAsync(result);
    }
    
    [Parameter] public EventCallback<bool> OnClose { get; set; }
} 
