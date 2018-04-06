using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace RedisBookApp
{
    public interface IRepository
    {
        Task<List<Book>> GetBooksAsync();
    }

    public class Repository : IRepository
    {
        public Repository(IRedisConnection connection)
        {
            RedisDatabase = connection.Redis.GetDatabase();
        }

        IDatabase RedisDatabase { get; set; }

        public async Task<List<Book>> GetBooksAsync()
        {
            string key = "books";

            var books = await FromCacheAsync(key);
            if (books != null)
                return books;

            books = FromPersistentStore();
            await ToCache(key, books, new TimeSpan(0, 0, 30));

            return books;
        }

        async Task<List<Book>> FromCacheAsync(string key)
        {
            string value = await RedisDatabase.StringGetAsync(key);
            if (value == null)
                return null;

            return JsonConvert.DeserializeObject<List<Book>>(value);
        }

        async Task ToCache(string key, List<Book> books, TimeSpan expiresIn) =>
            await RedisDatabase.StringSetAsync(key, JsonConvert.SerializeObject(books), expiresIn);

        List<Book> FromPersistentStore() =>
            new List<Book>
            {
                new Book { Id = 1, Title = "A Big Whale" },
                new Book { Id = 2, Title = "A Little Red Riding Hood" },
                new Book { Id = 3, Title = "Three Little Pigs" },
            };
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
