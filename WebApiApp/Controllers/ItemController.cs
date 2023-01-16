using Microsoft.AspNetCore.Mvc;
using WebApiApp.Dtos;
using WebApiApp.Model;
using WebApiApp.Repository;

namespace WebApiApp.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly ICatalogItem catalog;
        public ItemController(ICatalogItem catalog)
        {
            this.catalog = catalog;
        }
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = catalog.GetItems().Select(item => item.AsDto());
            return items;
        }
        [HttpGet("{id}")]
        public ActionResult <ItemDto> GetItem(Guid id)
        {
            var item = catalog.GetItem(id);
            if(item is null)
            {
                return NotFound();
            }
            return item.AsDto();
        }
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDtocs itemDto)
        {
            Item item = new Item()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow,
            };

            catalog.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());

        }
        [HttpPut("{id}")]
        public ActionResult UpdateItem( Guid id, UpdateItemDto itemDto)
        {
            var existingItem = catalog.GetItem(id);
            if(existingItem is null)
            {
             //   retun  NotFound();
            }
            Item updatedItem = existingItem with
            {
                Name = itemDto.Name,
                Price= itemDto.Price,
            };
            catalog.UpdateItem(updatedItem);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteItem (Guid id)
        {
            var existingItem = catalog.GetItem(id);
            if(existingItem is null)
            {
                //   retun  NotFound();
            }
            catalog.DeleteItem(id);
            return NoContent();
        }
       


    }
}
