using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Domain.Entities
{
    public class TipoTransacao
    {
        private IList<TransacaoItem> _transacaoItens;

        public int TipoTransacaoId { get; set; }
        public string Descricao { get; set; }
        public string Natureza { get; set; }
        public string Sinal { get; set; }
        public virtual ICollection<TransacaoItem> TransacaoItens { get => _transacaoItens; set { } }

        public TipoTransacao(string descricao, string natureza, string sinal)
        {
            Descricao = descricao;
            Natureza = natureza;
            Sinal = sinal;
        }

        public TipoTransacao()
        {

        }

        public void AddTransacao(TransacaoItem transacao)
        {
            _transacaoItens.Add(transacao);
        }
    }
}
