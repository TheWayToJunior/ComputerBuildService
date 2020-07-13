using ComputerBuildService.Server.Data;
using ComputerBuildService.Server.IServices;

namespace ComputerBuildService.Server.Services
{
    public class ApplicationDbService<TEntity> : Repository<TEntity>, IApplicationDbService<TEntity>
        where TEntity : class
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
