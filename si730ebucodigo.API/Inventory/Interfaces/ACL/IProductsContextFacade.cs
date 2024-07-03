namespace si730ebucodigo.API.Inventory.Interfaces.ACL;

public interface IProductsContextFacade
{
    Task<int> FetchProductIdBySerialNumber(string serialNumber);
}