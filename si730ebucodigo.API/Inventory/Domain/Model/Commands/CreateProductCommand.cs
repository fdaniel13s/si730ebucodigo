namespace si730ebucodigo.API.Inventory.Domain.Model.Commands;

public record CreateProductCommand(
    string Brand, string Model, string SerialNumber, string StatusDescription
    );