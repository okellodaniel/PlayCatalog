using System;
using System.ComponentModel.DataAnnotations;

namespace Place.Catalog.Service.Dtos
{
    public record ItemDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);

    public record CreatedItemDto([Required] string Name, string Description, [Range(0, 5000)] decimal Price);
    public record UpdateItemDto(string Name, string Description, decimal Price);
}