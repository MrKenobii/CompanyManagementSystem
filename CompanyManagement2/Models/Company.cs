using System;
namespace CompanyManagement2.Models
{
	public class Company
	{
		public int Id { get; set; }
		public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zipcode { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string Website { get; set; }

        public Company(int Id, string? CompanyName, string? Address, string? City, string? State, string? Zipcode, string? Phone, string? Fax, string? Website)
        {
            this.Id = Id;
            this.CompanyName = CompanyName;
            this.Address = Address;
            this.City = City;
            this.State = State;
            this.Zipcode = Zipcode;
            this.Phone = Phone;
            this.Fax = Fax;
            this.Website = Website;
        }
    }
}

