using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace MONGOLABB3.DAO
{
    internal class Database : IProduct
    {
        MongoClient client;
        IMongoDatabase db;

        public Database(string db, string MongoURI)
        {
            this.client = new MongoClient(MongoURI);
            this.db = this.client.GetDatabase(db);
        }
        IMongoCollection<BsonDocument> GetCollection()
        {
            var collection = db.GetCollection<BsonDocument>("Produkter");
            return collection;
        }
        bool IProduct.Create(FishingProductModel product)
        {
            var collection = GetCollection();
            var checkNameFilter = Builders<BsonDocument>.Filter.Eq("Name", product.Name);
            var document = collection.Find(checkNameFilter).FirstOrDefault();
            if (document != null)
            {
                return false;
            }
            else
            {
                var addProduct = new BsonDocument { { "Name", product.Name }, { "Description", product.Description.ToString() }, { "Price", product.Price }, { "Inventory", product.Inventory } };
                collection.InsertOne(addProduct);
                return true;
            }

        }

        List<FishingProductModel> IProduct.ReadAll()
        {
            List<FishingProductModel> productlist = new List<FishingProductModel>();
            var collection = GetCollection();
            var collectionDocs = collection.Find(new BsonDocument()).ToList();
            var collectionList = collectionDocs.Select(v => BsonSerializer.Deserialize<FishingProductModel>(v)).ToList();
            foreach (var product in collectionList)
            {
                productlist.Add(product);
            }
            return productlist;
        }
        void IProduct.Delete(FishingProductModel product)
        {
            var collection = GetCollection();
            var delete = Builders<BsonDocument>.Filter.Eq("_id", product.id);
            collection.DeleteOne(delete);
        }
        void IProduct.Update(FishingProductModel product, FishingProductModel updatedproduct)
        {
            var collection = GetCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", product.id);
            var UpdateProduct = new BsonDocument { { "Name", updatedproduct.Name }, { "Description", updatedproduct.Description.ToString() }, { "Price", updatedproduct.Price }, { "Inventory", updatedproduct.Inventory } };
            collection.ReplaceOne(filter, UpdateProduct);
            
        }
    }
}
