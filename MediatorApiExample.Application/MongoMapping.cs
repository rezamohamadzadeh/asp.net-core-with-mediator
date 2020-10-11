using MediatorApiExample.Core.Entities;
using MongoDB.Bson.Serialization;

namespace MediatorApiExample.Application
{
    public class MongoMapping
    {
        public static void RegisterMapping()
        {
            BsonClassMap.RegisterClassMap<FriendItem>(cm =>
            {
                cm.AutoMap();
                cm.MapCreator(s => new FriendItem(s.Id, s.Name, s.Liked));
            });
        }
    }
}
