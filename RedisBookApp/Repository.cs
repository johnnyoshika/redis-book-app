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
        public async Task<List<Book>> GetBooksAsync()
        {
            return FromPersistentStore();
        }

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
