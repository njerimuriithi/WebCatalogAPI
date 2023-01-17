using MongoDB.Bson;
using MongoDB.Driver;
using WebApiApp.Model;
//docker run -d  --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo
namespace WebApiApp.Repository
{

    public class MongoCatalogItem : ICatalogItem
    {
        private const string databaseName = "catalog";
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> itemscollection;
        public MongoCatalogItem(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemscollection = database.GetCollection<Item>(collectionName);
        }
        public void CreateItem(Item item)
        {

            itemscollection.InsertOne(item);
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            return itemscollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
