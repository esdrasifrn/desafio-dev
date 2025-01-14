﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infra.Extensions
{
    public static class HttpExtensions
    {        
        public static HttpContent ToHttpContent(this object obj)
        {
            HttpContent httpContent = null;

            if (obj != null)
            {
                var ms = new MemoryStream();
                SerializeJsonIntoStream(obj, ms);
                ms.Seek(0, SeekOrigin.Begin);
                httpContent = new StreamContent(ms);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return httpContent;
        }

        public static void SerializeJsonIntoStream(object value, Stream stream)
        {
            using (var sw = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
            using (var jtw = new JsonTextWriter(sw) { Formatting = Formatting.None })
            {
                var js = new JsonSerializer();
                js.Serialize(jtw, value);
                jtw.Flush();
            }
        }

        public static async Task<T> ReadAsObjectAsync<T>(this HttpContent content)
        {
            var responseStr = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseStr);
        }
    }
}
