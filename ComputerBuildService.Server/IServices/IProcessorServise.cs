using ComputerBuildService.Shared.Models;
using System.Linq;

namespace ComputerBuildService.Server.IServices
{
    public interface IProcessorServise
    {
        IQueryable<CentralProcessorUnit> GerRange(int index, int size);
    }
}
