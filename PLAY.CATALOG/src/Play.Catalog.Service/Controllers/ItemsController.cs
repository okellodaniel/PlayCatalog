using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Place.Catalog.Service.Dtos;
using Play.Catalog.Service.Repositories;
using PLAY.CATALOG.src.Entities;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsRepository itemsRepository = new();

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetAsync()
        {
            var items = (await itemsRepository.GetAllAsync())
                        .Select(item => item.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetByIdAsync(string id)
        {
            var item = await itemsRepository.GetItemAsync(id);

            if (item == null)
            {
                throw new Exception("Item not found");
            }

            return item.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> PostAsync(CreatedItemDto createdItemDto)
        {
            var item = new Item
            {
                Name = createdItemDto.Name,
                Description = createdItemDto.Description,
                Price = createdItemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await itemsRepository.CreateAsync(item);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, UpdateItemDto updateItemDto)
        {
            var existingItem = await itemsRepository.GetItemAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = updateItemDto.Name;
            existingItem.Description = updateItemDto.Description;
            existingItem.Price = updateItemDto.Price;

            await itemsRepository.UpdateAsync(existingItem);

            return NoContent();
        }

        // Delete /Items/{id}   

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var item = await itemsRepository.GetItemAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            await itemsRepository.DeleteAsync(item.Id);

            return NoContent();
        }
    }
}
