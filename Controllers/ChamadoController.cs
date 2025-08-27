using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiServico.Controllers
{
    [Route("/chamados")]
    [ApiController]
    public class ChamadoController : ControllerBase
    {

        private static List<Chamado> _listaChamados = new List<Chamado>
        {
            new Chamado() { 
                Id = 1, Titulo = "Erro na Tela de Acesso", Descricao = "O usuário não conseguiu logar" },
            new Chamado() { 
                Id = 2, Titulo = "Sistema com lentidão", Descricao = "Demora no carregamento das telas"}
        };

        private static int _proximoId = 3;

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            return Ok(_listaChamados);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Chamado novoChamado)
        {
            novoChamado.Id = _proximoId++;
            novoChamado.Status = "Aberto";

            _listaChamados.Add(novoChamado);

            return Created("", novoChamado);
        }
    }
}
