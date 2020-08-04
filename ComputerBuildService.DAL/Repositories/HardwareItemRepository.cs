using ComputerBuildService.DAL.Data;
using ComputerBuildService.DAL.Entities;
using ComputerBuildService.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuildService.DAL.Repositories
{
    public class HardwareItemRepository : Repository<HardwareItemEntity, int>, IHardwareItemRepository
    {
        public HardwareItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationDbContext ApplicationContext => base.Context as ApplicationDbContext;

        public async Task<IQueryable<HardwareItemEntity>> GetAllFullObjects()
        {
            return (await GetAll())
                .Include(entity => entity.Manufacturer)
                .Include(entity => entity.HardwareType)
                .Include(entity => entity.PropertysItems).ThenInclude(propItems => propItems.Item)
                .Include(entity => entity.PropertysItems).ThenInclude(propItems => propItems.Property);
        }

        public async Task<HardwareItemEntity> GetFullObject(int id)
        {
            return await Get(id).Result
                .Include(entity => entity.Manufacturer)
                .Include(entity => entity.HardwareType)
                .Include(entity => entity.PropertysItems).ThenInclude(propItems => propItems.Item)
                .Include(entity => entity.PropertysItems).ThenInclude(propItems => propItems.Property)
                .SingleOrDefaultAsync();
        }
    }
}
