using ComputerBuildService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuildService.DAL.IRepositories
{
    public interface ICompatibilityPropertyRepository : IRepository<CompatibilityPropertyEntity, int>
    {
        Task<CompatibilityPropertyEntity> GetByName(string type, string name);

        Task<IEnumerable<CompatibilityPropertyEntity>> GetByName(IEnumerable<(string type, string name)> props);
    }
}
