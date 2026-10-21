using LogisticsOps.Api.Data;
using LogisticsOps.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsOps.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipmentsController(IShipmentRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShipmentDto>>> GetAll()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        var shipments = await repository.GetAllAsync();
        return Ok(shipments.Select(s => ShipmentDto.FromShipment(s, today)));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ShipmentDto>> GetById(int id)
    {
        var shipment = await repository.GetByIdAsync(id);
        if (shipment is null)
        {
            return NotFound();
        }

        var today = DateOnly.FromDateTime(DateTime.Today);
        return Ok(ShipmentDto.FromShipment(shipment, today));
    }
}