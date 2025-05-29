using System.Collections.ObjectModel;

namespace PayCom.Shared.Authorization;

public static class FshRoles
{
    public const string Admin = nameof(Admin);
    public const string Basic = nameof(Basic);
    public const string AgentFiscal = nameof(AgentFiscal);
    public const string Contribuable = nameof(Contribuable);

    public static IReadOnlyList<string> DefaultRoles { get; } = new ReadOnlyCollection<string>(new[]
    {
        Admin,
        Basic,
        AgentFiscal,
        Contribuable
    });

    public static bool IsDefault(string roleName) => DefaultRoles.Any(r => r == roleName);
}
