using System;

namespace ComputerBuildService.Server.Configuration
{
    public interface IDbServiceOptions<out TModel, TPrimaryKey>
         where TModel : IEntity<TPrimaryKey>
    {
        public string Key { get; }

        public Type ServiceType { get; }

        public Type InplimentalType { get; }
    }

    public class DbServiceOptions<TModel, TPrimaryKey> : IDbServiceOptions<TModel, TPrimaryKey>
        where TModel : class, IEntity<TPrimaryKey>
    {
        public DbServiceOptions(string key)
        {
            Key = key;
        }

        public string Key { get; private set; }

        public Type ServiceType => throw new NotImplementedException();

        public Type InplimentalType => throw new NotImplementedException();
    }
}
