using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebNotes.Auth.Domain.Interfaces.Repository;
using WebNotes.Auth.Domain.Repository.User;

namespace WebNotes.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _UserCollection;
        public UserRepository(
        IOptions<UserDatabaseSettings> UserDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                UserDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                UserDatabaseSettings.Value.DatabaseName);

            _UserCollection = mongoDatabase.GetCollection<User>(
                UserDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task<List<User>> GetAsync() =>
        await _UserCollection.Find(_ => true).ToListAsync();

        public async Task<User?> GetAsync(string id) =>
            await _UserCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<User?> GetByEmailAsync(string email) =>
            await _UserCollection.Find(x => x.Email == email).FirstOrDefaultAsync();

        public async Task CreateAsync(User newBook) =>
            await _UserCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, User updatedBook) =>
            await _UserCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _UserCollection.DeleteOneAsync(x => x.Id == id);
    }
}
