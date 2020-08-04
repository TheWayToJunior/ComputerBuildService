using ComputerBuildService.DAL.Data;
using ComputerBuildService.DAL.Entities;
using ComputerBuildService.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ComputerBuildService.DAL.Repositories
{
    public class ManufacturerRepository : Repository<ManufacturerEntity, int>, IManufacturerRepository, ISearcher<ManufacturerEntity>
    {
        public ManufacturerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationDbContext ApplicationContext => base.Context as ApplicationDbContext;

        public async Task<ManufacturerEntity> GetByName(string name)
        {
            return await GetAll().Result
                .SingleOrDefaultAsync(entity => entity.Name.ToLower() == name.ToLower());
        }
    }
}
