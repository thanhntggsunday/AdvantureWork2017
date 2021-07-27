using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantureWork.Model.Entities
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser<Guid>
    {
        public string FullName { set; get; }

        public string Address { set; get; }

        public string Avatar { get; set; }

        public DateTime? BirthDay { set; get; }

        public bool? Status { get; set; }

        public bool? Gender { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }

        public string Country { get; set; }
        public string CountryRegionCode { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        // public int Age { get; set; }
    }
}