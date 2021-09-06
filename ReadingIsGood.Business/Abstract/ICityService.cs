using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Results;
using System.Collections.Generic;

namespace ReadingIsGood.Business.Abstract
{
    public interface ICityService
    {
        IEnumerable<City> GetAll();
    }
}
