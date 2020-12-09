
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bamboo.Common.Extensions
{
    // https://stackoverflow.com/questions/1689199/c-sharp-code-to-order-by-a-property-using-the-property-name-as-a-string
    public static class IQueryableExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string propertyName, IComparer<object> comparer = null)
        {
            return CallOrderedQueryable(query, "OrderBy", propertyName, comparer);
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> query, string propertyName, IComparer<object> comparer = null)
        {
            return CallOrderedQueryable(query, "OrderByDescending", propertyName, comparer);
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> query, string propertyName, IComparer<object> comparer = null)
        {
            return CallOrderedQueryable(query, "ThenBy", propertyName, comparer);
        }

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> query, string propertyName, IComparer<object> comparer = null)
        {
            return CallOrderedQueryable(query, "ThenByDescending", propertyName, comparer);
        }

        /// <summary>
        /// Builds the Queryable functions using a TSource property name.
        /// </summary>
        public static IOrderedQueryable<T> CallOrderedQueryable<T>(this IQueryable<T> query, string methodName, string propertyName,
                IComparer<object> comparer = null)
        {
            var param = Expression.Parameter(typeof(T), "x");

            var body = propertyName.Split('.').Aggregate<string, Expression>(param, Expression.PropertyOrField);

            return comparer != null
                ? (IOrderedQueryable<T>)query.Provider.CreateQuery(
                    Expression.Call(
                        typeof(Queryable),
                        methodName,
                        new[] { typeof(T), body.Type },
                        query.Expression,
                        Expression.Lambda(body, param),
                        Expression.Constant(comparer)
                    )
                )
                : (IOrderedQueryable<T>)query.Provider.CreateQuery(
                    Expression.Call(
                        typeof(Queryable),
                        methodName,
                        new[] { typeof(T), body.Type },
                        query.Expression,
                        Expression.Lambda(body, param)
                    )
                );
        }
    }

    // https://stackoverflow.com/questions/298725/multiple-order-by-in-linq?rq=1
    // queryable.SmartOrderBy(i => i.Property1).SmartOrderByDescending(i => i.Property2);
    public static class IQueryableExtension
    {
        public static bool IsOrdered<T>(this IQueryable<T> queryable)
        {
            if (queryable == null)
            {
                throw new ArgumentNullException("queryable");
            }

            return queryable.Expression.Type == typeof(IOrderedQueryable<T>);
        }

        public static IQueryable<T> SmartOrderBy<T, TKey>(this IQueryable<T> queryable, Expression<Func<T, TKey>> keySelector)
        {
            if (queryable.IsOrdered())
            {
                var orderedQuery = queryable as IOrderedQueryable<T>;
                return orderedQuery.ThenBy(keySelector);
            }
            else
            {
                return queryable.OrderBy(keySelector);
            }
        }

        public static IQueryable<T> SmartOrderByDescending<T, TKey>(this IQueryable<T> queryable, Expression<Func<T, TKey>> keySelector)
        {
            if (queryable.IsOrdered())
            {
                var orderedQuery = queryable as IOrderedQueryable<T>;
                return orderedQuery.ThenByDescending(keySelector);
            }
            else
            {
                return queryable.OrderByDescending(keySelector);
            }
        }
    }
    public static class DateTimeDayOfMonthExtensions
    {
        public static DateTime FirstDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1, 0,0,0);
        }

        public static int DaysInMonth(this DateTime value)
        {
            return DateTime.DaysInMonth(value.Year, value.Month);
        }

        public static DateTime LastDayOfMonth(this DateTime value)
        {
            return value.AddMonths(1).AddSeconds(-1);
            //return new DateTime(value.Year, value.Month, value.DaysInMonth());
        }
    }
}