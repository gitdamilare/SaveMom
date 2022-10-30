using MongoDB.Driver;

namespace SaveMom.Domain.Data
{
    public interface IDbContext<T> where T : class
    {
        public IMongoCollection<T> Collection { get; }
    }
}
