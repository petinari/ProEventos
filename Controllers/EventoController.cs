using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EventoController : ControllerBase
{
    public IEnumerable<Evento> _evento = new Evento[]
    {
        new Evento()
            {
            EventoId = 1,
            DataEvento = DateTime.Now.AddDays(2).ToString(),
            Local = "Campo Grande",
            Lote = "Primeiro",
            QtdPessoas = 1,
            Tema = "Coisas",
            ImagemURL = "http://www.google.com.br/asd"
        },
        new Evento()
            {
            EventoId = 2,
            DataEvento = DateTime.Now.AddDays(2).ToString(),
            Local = "Terenos",
            Lote = "Segundo",
            QtdPessoas = 123,
            Tema = "Coisas asd",
            ImagemURL = "http://www.google.com.br/asd"
        },
    };
    public EventoController()
    {

    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _evento;
    }

}
