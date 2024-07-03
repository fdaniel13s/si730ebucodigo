using si730ebucodigo.API.Maintenance.Application.Internal.OutboundServices.ACL;
using si730ebucodigo.API.Maintenance.Domain.Model.Aggregates;
using si730ebucodigo.API.Maintenance.Domain.Model.Commands;
using si730ebucodigo.API.Maintenance.Domain.Repositories;
using si730ebucodigo.API.Maintenance.Domain.Services;
using si730ebucodigo.API.Shared.Domain.Repositories;

namespace si730ebucodigo.API.Maintenance.Application.Internal.CommandServices;

public class MaintenanceActivityCommandService(IMaintenanceActivityRepository maintenanceActivityRepository,
    ExternalProductService externalProductService, IUnitOfWork unitOfWork):
    IMaintenanceActivityCommandService
{
    public async Task<MaintenanceActivity?> Handle(CreateMaintenanceActivityCommand command)
    {
        var productId = externalProductService.FetchProductIdBySerialNumber(command.ProductSerialNumber);
        var maintenanceActivity = new MaintenanceActivity(command, productId.Id);  
        
        if (maintenanceActivity == null)
            throw new Exception("Error creating maintenance activity");
        
        try 
        {
            await maintenanceActivityRepository.AddAsync(maintenanceActivity);
            await unitOfWork.CompleteAsync();
            return maintenanceActivity;
        }
        catch (Exception e)
        {
            throw new Exception("Error creating maintenance activity", e);
        }
    }
}