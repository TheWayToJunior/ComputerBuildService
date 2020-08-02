using ComputerBuildService.DAL.Data;
using ComputerBuildService.DAL.Entitys;
using ComputerBuildService.DAL.IRepositorys;
using ComputerBuildService.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.DAL.Repositorys
{
    public class CompatibilityPropertyRepository : Repository<CompatibilityPropertyEntity, int>, ICompatibilityPropertyRepository
    {
        public CompatibilityPropertyRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationDbContext ApplicationContext => base.Context as ApplicationDbContext;

        public async Task<CompatibilityPropertyEntity> GetByName(string type, string name)
        {
            return await GetAll().Result
                .Include(p => p.PropertysItems).ThenInclude(pi => pi.Item)
                .SingleOrDefaultAsync(entity => entity.PropertyName.ToLower() == name.ToLower()
                    && entity.PropertyType.ToLower() == type.ToLower());
        }

        public async Task<IEnumerable<CompatibilityPropertyEntity>> GetByName(IEnumerable<(string type, string name)> props)
        {
            var list = new List<CompatibilityPropertyEntity>();

            foreach (var item in props)
            {
                var entity = await GetByName(item.type, item.name);

                if (entity == null)
                    throw new Exception($"The specified parameter was not found: {item.type}, {item.name}");

                list.Add(entity);
            }

            return list;
        }
    }
}
