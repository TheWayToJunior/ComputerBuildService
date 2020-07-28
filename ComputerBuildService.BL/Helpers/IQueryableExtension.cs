using ComputerBuildService.BL.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

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

        /// <summary>
        /// Формирует выражение необходимое для выбора по указанному свойству
        /// </summary>
        public static IQueryable<TModel> Search<TModel>(this IQueryable<TModel> queryable, SearchOptions search)
            where TModel : class
        {
            if (string.IsNullOrEmpty(search?.Value))
                return queryable;

            var modelProperty = typeof(TModel).GetProperty(search.Field)
               ?? throw new InvalidOperationException($"The {typeof(TModel).Name} does not have a {search.Field} field");

            ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "model");
            Expression propExpression = Expression.Property(parameterExpression, modelProperty.Name);

            Expression exception = modelProperty.PropertyType.IsAssignableFrom(typeof(string))
                ? Contains(propExpression, search.Value)
                : Equal(propExpression, search.Value);

            var predicate = Expression.Lambda<Func<TModel, bool>>(exception, parameterExpression);

            return queryable.Where(predicate);
        }

        /// <summary>
        /// (model) => model.StringProp.Contains(searchObj);
        /// </summary>
        private static Expression Contains(Expression propExpression, string searchObj)
        {
            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });

            return Expression.Call(propExpression, method, Expression.Constant(searchObj));
        }

        /// <summary>
        /// (model) => model.Prop == searchObj;
        /// </summary>
        private static Expression Equal(Expression propExpression, string searchObj)
        {
            var castValue = Convert.ChangeType(searchObj, propExpression.Type);

            return Expression.Equal(propExpression, Expression.Constant(castValue));
        }
    }
}
