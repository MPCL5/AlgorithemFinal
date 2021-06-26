using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AlgorithemFinal.Utiles.Pagination
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = pageSize == -1 ? 1 : (int) Math.Ceiling(count / (double) pageSize);

            AddRange(items);
        }

        public int PageIndex { get; }
        public int TotalPages { get; }

        // public bool HasPreviousPage => PageIndex > 1;
        //
        // public bool HasNextPage => PageIndex < TotalPages;

        public PaginatedResult<T> Result => new()
            {List = this, TotalPages = TotalPages, Page = PageIndex, Count = Count};

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, PaginationParams paginationParams)
        {
            return await CreateAsync(source, paginationParams.Page, paginationParams.PageSize);
        }
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            if (pageIndex < 1)
                pageIndex = 1;

            if (pageSize is < -1 or 0)
                pageSize = 10;

            if (pageSize != -1)
                source = source.Skip((pageIndex - 1) * pageSize).Take(pageSize);


            return new PaginatedList<T>(await source.ToListAsync(), count, pageIndex, pageSize);
        }
    }
}