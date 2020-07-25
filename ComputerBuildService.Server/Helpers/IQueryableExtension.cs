using ComputerBuildService.Shared;
using System;
using System.Linq;
using System.Linq.Expressions;

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

        public static IQueryable<TModel> Search<TModel>(this IQueryable<TModel> queryable, SearchOptions search)
            where TModel : class
        {
            if (string.IsNullOrEmpty(search?.Value))
                return queryable;

            var modelProperty = typeof(TModel).GetProperty(search.Field);

            if (modelProperty == null)
                throw new InvalidOperationException($"This model does not have a {search.Field} field");

            var castValue = Convert.ChangeType(search.Value, modelProperty.PropertyType);

            ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "model");

            Expression propertyExpression = Expression.Property(parameterExpression, modelProperty.Name);
            BinaryExpression equal = Expression.Equal(propertyExpression, Expression.Constant(castValue));

            var predicate = Expression.Lambda<Func<TModel, bool>>(equal, parameterExpression);

            return queryable.Where(predicate);
        }
    }
}
