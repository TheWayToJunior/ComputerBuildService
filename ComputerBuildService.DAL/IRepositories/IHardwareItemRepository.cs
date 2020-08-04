using ComputerBuildService.DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuildService.DAL.IRepositories
{
    public interface IHardwareItemRepository : IRepository<HardwareItemEntity, int>
    {
        Task<IQueryable<HardwareItemEntity>> GetAllFullObjects();

        Task<HardwareItemEntity> GetFullObject(int id);
    }
}
