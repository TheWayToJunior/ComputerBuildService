using ComputerBuildService.Server.Data;

namespace ComputerBuildService.Server.IServices
{
    public interface IApplicationDbService<TEintity> : IRepository<TEintity>
        where TEintity : class
    {
        ApplicationDbContext ApplicationDbContext { get; }

        int SaveChanges();
    }
}
