using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuildService.DAL.IRepositories
{
    public interface IRepositoryContainer : IDisposable
    {
        IHardwareItemRepository HardwareItemRepository { get; }

        IHardwareTypeRepository HardwareTypeRepository { get; }

        ICompatibilityPropertyRepository CompatibilityPropertyRepository { get; }

        IManufacturerRepository ManufacturerRepository { get; }

        int Save();

        Task<int> SaveAsync();
    }
}
