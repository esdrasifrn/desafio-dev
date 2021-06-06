using Desafio.API.Helpers;
using Desafio.API.Model;
using Desafio.Domain.Interfaces.Services;
using Desafio.Infra.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
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

        /// <summary>
        /// Recebe um arquivo CNAB em base64 
        /// </summary>
        /// <param name="arquivoBase64">Deve ser passado uma string de um arquivo CNAB no formato base64</param>
        /// <returns>Retorna o resultado do processamento (sucesso ou não)</returns>
        [Route("~/api/file"), HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ApiResult>> UploadArquivoCNAB([FromBody] string arquivoBase64)
        {
            try
            {
                var arquivoCnab = Util.NormalizeFormat(arquivoBase64);

                if (arquivoBase64 is null)
                    return BadRequest(arquivoCnab);

                var response = JsonSerializer.Deserialize<FileUploadModel>(arquivoCnab, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });

                if (!Util.IsBase64String(response.Arquivo))
                    return BadRequest(response.Arquivo);

                if (_serviceTransacao.ProcessaSalvamento(response.ToStream()).Count > 1)
                    return Ok(Result(true, "Arquivo processado com sucesso."));
            }

            catch (Exception ex)
            {
                return Result(false, "Ocorreu um erro ao processar o arquivo: Erro:" + ex.Message, null);
            }

            return BadRequest();
        }
    }
}
