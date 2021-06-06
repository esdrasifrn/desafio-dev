using Desafio.Domain.Services;
using Desafio.Test.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Desafio.Test.Services
{
    public class ServiceTransacaoProcessaArquivoCNAB
    {
        [Fact]
        public void ProcessaArquivoCNABFuncionando_ChamadoComStreamValido_RetornaNumeroLinhasIgualAoStream()
        {
            int linhasDoStream = ArquivoCNABFactory.GetNumeroLinhasStream();

            //Arrange
            var arquivo = ArquivoCNABFactory.GetArquivoCNABValido();

            var transacaoService = new ServiceTransacao();

            //Act
            var resultadoProcessamento = transacaoService.ProcessaArquivoCNAB(arquivo);

            //Assert
            Assert.Equal(linhasDoStream, resultadoProcessamento.Count);
        }
    }
}
