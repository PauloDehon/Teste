using System;

namespace Data.Entities
{
    public class Produto
    {
        public Produto() { }

        public Produto(int id, string tipo, double precoCusto, double precoVenda, string tamanho, string cor, DateTime dataEntrada)
        {
            Id = id;
            Cor = cor;
            DataEntrada = dataEntrada;
            PrecoCusto = precoCusto;
            PrecoVenda = precoVenda;
            Tipo = tipo;
            Tamanho = tamanho;
        }

        public int Id { get; set; }
        public string Cor { get; set; }
        public DateTime DataEntrada { get; set; }
        public double PrecoCusto { get; set; }
        public double PrecoVenda { get; set; }
        public string Tipo { get; set; }
        public string Tamanho { get; set; }        
    }
}
