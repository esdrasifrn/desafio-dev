using Desafio.Domain.Interfaces.Repository;
using Desafio.Domain.Interfaces.Services;
using Desafio.Domain.Services;
using Desafio.Infra.Http;
using Desafio.Infra.Interfaces;
using Desafio.Infra.RepositoryEF;
using Microsoft.AspNetCore.Http;
using SDK.DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Desafio.Application
{
    public class DependencyInjection
    {
        public static void RegisterDependencies(ISdkContainerBuilder builder)
        {            
            RegisterDesafioDependencies(builder);
        }

        private static void RegisterDesafioDependencies(ISdkContainerBuilder builder)
        {
            builder.RegisterSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.RegisterScoped<IHttpUserAgent>(c =>
             new ClientAgent("http://host.docker.internal:20001/",
             new HttpClientHandler
             {
                 ServerCertificateCustomValidationCallback =
             (message, cert, chain, errors) => { return true; }
             })
            );

            builder.RegisterScoped<ITransacaoItemRepository, TransacaoItemRepository>();
            builder.RegisterScoped<IServiceTransacao, ServiceTransacao>();

            builder.RegisterScoped<ITipoTransacaoRepository, TipoTransacaoRepository>();
            

            
            builder.RegisterScoped<ILojaRepository, LojaRepository>();
            



        }
    }
}
