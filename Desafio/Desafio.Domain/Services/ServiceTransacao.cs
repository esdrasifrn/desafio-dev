using Desafio.Domain.DTO;
using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repository;
using Desafio.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Desafio.Domain.Services
{
    /// <summary>
    /// Classe responsável pelo serviço de transacionar um arquivo CNAB
    /// </summary>
    public class ServiceTransacao : IServiceTransacao
    {
        private readonly ITransacaoItemRepository _transacaoItemRepository;
        private readonly ITipoTransacaoRepository _tipoTransacaoRepository;
        private readonly ILojaRepository _lojaRepository;

        public ServiceTransacao(ITransacaoItemRepository transacaoRepository, ITipoTransacaoRepository tipoTransacaoRepository, ILojaRepository lojaRepository)
        {
            _transacaoItemRepository = transacaoRepository;
            _tipoTransacaoRepository = tipoTransacaoRepository;
            _lojaRepository = lojaRepository;
        }

        public ServiceTransacao()
        {
                
        }

        #region Métodos genéricos da classe
        public TransacaoItem Salvar(TransacaoItem entity)
        {
            return _transacaoItemRepository.Salvar(entity);
        }

        public void Atualizar(TransacaoItem entity)
        {
            _transacaoItemRepository.Atualizar(entity);
        }

        public IEnumerable<TransacaoItem> Buscar(Expression<Func<TransacaoItem, bool>> predicado)
        {
            return _transacaoItemRepository.Buscar(predicado);
        }

        public TransacaoItem BuscarEntidade(Expression<Func<TransacaoItem, bool>> predicado)
        {
            return _transacaoItemRepository.BuscarEntidade(predicado);
        }

        public TransacaoItem ObterPorId(int id)
        {
            return _transacaoItemRepository.ObterPorId(id);
        }

        public IEnumerable<TransacaoItem> ObterTodos()
        {
            return _transacaoItemRepository.ObterTodos();
        }

        public IEnumerable<TransacaoItem> ObterTodosPaginado(int skip, int take)
        {
            return _transacaoItemRepository.ObterTodosPaginado(skip, take);
        }

        public void Remover(TransacaoItem entity)
        {
            _transacaoItemRepository.Remover(entity);
        }

        #endregion

        #region Métodos específicos da classe
              
        /// <summary>
        /// Retorna uma lista de lojas únicas processadas do arquivo com suas operações
        /// </summary>
        /// <param name="arquivo">arquivo com os itens de transações/operações</param>
        /// <returns>Lista de lojas processadas</returns>
        public List<Loja> ProcessaSalvamento(Stream arquivo)
        {
            //chama o processamento do arquivo
            List<TransacaoDTO> ListaTransacaoDTO = ProcessaArquivoCNAB(arquivo);

            List<TransacaoItem> transacaoItems = new List<TransacaoItem>();
            List<Loja> listaLojas = new List<Loja>();

            Loja loja;
            TipoTransacao tipoTransacao;
            TransacaoItem transacaoItem;

            try
            {
                foreach (var trasacaoLinha in ListaTransacaoDTO)
                {
                    decimal valorFormatado;
                    if (trasacaoLinha.Tipo == 2 || trasacaoLinha.Tipo == 3 || trasacaoLinha.Tipo == 9)
                    {
                        valorFormatado = -trasacaoLinha.Valor;
                    }
                    else
                    {
                        valorFormatado = trasacaoLinha.Valor;
                    }

                    //Gerencia a criação de novas lojas
                    loja = ProcessaLoja(trasacaoLinha);

                    //Armazena as lojas processadas
                    listaLojas.Add(loja);

                    tipoTransacao = _tipoTransacaoRepository.ObterPorId(trasacaoLinha.Tipo);

                    transacaoItem = new TransacaoItem(
                        valor: valorFormatado,
                        data: trasacaoLinha.Data,
                        hora: trasacaoLinha.Hora,
                        cpfBeneficiario: trasacaoLinha.CPF,
                        loja: loja,
                        cartao: trasacaoLinha.Cartao,
                        tipoTransacao: tipoTransacao
                        );

                    _transacaoItemRepository.Salvar(transacaoItem);

                    transacaoItems.Add(transacaoItem);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaLojas;
        }

        public List<TransacaoDTO> ProcessaArquivoCNAB(Stream arquivo)
        {
            List<string> linhas = new List<string>();
            List<TransacaoDTO> ListaTransacaoDTO = new List<TransacaoDTO>();

            try
            {
                using StreamReader reader = new StreamReader(arquivo);
                while (!reader.EndOfStream)
                {
                    linhas.Add(reader.ReadLine());
                }

                foreach (var linha in linhas)
                {
                    if (!String.IsNullOrEmpty(linha))
                    {
                        var dia = int.Parse(linha.Substring(7, 2));
                        var mes = int.Parse(linha.Substring(5, 2));
                        var ano = int.Parse(linha.Substring(1, 4));
                        var hora = int.Parse(linha.Substring(42, 2));
                        var minuto = int.Parse(linha.Substring(44, 2));
                        var segundo = int.Parse(linha.Substring(46, 2));                        


                        TransacaoDTO transacaoDTO = new TransacaoDTO
                        {
                            Tipo = int.Parse(linha.Substring(0, 1)),
                            Data = new DateTime(ano, mes, dia),
                            Valor = Decimal.Parse(linha.Substring(9, 10))/100,
                            CPF = linha.Substring(19, 11),
                            Cartao = linha.Substring(30, 12),
                            Hora = new DateTime(ano, mes, dia, hora, minuto, segundo),
                            DonoLoja = linha.Substring(48, 14),
                            NomeLoja = linha.Substring(62, 18)
                        };

                        ListaTransacaoDTO.Add(transacaoDTO);
                    }
                }
            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }

            return ListaTransacaoDTO;
        }

        private Loja ProcessaLoja(TransacaoDTO trasacaoLinha)
        {
            Loja loja;
            var lojaExiste = _lojaRepository.BuscarEntidade(c => c.Nome.Equals(trasacaoLinha.NomeLoja.Trim()));

            if (lojaExiste != null)
            {
                loja = lojaExiste;
            }
            else
            {
                loja = new Loja(
                    dono: trasacaoLinha.DonoLoja,
                    nome: trasacaoLinha.NomeLoja
                    );
            }

            return loja;
        }

        #endregion
    }
}
