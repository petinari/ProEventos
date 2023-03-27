using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProEventos.Application.Contracts;
using ProEventos.Domain.Models;
using ProEventos.Persistence;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EventoController : ControllerBase
{
    private readonly IEventosService eventoService;

    public EventoController(IEventosService eventoService)
    {
        this.eventoService = eventoService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var eventos = eventoService.GetAllEventosAsync(true);
            if (eventos == null)
            {
                return NotFound("Nem um evento encontrado.");
            }
            return Ok(eventos);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro {ex.Message}");
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var eventos = eventoService.GetEventosByIdAsync(id, true);
            if (eventos == null)
            {
                return NotFound("Nem um evento por Id encontrado.");
            }
            return Ok(eventos);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro {ex.Message}");
        }
    }
    [HttpGet("{tema}/tema")]
    public async Task<IActionResult> GetEventosByTema(string tema)
    {
        try
        {
            var eventos = eventoService.GetAllEventosByTemaAsync(tema, true);
            if (eventos == null)
            {
                return NotFound("Nem um evento por tema encontrado.");
            }
            return Ok(eventos);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro {ex.Message}");
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post(Evento model)
    {
        try
        {
            var evento = await eventoService.AddEvento(model);
            if (evento == null)
            {
                return BadRequest("Erro ao adicionar eventos");
            }
            return Ok(evento);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar eventos. Erro {ex.Message}");
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Evento evento)
    {
        try
        {
            var _evento = await eventoService.UpdateEvento(evento);
            if (_evento == null)
            {
                return BadRequest("Erro ao atualizar eventos");
            }
            return Ok(_evento);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar eventos. Erro {ex.Message}");
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var deletado = await eventoService.DeleteEvento(id);
            if (deletado == false)
            {
                return BadRequest("Erro ao deletar eventos");
            }
            return Ok("Deletado.");
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar eventos. Erro {ex.Message}");
        }
    }

}
