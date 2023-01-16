using System.Collections.Generic;
using WebApiApp.Model;

namespace WebApiApp.Repository
{
    public class CatalogItem : ICatalogItem
    {
        private readonly List<Item> items = new()
        {
            new Item {Id = Guid.NewGuid(), Name = "Portion", Price = 9,CreatedDate=DateTimeOffset.UtcNow  },
            new Item {Id = Guid.NewGuid(), Name = "Iron", Price = 20,CreatedDate=DateTimeOffset.UtcNow  },
            new Item {Id = Guid.NewGuid(), Name = "Sword", Price = 23,CreatedDate=DateTimeOffset.UtcNow  },
            new Item {Id = Guid.NewGuid(), Name = "food", Price = 25,CreatedDate=DateTimeOffset.UtcNow  },
            new Item {Id = Guid.NewGuid(), Name = "jjji", Price = 29,CreatedDate=DateTimeOffset.UtcNow  },
        };
        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem=> existingItem.Id == item.Id);
            items[index] = item; 
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);

        }
    }
}
