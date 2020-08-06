using ComputerBuildService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuildService.DAL.IRepositories
{
    public interface IHardwareTypeRepository : IRepository<HardwareTypeEntity, int>, ISearcher<HardwareTypeEntity, int>
    {
    }
}
