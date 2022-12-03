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

    [HttpGet("{matricula}")]
    public async Task<ActionResult<List<Pagos>>> Get(string matricula)
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
}
