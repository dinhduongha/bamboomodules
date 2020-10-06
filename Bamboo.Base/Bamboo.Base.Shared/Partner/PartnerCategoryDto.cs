using System;
using Newtonsoft.Json;

using Abp.Application.Services.Dto;
using Bamboo.Common;

namespace Bamboo.Base.Shared
{
    public class PartnerCategoryExtraData : IExtraData
    {

    }

    public class CreatePartnerCategoryDto: EntityDto<Guid>
    {
        public int CurrencyId { get; set; }

        public double Rate { get; set; }

        public DateTime? Date { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PartnerCategoryDto : CreatePartnerCategoryDto
    {
    }
}