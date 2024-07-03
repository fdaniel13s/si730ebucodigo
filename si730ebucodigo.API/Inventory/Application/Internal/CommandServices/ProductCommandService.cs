using si730ebucodigo.API.Inventory.Domain.Model.Aggregates;
using si730ebucodigo.API.Inventory.Domain.Model.Commands;
using si730ebucodigo.API.Inventory.Domain.Model.ValueObjects;
using si730ebucodigo.API.Inventory.Domain.Repositories;
using si730ebucodigo.API.Inventory.Domain.Services;
using si730ebucodigo.API.Shared.Domain.Repositories;

namespace si730ebucodigo.API.Inventory.Application.Internal.CommandServices;

public class ProductCommandService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    : IProductCommandService
{
    public async Task<Product?> Handle(CreateProductCommand command)
    {
        if (!IsValid(command))
        {
            return null;
        }

        var product = new Product(command);
        try
        {
            await productRepository.AddAsync(product);
            await unitOfWork.CompleteAsync();
            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    private bool IsValid(CreateProductCommand command)
    {
        return IsSerialNumberUnique(command.SerialNumber) && IsStatusValid(command.StatusDescription);
    }

    private bool IsSerialNumberUnique(string serialNumber)
    {
        return productRepository.FindBySerialNumberAsync(serialNumber).Result == null;
    }

    private static bool IsStatusValid(string statusDescription)
    {
        return Enum.TryParse<EStatus>(statusDescription, out _);
    }
}