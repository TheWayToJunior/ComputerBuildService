using ComputerBuildService.BL.Models;
using ComputerBuildService.BL.Models.Requests;
using ComputerBuildService.DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuildService.BL.Helpers
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<TModel> Pagination<TModel>(this IEnumerable<TModel> enumerable, Pagination pagination)
        {
            return enumerable
                .Skip((pagination.Index - 1) * pagination.Size)
                .Take(pagination.Size);
        }
    }
}
