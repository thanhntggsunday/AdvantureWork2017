﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AdvantureWork.Common.Request
{
    public class UserUpdateRequest
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}