using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Helpers
{
    public static class IQueryableExtension
    {
        /// <summary>
        /// Формирует запрос на выборку заданного диапазона объектов из хранилища
        /// </summary>
        /// <param name="index">Начальный объект выборки</param>
        /// <param name="size">Количество выбранных объектов</param>
        public static IQueryable<T> GetRange<T>(this IQueryable<T> queryable, int index, int size)
        {
            return queryable
                .Skip((index - 1) * size)
                .Take(size);
        }
    }
}
