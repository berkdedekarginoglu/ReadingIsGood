using System.Collections.Generic;

namespace ReadingIsGood.Core.Entities.Concrete
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public string PlateNo { get; set; }
        public string PhoneCode { get; set; }
        public ICollection<Address> Adresses { get; set; }
        public Country Country { get; set; }
    }
}
