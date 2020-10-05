using System;

using Newtonsoft.Json;

namespace Bamboo.Base.Currency
{
    public class CreateCurrencyDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CurrencyDto : CreateCurrencyDto
    {
        public int Id { get; set; }
    }
}