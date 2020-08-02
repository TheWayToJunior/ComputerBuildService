using ComputerBuildService.DAL.Entitys;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuildService.DAL.IRepositorys
{
    public interface IHardwareItemRepository : IRepository<HardwareItemEntity, int>
    {
        Task<IQueryable<HardwareItemEntity>> GetAllFullObjects();

        Task<HardwareItemEntity> GetFullObject(int id);
    }
}
