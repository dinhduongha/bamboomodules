using System;

using Newtonsoft.Json;

using Bamboo.Common;

namespace Bamboo.Base.Shared
{
    public class CurrencyExtraData : IExtraData
    {

    }

    public class CreateCurrencyDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CurrencyDto : CreateCurrencyDto
    {
        public int Id { get; set; }
    }
}