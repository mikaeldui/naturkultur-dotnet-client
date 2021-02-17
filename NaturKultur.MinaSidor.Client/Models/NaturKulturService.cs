using System;

namespace NaturKultur.MinaSidor
{
    public class NaturKulturService
    {
        public NaturKulturServiceLicense[] Licenses { get; set; }
        public NaturKulturServiceOwnedSingleLicenses OwnedSingleLicenses { get; set; }
        public bool HasActiveLicense { get; set; }
        public bool IncludeAllLicenses { get; set; }
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string LicensePeriodName { get; set; }
        public int LicensePeriodDays { get; set; }
        public string InformationUrl { get; set; }
        public bool DemoExists { get; set; }
        public string StartUrl { get; set; }
        public DateTime BetaEndDate { get; set; }
        public DateTime PublishDate { get; set; }
        public object DigitalTypeId { get; set; }
        public int DaysUntilExpiration { get; set; }
        public string DigitalOrderIsbn { get; set; }
        public string ImageUrl { get; set; }
        public string[] ServiceTypes { get; set; }
        public string[] Grades { get; set; }
        public string[] Subjects { get; set; }
        public object[] AssociatedProducts { get; set; }
        public bool IsConnectedToIsbn { get; set; }
    }

    public class NaturKulturServiceOwnedSingleLicenses
    {
        public int Total { get; set; }
        public int Free { get; set; }
    }

    public class NaturKulturServiceLicense
    {
        public int LicenseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ReminderDate { get; set; }
        public bool IsStarted { get; set; }
        public int OwnerId { get; set; }
        public int AssigneeId { get; set; }
        public object GroupId { get; set; }
        public string LicenseType { get; set; }
        public string LicensePeriod { get; set; }
        public string ActivationCode { get; set; }
        public DateTime ActivationDate { get; set; }
        public object DebtorId { get; set; }
        public int DaysUntilExpiration { get; set; }
    }
}