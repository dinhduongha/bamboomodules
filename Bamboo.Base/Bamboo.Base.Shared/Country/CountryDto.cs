using System;
using Newtonsoft.Json;

using Abp.Domain.Entities;
using Abp.Application.Services.Dto;

using Bamboo.Common;

namespace Bamboo.Base.Shared
{
    public class CountryExtraData : IExtraData
    {

    }

    public class CreateCountryDto: EntityDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CountryDto : CreateCountryDto
    {
    }
}