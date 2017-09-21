namespace Aanvragen.Entities {
    public enum AttachmentAction {
        Verzonden, Beoordeling, Verbeterd, Overig
    }

    public enum AttachmentType {
        CV, Mail, Certificaat, Personal, Overig
    }

    public enum HireType {
        Inhuur, Verhuur, Geen, Overig
    }

    public enum Role {
        Operationmanager, Accountmanager, Directeur, Jobcoach, Overig
    }

    public enum RequestStatus {
        Nieuw, Aanbieding, Contract, Verloren, Gesloten
    }

    public enum RequestType {
        Inkoop, Verkoop, Overig
    }
}
