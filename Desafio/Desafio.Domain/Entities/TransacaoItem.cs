using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Domain.Entities
{
    /// <summary>
    /// Esta classe representa um item transacionado do arquivo CNAB 
    /// </summary>
    public class TransacaoItem
    {
        public int TransacaoId { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string CpfBeneficiario { get; set; }
        public virtual Loja Loja { get; set; }
        public virtual string Cartao { get; set; }
        public virtual TipoTransacao TipoTransacao { get; set; }       

        public TransacaoItem(decimal valor, DateTime data, DateTime hora, string cpfBeneficiario, Loja loja, string cartao, TipoTransacao tipoTransacao)
        {
            Valor = valor;
            Data = data;
            Hora = hora;
            CpfBeneficiario = cpfBeneficiario;
            Loja = loja;
            Cartao = cartao;
            TipoTransacao = tipoTransacao;            
        }

        public TransacaoItem()
        {

        }
    }
}
