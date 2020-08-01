using System;
using System.Collections.Generic;
using System.Linq;

namespace Todo.Application.Services.Models
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = CountAmountOfPages(count, pageSize);

            AddRange(items);
        }

        private int CountAmountOfPages(int itemsCount, int pageSize)
        {
            return (int)Math.Ceiling(itemsCount / (double)pageSize);
        }

        public static PagedList<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var paginatedItems = PaginateItems(source, pageNumber, pageSize);
            var count = source.Count();

            return new PagedList<T>(paginatedItems, count, pageNumber, pageSize);
        }

        private static List<T> PaginateItems(IQueryable<T> source, int pageNumber, int pageSize)
        {
            return source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}