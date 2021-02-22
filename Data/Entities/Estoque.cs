using System;

namespace Data.Entities
{
    public class Estoque
    {
        public Estoque() { }

        public Estoque(int id, int quantidade, Produto produto)
        {
            Id = id;
            Quantidade = quantidade;
            Produto = produto;
        }

        public int Id { get; set; }
        public int Quantidade { get; set; }
        public Produto Produto { get; set; }
    }
}
