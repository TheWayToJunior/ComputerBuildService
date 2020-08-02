using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuildService.DAL.IRepositorys
{
    public interface IRepositoryContainer : IDisposable
    {
        IHardwareItemRepository HardwareItemRepository { get; }

        IHardwareTypeRepository HardwareTypeRepository { get; }

        ICompatibilityPropertyRepository CompatibilityPropertyRepository { get; }

        int Save();

        Task<int> SaveAsync();
    }
}
