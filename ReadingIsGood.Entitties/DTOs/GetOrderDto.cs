using System;

namespace ReadingIsGood.Entities.DTOs
{
    public class GetOrderDto
    {
        public string OrderNo { get; set; }
        public string AddressCity { get; set; }
        public string AddressDetails { get; set; }

        public string BookISBN { get; set; }
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public decimal BookPrice { get; set; }
        public int  Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string Status { get; set; }
    }
}
