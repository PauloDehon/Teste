namespace Data.Entities
{
    public class Carrinho
    {
        public Carrinho() { }
        public Carrinho(int produtoId, int vendaId)
        {
            ProdutoId = produtoId;
            VendaId = vendaId;
        }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int VendaId { get; set; }
        public Venda Venda { get; set; }
    }
}
