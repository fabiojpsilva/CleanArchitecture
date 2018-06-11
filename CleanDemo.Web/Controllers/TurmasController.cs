using System.Linq;
using CleanDemo.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanDemo.Web.Controllers
{
    [Route("api/[controller]")]
    public class TurmasController : Controller
    {
        // POST: /turmas
        [HttpPost]
        public IActionResult Post([FromServices] CadastrarTurmaInteractor cadastrarTurmaInteractor, [FromBody] CadastrarTurmaInput turma)
        {
            CadastrarTurmaOutput interactionResponse = cadastrarTurmaInteractor.Handle(turma);
            if (interactionResponse.Sucesso)
                return Ok(interactionResponse.TurmaId);
            else
                return BadRequest($"{interactionResponse.Status}: {interactionResponse.Mensagem}");
        } 
    }
}
