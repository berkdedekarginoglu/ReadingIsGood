namespace ReadingIsGood.Core.Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string OperationClaimId { get; set; }
        public User User { get; set; }
        public OperationClaim OperationClaim { get; set; }

    }
}
