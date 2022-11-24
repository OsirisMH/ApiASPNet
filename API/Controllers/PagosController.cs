using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]

public class PagosController : ControllerBase
{
    private readonly PagosService _pagosService;
    public PagosController(PagosService pagosService) =>
        _pagosService = pagosService;

    [HttpGet]
    public async Task<List<Pagos>> Get() =>
        await _pagosService.GetAsync();

    [HttpGet("{matricula:length(24)}")]
    public async Task<ActionResult<Pagos>> Get(string matricula)
    {
        var pago = await _pagosService.GetAsync(matricula);

        if (pago is null)
        {
            return NotFound();
        }

        return pago;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Pagos newPago)
    {
        await _pagosService.CreateAsync(newPago);

        return CreatedAtAction(nameof(Get), new { matricula = newPago.NumeroMatricula }, newPago);
    }

    [HttpPut("{matricula:length(24)}")]
    public async Task<IActionResult> Update(string matricula, Pagos updatedPago)
    {
        var book = await _pagosService.GetAsync(matricula);
        if (book is null)
        {
            return NotFound();
        }
        updatedPago.NumeroMatricula = book.NumeroMatricula;
        await _pagosService.UpdateAsync(matricula, updatedPago);
        return NoContent();
    }

    [HttpDelete("{matricula:length(24)}")]
    public async Task<IActionResult> Delete(string matricula)
    {
        var book = await _pagosService.GetAsync(matricula);
        if (book is null)
        {
            return NotFound();
        }
        await _pagosService.RemoveAsync(matricula);
        return NoContent();
    }
}
