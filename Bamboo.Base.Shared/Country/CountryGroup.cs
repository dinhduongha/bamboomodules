using Newtonsoft.Json;
using System;

namespace Bamboo.Base.Shared
{
    public class CreateCountryGroupDto
    {

    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CountryGroupDto : CreateCountryGroupDto
    {

    }
}