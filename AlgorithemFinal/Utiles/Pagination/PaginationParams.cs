using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Utiles.Pagination
{
    public class PaginationParams
    {
        /// <summary>
        /// تعداد آیتم های موجود در صفحه
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// شماره صفحه
        /// </summary>
        public int Page { get; set; } = 1;
    }
}
