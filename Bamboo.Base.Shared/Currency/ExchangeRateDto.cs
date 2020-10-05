using Newtonsoft.Json;
using System;

namespace Bamboo.Base.Dto
{
    public class CreateExchangeRateDto
    {
        public int CurrencyId { get; set; }

        public double Rate { get; set; }

        public DateTime? Date { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ExchangeRateDto : CreateExchangeRateDto
    {
        public int Id { get; set; }

    }
}