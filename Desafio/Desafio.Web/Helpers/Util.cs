using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Desafio.Web.Helpers
{
    public static class Util
    {
        public static string ConvertFormFileParaBase64(IFormFile file)
        {
            string arquivoBase64 = null;

            if (file.Length > 0)
            {
                using var ms = new MemoryStream();
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                arquivoBase64 = Convert.ToBase64String(fileBytes);
            }

            var data = new
            {
                arquivo = arquivoBase64,
            };

            var options = JsonCamelCase();
            string json = JsonSerializer.Serialize(data, options);

            return json;
        }

        public static JsonSerializerOptions JsonCamelCase()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            return options;
        }
    }
}
