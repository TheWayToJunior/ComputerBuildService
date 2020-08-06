using ComputerBuildService.DAL.Data;
using ComputerBuildService.DAL.Entities;
using ComputerBuildService.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ComputerBuildService.DAL.Repositories
{
    public class HardwareTypeRepository : Repository<HardwareTypeEntity, int>, IHardwareTypeRepository, ISearcher<HardwareTypeEntity, int>
    {
        public HardwareTypeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationDbContext ApplicationContext => base.Context as ApplicationDbContext;

        public async Task<HardwareTypeEntity> SearchByName(string typeName)
        {
            return await GetAll().Result
                .SingleOrDefaultAsync(entity => entity.Name.ToLower() == typeName.ToLower());
        }
    }
}
