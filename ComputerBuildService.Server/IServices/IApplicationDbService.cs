namespace ComputerBuildService.Server.IServices
{
    public interface IApplicationDbService<TEintity> : IRepository<TEintity>
    {
        int SaveChanges();
    }
}
