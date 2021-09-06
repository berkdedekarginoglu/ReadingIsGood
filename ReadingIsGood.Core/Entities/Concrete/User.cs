using System;
using System.Collections.Generic;

namespace ReadingIsGood.Core.Entities.Concrete
{
    public class User : IEntity
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }

        public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<UserAddress> UserAddresses { get; set; }
        public bool EmailConfirmed { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        
    }
}
