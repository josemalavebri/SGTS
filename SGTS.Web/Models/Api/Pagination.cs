namespace SGTS.Web.Models.Api
{
    public class Pagination
    {

        public int Drawn { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalRecordsFiltered { get; set; }

    }
}