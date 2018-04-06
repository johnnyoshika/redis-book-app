using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace RedisBookApp
{
    public interface IRedisConnection
    {
        ConnectionMultiplexer Redis { get; }
    }

    public class RedisConnection : IRedisConnection
    {
        public RedisConnection()
        {
            Redis = ConnectionMultiplexer.Connect("localhost:6379");
        }

        public ConnectionMultiplexer Redis { get; }
    }
}
