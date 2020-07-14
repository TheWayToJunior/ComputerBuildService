using ComputerBuildService.Server.Data;
using ComputerBuildService.Server.IServices;

namespace ComputerBuildService.Server.Services
{
    public class ApplicationDbService<TEntity, TPrimaryKey> 
        : Repository<TEntity, TPrimaryKey>, IApplicationDbService<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public ApplicationDbService(ApplicationDbContext context)
            : base(context)
        {
        }

        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;

        public int SaveChanges()
        {
            return ApplicationDbContext.SaveChanges();
        }
    }
}
