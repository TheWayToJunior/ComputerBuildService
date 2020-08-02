using ComputerBuildService.DAL.Data;
using ComputerBuildService.DAL.Entitys;
using ComputerBuildService.DAL.IRepositorys;
using ComputerBuildService.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ComputerBuildService.DAL.Repositorys
{
    public class HardwareTypeRepository : Repository<HardwareTypeEntity, int>, IHardwareTypeRepository
    {
        public HardwareTypeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationDbContext ApplicationContext => base.Context as ApplicationDbContext;

        public async Task<HardwareTypeEntity> GetByName(string typeName)
        {
            return await GetAll().Result
                .SingleOrDefaultAsync(entity => entity.TypeName.ToLower() == typeName.ToLower());
        }
    }
}
