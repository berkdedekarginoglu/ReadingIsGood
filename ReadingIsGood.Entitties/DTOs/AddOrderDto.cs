namespace ReadingIsGood.Entities.DTOs
{
    public class AddOrderDto
    {
        public string UserId { get; set; }
        public string AddressId { get; set; }
        public string BookId { get; set; }
        public int Quantity { get; set; }

    }
}
