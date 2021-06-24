using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Utiles.Pagination
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> List { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
    }
}
