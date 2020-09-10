using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProAgil.API.Data;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class WeatherForecastController : ControllerBase {
        
        public readonly DataContext _context;

        public WeatherForecastController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                var results = _context.Eventos.ToList();
                return Ok(results);
            }
            catch (System.Exception)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }                    
        }

        [HttpGet("{id}")]
        public ActionResult<Evento> Get(int id)
        {
            return _context.Eventos.FirstOrDefault(x => x.EventoId == id);
        }
    }
}