using Newtonsoft.Json;
using System;

namespace Bamboo.Base.Shared
{
    public class CreateCountryStateDto
    {
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CountryStateDto : CreateCountryStateDto
    {

    }
}