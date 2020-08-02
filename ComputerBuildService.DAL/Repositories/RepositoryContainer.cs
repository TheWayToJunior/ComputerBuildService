using ComputerBuildService.DAL.Data;
using ComputerBuildService.DAL.IRepositorys;
using ComputerBuildService.DAL.Repository;
using System;
using System.Threading.Tasks;

namespace ComputerBuildService.DAL.Repositorys
{
    public class RepositoryContainer : IRepositoryContainer
    {
        private readonly ApplicationDbContext context;

        public RepositoryContainer(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));

            HardwareItemRepository = new HardwareItemRepository(this.context);
            HardwareTypeRepository = new HardwareTypeRepository(this.context);
            CompatibilityPropertyRepository = new CompatibilityPropertyRepository(this.context);
        }

        public IHardwareItemRepository HardwareItemRepository { get; private set; }

        public IHardwareTypeRepository HardwareTypeRepository { get; private set; }

        public ICompatibilityPropertyRepository CompatibilityPropertyRepository { get; private set; }

        public int Save()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
