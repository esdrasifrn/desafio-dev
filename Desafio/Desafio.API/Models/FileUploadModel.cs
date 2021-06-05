using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.API.Model
{
    public class FileUploadModel
    {
        public string Arquivo { set; get; }       

        public Stream ToStream()
        {           
            return new MemoryStream(FromBase64());
        }       

        public byte[] FromBase64()
        {
            return Convert.FromBase64String(Arquivo);
        }
    }
}
