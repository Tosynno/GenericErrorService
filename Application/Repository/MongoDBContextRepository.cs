using Application.Interface;
using Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class MongoDBContextRepository : IErrorLogRepo
    {
        private readonly IMongoCollection<ApplicationsErrorlog> mongoCollection;

        private const string databaseName = "GenericErrorLog";
        private const string collectionName = "ApplicationsErrortbl";
        public MongoDBContextRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            mongoCollection = database.GetCollection<ApplicationsErrorlog>(collectionName);
        }
        public async Task<bool> Create(ApplicationsErrorlog model)
        {
            bool response;
            try
            {
                await mongoCollection.InsertOneAsync(model);
                response = true;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
            //return Task.FromResult(mongoCollection.InsertOneAsync(model)).Result;
        }

        public async Task<IEnumerable<ApplicationsErrorlog>> GetAll()
        {
            return await mongoCollection.Find(new BsonDocument()).ToListAsync();
        }

        public Task<ApplicationsErrorlog> GetbyId(string id)
        {
            var filter = Builders<ApplicationsErrorlog>.Filter.Eq(c => c.ErrorLogId, id);
            return Task.FromResult(mongoCollection.Find(filter).FirstOrDefaultAsync()).Result;
        }
    }
}
