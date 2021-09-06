using System.Collections.Generic;

namespace ReadingIsGood.Core.Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
