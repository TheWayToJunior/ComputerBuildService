using ComputerBuildService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuildService.DAL.IRepositories
{
    public interface IManufacturerRepository : IRepository<ManufacturerEntity, int>, ISearcher<ManufacturerEntity, int>
    {
    }
}
