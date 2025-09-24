namespace ApiServico.Controllers.Helpers
{
    public interface IPaginatedFilter
    {
        string? Search { get; set; }

        int Page { get; set; }

        int Limit { get; set; }
    }
}
