using System;
using Newtonsoft.Json;
using Volo.Abp.Application.Dtos;

namespace Bamboo.Base.Dtos
{
    public class CreateCurrencyRateDto 
    {
        public int CurrencyId { get; set; }

        public double Rate { get; set; }

        public DateTime? Date { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CurrencyRateDto : CreateCurrencyRateDto, IEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}