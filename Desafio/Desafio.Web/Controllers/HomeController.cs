using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repository;
using Desafio.Domain.Interfaces.Services;
using Desafio.Infra.Helpers;
using Desafio.Infra.Interfaces;
using Desafio.Web.Helpers;
using Desafio.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Desafio.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpUserAgent _httpUserAgent;
        private readonly IServiceTransacao _serviceTransacao;
        private readonly ILojaRepository _lojaRepository;


        public HomeController(IHttpUserAgent httpUserAgent, IServiceTransacao serviceTransacao, ILojaRepository lojaRepository)
        {
            _httpUserAgent = httpUserAgent;
            _serviceTransacao = serviceTransacao;
            _lojaRepository = lojaRepository;
        }

        public IActionResult Index()
        {
            return View(new FileUploadModel());
        }

        public IActionResult ListaLojas()
        {
            IEnumerable<Loja> lojas;
            lojas = _lojaRepository.ObterTodos().ToList();
            return View(lojas);
        }

        [HttpPost]
        public async Task<IActionResult> UploadArquivo(IFormFile arquivoCNAB)
        {
            ApiResult apiResult;

            var jsonBase64 = Util.ConvertFormFileParaBase64(arquivoCNAB);

            apiResult = await _httpUserAgent.PostAsync<string, ApiResult>("api/file", jsonBase64);

            if (apiResult.Success)
            {
                return RedirectToAction("ListaLojas", "Home");
            }
            else
            {
                return View();
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
