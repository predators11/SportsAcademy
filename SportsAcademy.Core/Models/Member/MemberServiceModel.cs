﻿namespace SportsAcademy.Core.Models.Member
{
    public class MemberServiceModel
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? Email { get; set; } = null;
    }
}
