using System;
using Newtonsoft.Json;
using Abp.Application.Services.Dto;

namespace Bamboo.Base.Shared
{
    public class CreateCurrencyRateDto : EntityDto<Guid>
    {
        public int CurrencyId { get; set; }

        public double Rate { get; set; }

        public DateTime? Date { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CurrencyRateDto : CreateCurrencyRateDto
    {

    }
}