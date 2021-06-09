using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Utiles.Pagination
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = pageSize == -1 ? 1 : (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public PaginatedResult<T> Result
        {
            get
            {
                return new PaginatedResult<T> { List = this, TotalPages = this.TotalPages, Page = this.PageIndex, PageSize = this.Count };
            }
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            if (pageIndex < 1)
                pageIndex = 1;

            if (pageSize < -1 || pageSize == 0)
                pageSize = 10;

            if (pageSize != -1)
                source = source.Skip((pageIndex - 1) * pageSize).Take(pageSize);


            return new PaginatedList<T>(await source.ToListAsync(), count, pageIndex, pageSize);
        }
    }
}
