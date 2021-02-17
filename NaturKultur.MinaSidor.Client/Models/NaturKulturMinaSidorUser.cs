using System;

namespace NaturKultur.MinaSidor
{
    public class NaturKulturMinaSidorUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public object Phone { get; set; }
        public object FutureDeletionDate { get; set; }
        public object PendingDebtorId { get; set; }
        public object PendingRoleId { get; set; }
        public object PendingRequestId { get; set; }
        public object DeletionDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime LastLogin { get; set; }
        public object[] Debtors { get; set; }
        public DateTime AcceptedTerms { get; set; }
        public NaturKulturMinaSidorUserEmailAddress[] EmailAddresses { get; set; }
        public object[] ExternalAuthentications { get; set; }
        public object ProviderToken { get; set; }
        public string PendingRole { get; set; }
        public object PendingDebtorName { get; set; }
    }

    public class NaturKulturMinaSidorUserEmailAddress
    {
        public string Value { get; set; }
        public bool Primary { get; set; }
        public bool IsValidated { get; set; }
    }
}