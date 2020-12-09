using System;
using Newtonsoft.Json;

using Bamboo.Common;
using Volo.Abp.Application.Dtos;

namespace Bamboo.Base.Dtos
{
    public class PartnerCategoryExtraData
    {

    }

    public class CreatePartnerCategoryDto
    {
        public int CurrencyId { get; set; }

        public double Rate { get; set; }

        public DateTime? Date { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PartnerCategoryDto : CreatePartnerCategoryDto, IEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}