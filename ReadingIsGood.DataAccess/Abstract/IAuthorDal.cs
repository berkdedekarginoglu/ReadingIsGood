﻿using ReadingIsGood.Core.DataAccess;
using ReadingIsGood.Core.Entities.Concrete;

namespace ReadingIsGood.DataAccess.Abstract
{
    public interface IAuthorDal : IEntityRepository<Author>
    {
    }
}
