namespace ApiServico.Controllers.Helpers
{
    public class PagedResponse<T>
    {
        public int Page { get; set; }
        public int Limit { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }

        public IEnumerable<T> Data { get; set; } = new List<T>();
    }
}
