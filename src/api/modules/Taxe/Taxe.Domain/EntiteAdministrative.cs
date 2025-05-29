using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;

namespace PayCom.WebApi.Taxe.Domain;

public abstract class EntiteAdministrative : AuditableEntity, IAggregateRoot
{
    public string Nom { get; protected set; } = string.Empty;
    public string Code { get; protected set; } = string.Empty;
    public string LogoUrl { get; protected set; } = string.Empty;
    public string AdresseSiege { get; protected set; } = string.Empty;
    public string Contact { get; protected set; } = string.Empty;
    public string Email { get; protected set; } = string.Empty;
    public string SiteWeb { get; protected set; } = string.Empty;
    public double? Superficie { get; protected set; }
    public int? Population { get; protected set; }
    public bool EstActif { get; protected set; } = true;

    protected EntiteAdministrative() { }

    protected EntiteAdministrative(string nom, string code)
    {
        Nom = nom;
        Code = code;
        EstActif = true;
    }
    
    public void Activer()
    {
        if (!EstActif)
        {
            EstActif = true;
        }
    }

    public void Desactiver()
    {
        if (EstActif)
        {
            EstActif = false;
        }
    }

    public override string ToString() => $"{Code} - {Nom}";
}
