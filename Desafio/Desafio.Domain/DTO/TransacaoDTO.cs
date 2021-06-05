using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Domain.DTO
{
    public class TransacaoDTO
    {
        public int Tipo { get; set; }
        public DateTime Data { get; set; }
        public Decimal Valor { get; set; }
        public string CPF { get; set; }
        public string Cartao { get; set; }
        public DateTime Hora { get; set; }
        public string DonoLoja { get; set; }
        public string NomeLoja { get; set; }
       
    }
}
