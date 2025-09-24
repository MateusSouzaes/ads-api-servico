namespace ApiServico.Controllers.Helpers
{
    public class ChamadoFilter : PaginatedFilter
    {
        public string? Situacao {  get; set; } = null;
    }
}
