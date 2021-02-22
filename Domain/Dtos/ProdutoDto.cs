using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataEntrada { get; set; }
        public int Quantidade { get; set; }
        public double PrecoCusto { get; set; }
        public double PrecoVenda { get; set; }
    }
}
