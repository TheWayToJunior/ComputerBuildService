using ComputerBuildService.Server.Data;

namespace ComputerBuildService.Server.IServices
{
    public interface IApplicationDbService<TEintity, TPrimaryKey> : IRepository<TEintity, TPrimaryKey>
        where TEintity : class
    {
        ApplicationDbContext ApplicationDbContext { get; }

        int SaveChanges();
    }
}
