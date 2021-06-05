using Desafio.Domain.DTO;
using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Desafio.Domain.Interfaces.Services
{
    public interface IServiceTransacao : IServiceBase<TransacaoItem>
    {
        public List<Loja> ProcessaSalvamento(Stream arquivo);
    }
}
