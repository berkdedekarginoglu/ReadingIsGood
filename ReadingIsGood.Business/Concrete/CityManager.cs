using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.DataAccess.Abstract;
using System.Collections.Generic;

namespace ReadingIsGood.Business.Concrete
{
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }
        public IEnumerable<City> GetAll()
        {
            return _cityDal.GetAll();
        }
    }
}
