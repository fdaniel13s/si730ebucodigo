using Microsoft.AspNetCore.Mvc;
using si730ebucodigo.API.Maintenance.Domain.Model.Commands;
using si730ebucodigo.API.Maintenance.Domain.Model.Queries;
using si730ebucodigo.API.Maintenance.Domain.Services;
using si730ebucodigo.API.Maintenance.Interfaces.REST.Resources;
using si730ebucodigo.API.Maintenance.Interfaces.REST.Transform;

namespace si730ebucodigo.API.Maintenance.Interfaces.REST;

[ApiController]
[Route("api/v1/maintenance-activities")]
public class MaintenancesActivitiesController(
    IMaintenanceActivityCommandService maintenanceActivityCommandService,
    IMaintenanceActivityQueryService maintenanceActivityQueryService
    ):ControllerBase
{
    [HttpGet("{maintenanceActivityById:int}")]
    public async Task<IActionResult> GetMaintenanceActivityById(int maintenanceActivityById)
    {
        var maintenanceActivity =  await maintenanceActivityQueryService.Handle(new GetMaintenanceActivityByIdQuery(maintenanceActivityById));
        if (maintenanceActivity == null)
        {
            return NotFound();
        }
        return Ok(maintenanceActivity);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateMaintenanceActivity([FromBody] CreateMaintenanceActivityResource resource)
    {
        var command = CreateMaintenenceActivityCommandFromResourceAssembler.ToCommandFromResource(resource);
        var maintenanceActivity = await maintenanceActivityCommandService.Handle(command);
        if (maintenanceActivity == null)
        {
            return BadRequest(new { message = "Review your parameters. RULES: Brand and Model are required, SerialNumber is unique, StatusDescription is required" });
        }
        var maintenanceActivityResource = MaintenanceActivityResourceFromEntityAssembler.ToResourceFromEntity(maintenanceActivity); 
        return CreatedAtAction(nameof(GetMaintenanceActivityById), new { maintenanceActivityById = maintenanceActivity.Id }, maintenanceActivityResource);
    }
}