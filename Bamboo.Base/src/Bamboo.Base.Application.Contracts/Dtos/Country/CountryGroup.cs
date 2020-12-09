using Newtonsoft.Json;
using System;

namespace Bamboo.Base.Dtos
{
    public class CreateCountryGroupDto
    {

    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CountryGroupDto : CreateCountryGroupDto
    {

    }
}