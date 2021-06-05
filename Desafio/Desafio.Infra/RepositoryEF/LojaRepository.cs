using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repository;
using Desafio.Infra.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Infra.RepositoryEF
{
    public class LojaRepository : EFRepository<Loja>, ILojaRepository
    {
        public LojaRepository(DesafioContext desafioContext, IConfiguration configuration) : base(desafioContext, configuration)
        {

        }
    }
}
