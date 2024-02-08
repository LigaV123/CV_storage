namespace CV_storage_app.Models
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public int CurriculumVitaeId { get; set; }
    }
}
