using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdvantureWork.Common.DTO
{
    public class AppUserDTO
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string Avatar { get; set; }

        public DateTime? BirthDay { get; set; }

        public bool? Status { get; set; }

        public bool? Gender { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public string UserName { get; set; }

        public string Department { get; set; }
        public string Position { get; set; }

        public string Country { get; set; }
        public string CountryRegionCode { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string StrBirthDay { get; set; }

        public ICollection<string> Roles { get; set; }


    }
}