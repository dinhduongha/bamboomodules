using System;
using Newtonsoft.Json;
using Abp.Application.Services.Dto;

using Bamboo.Common;

namespace Bamboo.Base.Shared
{
    public class PartnerTitleExtraData : IExtraData
    {

    }

    public class CreatePartnerTitleDto: EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PartnerTitleDto : CreatePartnerTitleDto
    {
    }
}