using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SGTS.Models.DTOs;

namespace SGTS.Data.Services;

public class DataTableQueryService
{
    public async Task<(IEnumerable<T>, int, int)> QueryAsync<T>(
        IQueryable<T> baseQuery,
        DataTableRequestDTO request,
        Func<string, Expression<Func<T, bool>>>? searchBuilder = null)
    {
        var totalRecords = await baseQuery.CountAsync();

        var filteredQuery = baseQuery;

        if (!string.IsNullOrWhiteSpace(request.Search?.Value) && searchBuilder != null)
        {
            var searchExpression = searchBuilder(request.Search.Value);
            filteredQuery = filteredQuery.Where(searchExpression);
        }

        var totalRecordsFiltered = await filteredQuery.CountAsync();

        var orderColumnIndex = request.Order?.FirstOrDefault()?.Column ?? 0;
        var orderColumnName = request.Columns?.ElementAtOrDefault(orderColumnIndex)?.Data;
        var orderDirection = request.Order?.FirstOrDefault()?.Dir ?? "asc";

        filteredQuery = ApplyOrdering(filteredQuery, orderColumnName, orderDirection);

        var items = await filteredQuery
            .Skip(request.Start)
            .Take(request.Length)
            .ToListAsync();

        return (items, totalRecords, totalRecordsFiltered);
    }

    private IQueryable<T> ApplyOrdering<T>(IQueryable<T> query, string? column, string direction)
    {
        var properties = typeof(T).GetProperties();

        var property = !string.IsNullOrWhiteSpace(column)
            ? properties.FirstOrDefault(p =>
                p.Name.Equals(column, StringComparison.OrdinalIgnoreCase))
            : null;

        property ??= properties.FirstOrDefault(p =>
            p.Name.StartsWith("Id", StringComparison.OrdinalIgnoreCase));

        if (property == null)
            throw new InvalidOperationException(
                $"La entidad '{typeof(T).Name}' no posee una propiedad cuyo nombre comience con 'Id'.");

        return direction.Equals("desc", StringComparison.OrdinalIgnoreCase)
            ? query.OrderByDescending(e => EF.Property<object>(e, property.Name))
            : query.OrderBy(e => EF.Property<object>(e, property.Name));
    }
}