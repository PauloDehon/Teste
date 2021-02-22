using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Helpers
{
    public class PageParams
    {
        public const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize 
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public string Tipo { get; set; } = string.Empty;
        public double Preco { get; set; } = 0;
    }
}
