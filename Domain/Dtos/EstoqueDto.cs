using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class EstoqueDto
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public ProdutoDto ProdutoDto { get; set; }
    }
}
