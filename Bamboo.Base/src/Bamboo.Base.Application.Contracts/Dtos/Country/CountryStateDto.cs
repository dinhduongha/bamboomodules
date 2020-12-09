using Newtonsoft.Json;
using System;

namespace Bamboo.Base.Dtos
{
    public class CreateCountryStateDto
    {
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CountryStateDto : CreateCountryStateDto
    {

    }
}