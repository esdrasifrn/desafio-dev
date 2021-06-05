using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Web.Models
{
    public class FileUploadModel
    {
        public IFormFile ArquivoCNAB { set; get; }
        private string Data { set; get; }

        public Stream ToStream()
        {
            ToBase64();
            return new MemoryStream(FromBase64());
        }

        public string ToBase64()
        {
            if (ArquivoCNAB.Length > 0)
            {
                using var ms = new MemoryStream();
                ArquivoCNAB.CopyTo(ms);
                var fileBytes = ms.ToArray();
                Data = Convert.ToBase64String(fileBytes);                
            }

            return Data;
        }

        public byte[] FromBase64()
        {
            return Convert.FromBase64String(Data);
        }
    }
}
