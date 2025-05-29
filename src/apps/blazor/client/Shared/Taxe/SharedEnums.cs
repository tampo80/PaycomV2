namespace PayCom.Shared.Enums;

public enum ModePaiement
{
    Especes = 0,
    CarteBancaire = 1,
    MobileMoney = 2,
    Cheque = 3,
    Virement = 4,
    OrangeMoney = 5,
    MTNMoney = 6,
    MoovMoney = 7,
    WaveAfricaMoney = 8,
    Paypal = 9,
    Crypto = 10,
    QRCode = 11,
    LiensPayement = 12
}

public enum StatutPaiement
{
    EnAttente = 0,
    Reussi = 1,
    Echoue = 2,
    Rembourse = 3,
    Annule = 4
}

public enum StatutPaiementTerrain
{
    EnAttente = 0,
    Valide = 1,
    Rejete = 2,
    FraudeSuspectee = 3
}

public enum FrequencePaiement
{
    Ponctuelle = 0,
    Quotidienne = 1,
    Hebdomadaire = 2,
    Mensuelle = 3,
    Trimestrielle = 4,
    Semestrielle = 5,
    Annuelle = 6
}

public enum TypePermis
{
    Temporaire = 0,
    Annual = 1,
    Permanent = 2
} 
