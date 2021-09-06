using System.Collections.Generic;

namespace ReadingIsGood.Core.Entities.Concrete
{
    public class Country : IEntity
    {
        public int Id { get; set; }
        public string BinaryCode { get; set; }
        public string TripleCode { get; set; }
        public string Name { get; set; }
        public string PhoneCode { get; set; }
        public IEnumerable<City> Cities { get; set; }
    }
}
