using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Place.Catalog.Service.Dtos;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private static readonly List<ItemDto> items = new()
        {
            new ItemDto(Guid.NewGuid(), "Porttion", "restores Hp", 5, DateTimeOffset.Now),
            new ItemDto(Guid.NewGuid(), "Antidote", "Cures poison", 7, DateTimeOffset.Now),
            new ItemDto(Guid.NewGuid(), "Bronze Sword", "Deals small damage", 20, DateTimeOffset.Now),

        };

        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return items;
        }

        [HttpGet("{id}")]
        public ItemDto GetById(Guid id)
        {
            var item = items.Where(t => t.Id == id).SingleOrDefault();
            return item;
        }

        // [HttpPost]
        // public ItemDto Create(ItemDto item)
        // {
        //     item.Id = Guid.NewGuid();
        //     Items.Add(item);
        //     return item;
        // }

        // [HttpPut("{id}")]
        // public ItemDto Update(Guid id, ItemDto item)
        // {
        //     var itemToUpdate = Items.FirstOrDefault(x => x.Id == id);
        //     if (itemToUpdate == null)
        //     {
        //         return null;
        //     }

        //     itemToUpdate.Name = item.Name;
        //     itemToUpdate.Description = item.Description;
        //     itemToUpdate.Price = item.Price;
        //     itemToUpdate.CreatedAt = item.CreatedAt;

        //     return itemToUpdate;
        // }

        // [HttpDelete("{id}")]
        // public ItemDto Delete(Guid id)
        // {
        //     var itemToDelete = Items.FirstOrDefault(x => x.Id == id);
        //     if (itemToDelete == null)
        //     {
        //         return null;
        //     }

        //     Items.Remove(itemToDelete);
        //     return itemToDelete;
        // }
    }
}
