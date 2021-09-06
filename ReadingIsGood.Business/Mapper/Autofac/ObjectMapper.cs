using AutoMapper;
using ReadingIsGood.Business.Mapper.Autofac;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Entities.DTOs;
using System;

namespace ReadingIsGood.Business.Mapper2.Autofac
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperDto>();
            });

            return config.CreateMapper();

        });

        public static IMapper Mapper => lazy.Value;
    }

    
}
