namespace si730ebucodigo.API.Inventory.Interfaces.REST.Resources;

public record ProductResource(
    int Id,
    string Brand,
    string Model,
    string StatusDescription
    );