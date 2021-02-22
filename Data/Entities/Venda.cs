using System;

namespace Data.Entities
{
    public class Venda
    {
        public Venda() { }

        public Venda(int id, DateTime data)
        {
            Id = id;
            Data = data;
        }

        public int Id { get; set; }
        public bool Concluida { get; set; }
        public double Custo { get; set; }
        public DateTime Data { get; set; }
        public double Lucro { get; set; }        
        public double ValorVenda { get; set; }        
    }
}
