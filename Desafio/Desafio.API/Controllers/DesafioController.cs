using Desafio.API.Model;
using Desafio.Domain.Interfaces.Services;
using Desafio.Infra.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Desafio.API.Controllers
{
    public class DesafioController : ControllerBase
    {
        private readonly IServiceTransacao _serviceTransacao;

        public DesafioController(IServiceTransacao serviceTransacao)
        {
           _serviceTransacao = serviceTransacao;
        }

        private ApiResult Result(bool success, string message, Exception ex = null)
        {
            return ApiResult.New(success, message, ex);
        }

        [Route("~/api/file"), HttpPost]
        public async Task<ApiResult> UploadArquivoCNAB([FromBody] string arquivoCNAB)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var response = JsonSerializer.Deserialize<FileUploadModel>(arquivoCNAB, options);
               
                 _serviceTransacao.ProcessaSalvamento(response.ToStream());

                return Result(true, "Arquivo processado com sucesso.");
            }
            catch (Exception ex)
            {
                return Result(false, "Ocorreu um erro ao processar o arquivo: Erro:" + ex.Message);                
            }           
        }
    }
}
