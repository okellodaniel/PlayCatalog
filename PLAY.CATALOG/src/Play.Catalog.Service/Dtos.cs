using System;

namespace Place.Catalog.Service.Dtos
{
    public record ItemDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);

    public record CreatedItem(string Name, string Description, decimal Price);
    public record UpdateItemDto(string Name, string Description, decimal Price);
}