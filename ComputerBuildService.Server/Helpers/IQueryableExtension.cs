using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Helpers
{
    public static class IQueryableExtension
    {
        /// <summary>
        /// Формирует запрос на выборку для указанного индекса
        /// </summary>
        /// <param name="index">Необходимый индекс</param>
        /// <param name="size">Количество выбранных объектов</param>
        public static IQueryable<T> Pagination<T>(this IQueryable<T> queryable, int index, int size)
        {
            return queryable
                .Skip((index - 1) * size)
                .Take(size);
        }
    }
}
