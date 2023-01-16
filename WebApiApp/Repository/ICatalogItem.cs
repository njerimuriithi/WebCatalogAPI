using WebApiApp.Model;

namespace WebApiApp.Repository
{
    public interface ICatalogItem
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();

        void CreateItem(Item item); 
        void  UpdateItem(Item item);    
        void DeleteItem(Guid id);
    }
}