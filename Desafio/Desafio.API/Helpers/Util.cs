using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Desafio.API.Helpers
{
    public static class Util
    {
        public static bool IsBase64String(string base64)
        {
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);
        }

        public static string NormalizeFormat(string base64File)
        {
            if (base64File.Contains("arquivo"))
            {
                return base64File;
            }
            else
            {
                var data = new
                {
                    arquivo = base64File,
                };
               
                return JsonSerializer.Serialize(data);
            }
        }
    }
}
