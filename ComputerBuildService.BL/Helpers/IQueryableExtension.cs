using ComputerBuildService.BL.Models;
using System.Collections.Generic;
using System.Linq;

namespace ComputerBuildService.Server.Helpers
{
    public static class IQueryableExtension
    {
        /// <summary>
        /// Формирует запрос на выборку для указанного индекса
        /// </summary>
        /// <param name="index">Необходимый индекс</param>
        /// <param name="size">Количество выбранных объектов</param>
        public static IQueryable<TModel> Pagination<TModel>(this IQueryable<TModel> queryable, Pagination pagination)
        {
            return queryable
                .Skip((pagination.Index - 1) * pagination.Size)
                .Take(pagination.Size);
        }

        public static IEnumerable<TModel> Pagination<TModel>(this IEnumerable<TModel> queryable, Pagination pagination)
        {
            return queryable
                .Skip((pagination.Index - 1) * pagination.Size)
                .Take(pagination.Size);
        }
    }
}
