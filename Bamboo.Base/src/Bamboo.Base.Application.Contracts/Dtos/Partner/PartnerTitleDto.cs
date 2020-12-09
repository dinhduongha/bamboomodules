using System;
using Newtonsoft.Json;

using Bamboo.Common;
using Volo.Abp.Application.Dtos;

namespace Bamboo.Base.Dtos
{
    public class PartnerTitleExtraData
    {

    }

    public class CreatePartnerTitleDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PartnerTitleDto : CreatePartnerTitleDto, IEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}