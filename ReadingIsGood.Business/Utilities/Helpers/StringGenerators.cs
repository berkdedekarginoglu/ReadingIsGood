using System;

namespace ReadingIsGood.Business.Utilities.Helpers
{
    public static class StringGenerators
    {
        public static string GenerateOrderNo()
        {
            return (Guid.NewGuid().ToString()).Split('-')[0] + new Random().Next(1000000, 9999999).ToString();
        }
    }
}
