﻿using MongoDB.Bson.Serialization.Attributes;

namespace vetFoodShop.Catalog.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        //public string ImageUrl {  get; set; }
    }
}
