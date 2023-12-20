namespace AutoMapper.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string EmailAddress { get; set; }
        public int Phone { get; set; }
        public string AddressStreet { get; set; }
        public int AddressNumber { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
    }
}
}