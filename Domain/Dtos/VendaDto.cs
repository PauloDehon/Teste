using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class VendaDto
    {
        public int Id { get; set; }
        public bool Concluida { get; set; }
        public double Custo { get; set; }
        public DateTime Data { get; set; }
        public double Lucro { get; set; }
        public double ValorVenda { get; set; }
    }
}
