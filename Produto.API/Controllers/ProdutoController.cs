using Microsoft.AspNetCore.Mvc;
using Produto.Domain.Entities;
using Produto.Domain.ViewModels;
using Produto.Service.Interface;

namespace Produto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("BuscarProdutos")]
        public async Task<ActionResult<IEnumerable<ProdutoDomain>>> GetProdutos()
            => Ok(await _produtoService.GetProduto());

        [HttpGet("BuscarProduto/{id:Guid}")]
        public async Task<ActionResult<ProdutoDomain>> GetProdutoById([FromRoute] Guid id)
        {
            try
            {
                var resposta = await _produtoService.GetById(id);
                return resposta;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("AdicionarProduto")]
        public ActionResult<ProdutoViewModel> AddProduto([FromBody] ProdutoViewModel Produto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Detail = "Os parametros fornecidos são invalidos"
                });
            }
            //Produto.Id = Guid.NewGuid();
            return Created("", _produtoService.AddProduto(Produto));
        }

        [HttpPut("AtualizarProduto{id:Guid}")]
        public ActionResult<ProdutoDomain> UpdateProduto([FromRoute] Guid id, [FromBody] ProdutoDomain Produto)
        {
            try
            {
                var resposta = Created("", _produtoService.UpdateProduto(id, Produto));
                return resposta;
            }
            catch
            {
                return NotFound("Erro ao atualizar o produto.");
            }
        }

        [HttpDelete("DeletarProduto/{id:Guid}")]
        public ActionResult<bool> DeleteProdutoById([FromRoute] Guid id)
        {
            try
            {
                var resposta = Ok(_produtoService.DeleteProduto(id));
                return resposta;
            }
            catch
            {
                return NotFound("Erro ao deletar o produto.");
            }
        }
    }
}