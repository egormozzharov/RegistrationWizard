namespace RegistrationWizard.Server.Models
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Province> Provinces { get; set; }
    }

    public class Province
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Name { get; set; }
    }
}
