using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

using JetBrains.Annotations;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TSoft.AnkiLovesGoogle.GoogleTranslate
{
    public class GoogleTranslateApi
    {
        private const string queryStringFormat = "https://translate.google.com/translate_a/single?client=t&sl=en&tl=ru&hl=en&dt=bd&dt=ex&dt=ld&dt=md&dt=qca&dt=rw&dt=rm&dt=ss&dt=t&dt=at&ie=UTF-8&oe=UTF-8&otf=1&rom=1&ssel=0&tsel=0&kc=3&tk=523072|51201&q={0}";

        public GoogleTranslateApi()
        {
        }

        [NotNull]
        public Dictionary<string, string[]> GetDefinitions([NotNull] string word)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(string.Format(queryStringFormat, word)).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject(content) as JArray;
                var definitionsArray = result[12] as JArray;
                return definitionsArray.ToDictionary(x => x[0].ToString(), x => x.Skip(1).OfType<JArray>().Select(z => z[0]).OfType<JArray>().Select(z => z[0].ToString()).ToArray());
            }
        }
    }
}