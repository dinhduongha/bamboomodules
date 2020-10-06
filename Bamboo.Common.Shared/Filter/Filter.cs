using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bamboo.Filter
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class FilterBase
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 0;
        public string Keyword { get; set; }
        public string Format { get; set; }
        public List<KeyValuePair<string, string>> OrderBy { get; set; }
        public string ToUrlEncoded()
        {
            var keyValueContent = ToKeyValue(this);
            var formUrlEncodedContent = new FormUrlEncodedContent(keyValueContent);
            var urlEncodedString = formUrlEncodedContent.ReadAsStringAsync().GetAwaiter().GetResult();
            return urlEncodedString;
        }

        public static string ToUrlEncoded(object filter)
        {
            var keyValueContent = ToKeyValue(filter);
            var formUrlEncodedContent = new FormUrlEncodedContent(keyValueContent);
            var urlEncodedString = formUrlEncodedContent.ReadAsStringAsync().GetAwaiter().GetResult();
            return urlEncodedString;

        }

        /// https://geeklearning.io/serialize-an-object-to-an-url-encoded-string-in-csharp/
        public static IDictionary<string, string> ToKeyValue(object metaToken)
        {
            if (metaToken == null)
            {
                return null;
            }

            JToken token = metaToken as JToken;
            if (token == null)
            {
                return ToKeyValue(JObject.FromObject(metaToken));
            }

            if (token.HasValues)
            {
                var contentData = new Dictionary<string, string>();
                foreach (var child in token.Children().ToList())
                {
                    var childContent = ToKeyValue(child);
                    if (childContent != null)
                    {
                        contentData = contentData.Concat(childContent)
                                                 .ToDictionary(k => k.Key, v => v.Value);
                    }
                }

                return contentData;
            }

            var jValue = token as JValue;
            if (jValue?.Value == null)
            {
                return null;
            }

            var value = jValue?.Type == JTokenType.Date ?
                            jValue?.ToString("o", CultureInfo.InvariantCulture) :
                            jValue?.ToString(CultureInfo.InvariantCulture);

            return new Dictionary<string, string> { { token.Path, value } };
        }
    }

}