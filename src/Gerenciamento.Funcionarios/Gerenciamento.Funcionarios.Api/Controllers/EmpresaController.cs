using Gerenciamento.Funcionarios.Application.Interfaces;
using Gerenciamento.Funcionarios.Application.Mappers;
using Gerenciamento.Funcionarios.Application.Models.Requests;
using Gerenciamento.Funcionarios.Application.Models.Responses;

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciamento.Funcionarios.Api.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class EmpresaController(IEmpresaServico empresaServico) : Controller
    {
        private readonly IEmpresaServico _empresaServico = empresaServico;

        [HttpGet]
        [Route("getEmpresa", Name = nameof(GetEmpresa))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetEmpresa([FromQuery] Guid id)
        {
            var empresaResponse = await _empresaServico.FindAsync(id);
            return Ok(empresaResponse);
        }

        [HttpPost]
        [Route("addEmpresa", Name = nameof(AddEmpresa))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddEmpresa([FromBody] EmpresaRequest empresaRequest)
        {
            await _empresaServico.AddAsync(empresaRequest);
            return Created();
        }

        [HttpDelete]
        [Route("deleteEmpresa", Name = nameof(DeleteEmpresa))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteEmpresa([FromBody] Guid id)
        {
            await _empresaServico.DeleteAsync(id);
            return Accepted();
        }

        [HttpPatch]
        [Route("updateEmpresa/{id:guid}", Name = nameof(UpdateEmpresa))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateEmpresa(Guid id, [FromBody] JsonPatchDocument<EmpresaResponse> empresaRequest)
        {
            var empresa = await _empresaServico.FindAsync(id);

            empresaRequest
                .ApplyTo(empresa);

            await _empresaServico.UpdateAsync(empresa.ToEmpresaRequest());

            return Accepted();
        }
    }
}
