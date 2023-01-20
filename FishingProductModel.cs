using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace MONGOLABB3
{
    public class FishingProductModel
    {
        [BsonId]

        public object? id { get; set; }
        public string? Name { get; set; }
        public object? Description { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }

    }
}
