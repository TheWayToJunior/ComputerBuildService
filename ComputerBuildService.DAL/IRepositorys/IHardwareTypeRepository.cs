using ComputerBuildService.DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuildService.DAL.IRepositorys
{
    public interface IHardwareTypeRepository : IRepository<HardwareTypeEntity, int>
    {
        Task<HardwareTypeEntity> GetByName(string typeName);
    }
}
