using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediatorApiExample.Core;
using MongoDB.Driver;

namespace MediatorApiExample.Application.Services
{
    public class Repository
    {
        private readonly IMongoDatabase _database;

        public Repository(IMongoDatabase database)
        {
            _database = database;
        }

        public Task SaveAsync<T>(T item) where T : IEntity
        {
            var opt = new ReplaceOptions {IsUpsert = true};

            return GetCollection<T>().ReplaceOneAsync(s => s.Id == item.Id, item, opt);
        }

        public Task<List<T>> FindAsync<T>() where T : IEntity
        {
            return GetCollection<T>().Find(_ => true).ToListAsync();
        }
        
        public Task<List<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : IEntity
        {
            return GetCollection<T>().Find(predicate).ToListAsync();
        }

        public Task<T> FindByIdAsync<T>(Guid id) where T : IEntity
        {
            return GetCollection<T>().Find(s => s.Id == id).FirstOrDefaultAsync();
        }

        public Task RemoveAsync<T>(Guid id) where T : IEntity
        {
            return GetCollection<T>().DeleteOneAsync(s => s.Id == id);
        }
        
        private IMongoCollection<T> GetCollection<T>() => _database.GetCollection<T>(typeof(T).Name);
    }
}