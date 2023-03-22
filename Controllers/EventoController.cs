using Microsoft.AspNetCore.Mvc;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EventoController : ControllerBase
{
  

   

    public EventoController()
    {
        
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<Evento> Get()
    {

    }
}

