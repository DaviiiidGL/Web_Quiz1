using Microsoft.AspNetCore.Mvc;
using WEB_Quiz1.Interfaces;
using WEB_Quiz1.Models;

namespace WEB_Quiz1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsumosController : Controller
{
    private readonly IConsumosService _consumosService;

    public ConsumosController(IConsumosService consumosService)
    {
        _consumosService = consumosService;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    // Get All
    [HttpGet]
    public IActionResult GetAll() => Ok(_consumosService.GetAll());

    // Get By ID
    [HttpGet("{id}")]
    public IActionResult getById(Guid id)
    {
        var consumo = _consumosService.getById(id);
        
        return consumo != null ? Ok(consumo) : NotFound("El consumo no existe");
    }

    // Create
    [HttpPost]
    public IActionResult Create([FromBody] Consumos newEvent)
    {

        var createdEvent = _consumosService.Create(newEvent);
        return CreatedAtAction(nameof(getById),new { id = createdEvent.id }, createdEvent);
    }
    
    // Update
    [HttpPut("{id}")]
    public IActionResult Edit(Guid id, [FromBody] Consumos editedConsumo)
    {
        return _consumosService.Update(id, editedConsumo) ? NoContent(): NotFound();
    }
    
    
    // Soft Delete
    [HttpPatch("{id}/change-status")]
    public IActionResult ChangeStatus(Guid id)
    {
        return _consumosService.ChangeStatus(id) ? Ok("Se ha cambiado el estado del evento") : NotFound();
    }
    
    // Get Total
    [HttpGet("{id}")]
    public IActionResult getTotal(Guid id)
    {
        var consumo = _consumosService.getTotal(id);
        
        return consumo != 0 ? Ok(consumo) : NotFound("No tiene total");
    }
}




