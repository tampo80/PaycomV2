using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using System.Collections.Generic;
using System.Linq;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain.Events.CommuneEvents;

namespace PayCom.WebApi.Taxe.Domain;

public class Commune : EntiteAdministrative
{
    public TypeCommune Type { get; private set; }
    public int NombreSecteurs { get; private set; }
    public int NombreArrondissements { get; private set; }
    public TypeChefLieu TypeChefLieu { get; private set; } = TypeChefLieu.Aucun;
    
    public Guid RegionId { get; private set; }
    public virtual Region? Region { get; private set; }
    
    // Informations du centre administratif (tenant)
    public string CodeTenant { get; private set; } = string.Empty;
    public bool EstTenantActif { get; private set; } = true;
    public string NomCentreAdmin { get; private set; } = string.Empty;
    public string AdresseCentreAdmin { get; private set; } = string.Empty;
    public string ContactCentreAdmin { get; private set; } = string.Empty;
    public string EmailCentreAdmin { get; private set; } = string.Empty;
    public string ResponsableCentreAdmin { get; private set; } = string.Empty;

    private Commune() : base() { }

    public Commune(Guid id, string nom, TypeCommune type, string code, int nombreSecteurs, int nombreArrondissements, 
        string logoUrl, string adresseSiege, string contact, string email, 
        string siteWeb, Guid regionId, string codeTenant, string nomCentreAdmin, string adresseCentreAdmin,
        string contactCentreAdmin, string emailCentreAdmin, string responsableCentreAdmin) : base(nom, code)
    {
        Id = id;
        Type = type;
        NombreSecteurs = nombreSecteurs;
        NombreArrondissements = nombreArrondissements;
        LogoUrl = logoUrl;
        AdresseSiege = adresseSiege;
        Contact = contact;
        Email = email;
        SiteWeb = siteWeb;
        RegionId = regionId;
        CodeTenant = codeTenant;
        EstTenantActif = true;
        NomCentreAdmin = nomCentreAdmin;
        AdresseCentreAdmin = adresseCentreAdmin;
        ContactCentreAdmin = contactCentreAdmin;
        EmailCentreAdmin = emailCentreAdmin;
        ResponsableCentreAdmin = responsableCentreAdmin;
        
        QueueDomainEvent(new CommuneCreated(
            Id,
            Nom,
            Type,
            Code,
            NombreSecteurs,
            NombreArrondissements,
            LogoUrl,
            AdresseSiege,
            Contact,
            Email,
            SiteWeb,
            RegionId,
            CodeTenant,
            EstTenantActif,
            NomCentreAdmin,
            AdresseCentreAdmin,
            ContactCentreAdmin,
            EmailCentreAdmin,
            ResponsableCentreAdmin));
    }

    public static Commune Create(string nom, TypeCommune type, string code, int nombreSecteurs, int nombreArrondissements, 
        string logoUrl, string adresseSiege, string contact, string email, 
        string siteWeb, Guid regionId, string codeTenant, string nomCentreAdmin, string adresseCentreAdmin,
        string contactCentreAdmin, string emailCentreAdmin, string responsableCentreAdmin)
    {
        return new Commune(Guid.NewGuid(), nom, type, code, nombreSecteurs, nombreArrondissements, 
            logoUrl, adresseSiege, contact, email, siteWeb, regionId, codeTenant, nomCentreAdmin, 
            adresseCentreAdmin, contactCentreAdmin, emailCentreAdmin, responsableCentreAdmin);
    }

    public Commune Update(string nom, TypeCommune type, string code, int nombreSecteurs, int nombreArrondissements, 
        string logoUrl, string adresseSiege, string contact, string email, 
        string siteWeb, Guid regionId, string codeTenant, string nomCentreAdmin, string adresseCentreAdmin,
        string contactCentreAdmin, string emailCentreAdmin, string responsableCentreAdmin)
    {
        bool isUpdated = false;

        if (Nom != nom)
        {
            Nom = nom;
            isUpdated = true;
        }
        
        if (Code != code)
        {
            Code = code;
            isUpdated = true;
        }

        if (Type != type)
        {
            Type = type;
            isUpdated = true;
        }

        if (NombreSecteurs != nombreSecteurs)
        {
            NombreSecteurs = nombreSecteurs;
            isUpdated = true;
        }

        if (NombreArrondissements != nombreArrondissements)
        {
            NombreArrondissements = nombreArrondissements;
            isUpdated = true;
        }

        if (LogoUrl != logoUrl)
        {
            LogoUrl = logoUrl;
            isUpdated = true;
        }

        if (AdresseSiege != adresseSiege)
        {
            AdresseSiege = adresseSiege;
            isUpdated = true;
        }

        if (Contact != contact)
        {
            Contact = contact;
            isUpdated = true;
        }

        if (Email != email)
        {
            Email = email;
            isUpdated = true;
        }

        if (SiteWeb != siteWeb)
        {
            SiteWeb = siteWeb;
            isUpdated = true;
        }

        if (RegionId != regionId)
        {
            RegionId = regionId;
            isUpdated = true;
        }
        
        if (CodeTenant != codeTenant)
        {
            CodeTenant = codeTenant;
            isUpdated = true;
        }
        
        if (NomCentreAdmin != nomCentreAdmin)
        {
            NomCentreAdmin = nomCentreAdmin;
            isUpdated = true;
        }
        
        if (AdresseCentreAdmin != adresseCentreAdmin)
        {
            AdresseCentreAdmin = adresseCentreAdmin;
            isUpdated = true;
        }
        
        if (ContactCentreAdmin != contactCentreAdmin)
        {
            ContactCentreAdmin = contactCentreAdmin;
            isUpdated = true;
        }
        
        if (EmailCentreAdmin != emailCentreAdmin)
        {
            EmailCentreAdmin = emailCentreAdmin;
            isUpdated = true;
        }
        
        if (ResponsableCentreAdmin != responsableCentreAdmin)
        {
            ResponsableCentreAdmin = responsableCentreAdmin;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new CommuneUpdated(
                Id,
                Nom,
                Type,
                Code,
                NombreSecteurs,
                NombreArrondissements,
                LogoUrl,
                AdresseSiege,
                Contact,
                Email,
                SiteWeb,
                RegionId,
                CodeTenant,
                EstTenantActif,
                NomCentreAdmin,
                AdresseCentreAdmin,
                ContactCentreAdmin,
                EmailCentreAdmin,
                ResponsableCentreAdmin));
        }

        return this;
    }
    
    public void ActiverTenant()
    {
        if (!EstTenantActif)
        {
            EstTenantActif = true;
        }
    }

    public void DesactiverTenant()
    {
        if (EstTenantActif)
        {
            EstTenantActif = false;
        }
    }
    
    public void DefinirTypeChefLieu(TypeChefLieu typeChefLieu)
    {
        TypeChefLieu = typeChefLieu;
    }
    
    public bool EstChefLieuRegion => TypeChefLieu == TypeChefLieu.ChefLieuRegion;

    public string DescriptionType => Type switch
    {
        TypeCommune.Standard => "Commune Standard",
        TypeCommune.Urbaine => "Commune Urbaine",
        TypeCommune.Rurale => "Commune Rurale",
        TypeCommune.Arrondissement => "Arrondissement",
        TypeCommune.Municipalite => "Municipalité",
        TypeCommune.SpecialStatus => "Commune à Statut Spécial",
        _ => "Inconnu"
    };
}
