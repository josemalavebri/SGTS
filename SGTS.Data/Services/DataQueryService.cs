using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SGTS.Models.DTOs;

namespace SGTS.Data.Services;

public class DataTableQueryService
{
    public async Task<(IEnumerable<T>, int, int)> QueryAsync<T>(
        IQueryable<T> baseQuery,
        DataTableRequest request,
        Func<string, Expression<Func<T, bool>>> searchBuilder = null)
    {
        var totalRecords = await baseQuery.CountAsync();

        var filteredQuery = baseQuery;

        if (!string.IsNullOrEmpty(request.Search?.Value) && searchBuilder != null)
        {
            var searchExpression = searchBuilder(request.Search.Value);
            filteredQuery = filteredQuery.Where(searchExpression);
        }

        var totalRecordsFiltered = await filteredQuery.CountAsync();

        var orderColumnIndex = request.Order?.FirstOrDefault()?.Column ?? 0;
        var orderColumnName = request.Columns?[orderColumnIndex]?.Data ?? "Id";
        var orderDirection = request.Order?.FirstOrDefault()?.Dir ?? "asc";

        filteredQuery = ApplyOrdering(filteredQuery, orderColumnName, orderDirection);

        var items = await filteredQuery
            .Skip(request.Start)
            .Take(request.Length)
            .ToListAsync();

        return (items, totalRecords, totalRecordsFiltered);
    }

    private IQueryable<T> ApplyOrdering<T>(IQueryable<T> query, string column, string direction)
    {
        if (string.IsNullOrEmpty(column))
            column = "Id";

        var property = typeof(T).GetProperties()
            .FirstOrDefault(p => p.Name.Equals(column, StringComparison.OrdinalIgnoreCase));

        column = property?.Name ?? "Id";

        return direction.ToLower() == "desc"
            ? query.OrderByDescending(e => EF.Property<object>(e, column))
            : query.OrderBy(e => EF.Property<object>(e, column));
    }
}