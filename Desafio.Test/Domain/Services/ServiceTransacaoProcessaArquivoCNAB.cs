using Desafio.Domain.Services;
using Desafio.Test.Domain.Factories;
using Xunit;

namespace Desafio.Test.Domain.Services
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
