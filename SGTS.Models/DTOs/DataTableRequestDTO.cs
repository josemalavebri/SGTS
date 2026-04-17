namespace SGTS.Models.DTOs;

public class DataTableRequest
{
    public int Draw { get; set; }
    public int Start { get; set; }
    public int Length { get; set; }

    public List<Order> Order { get; set; }
    public List<Column> Columns { get; set; }
    public Search Search { get; set; }
}

public class Order
{
    public int Column { get; set; }
    public string Dir { get; set; }
}

public class Column
{
    public string Data { get; set; }
}

public class Search
{
    public string Value { get; set; }
}