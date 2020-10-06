using System;
using Newtonsoft.Json;

using Abp.Application.Services.Dto;

using Bamboo.Common;

namespace Bamboo.Base.Shared
{
    public class PartnerExtraData : IExtraData
    {

    }

    public class CreatePartnerDto: EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PartnerDto : CreatePartnerDto
    {
    }
}