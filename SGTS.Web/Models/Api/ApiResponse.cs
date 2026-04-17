using System.Text.Json.Serialization;
using SGMF_backend.Models;

namespace SGTS.Web.Models.Api;

public class ApiRes<T>
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Message { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Pagination? Pagination { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T? Data { get; set; }

    public static ApiRes<T> Success(T? data = default, Pagination? paginacion = default)
        => new() { Pagination = paginacion, Data = data };

    public static ApiRes<T> Fail(string message)
        => new() { Message = message };
}

