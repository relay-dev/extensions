using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TSource> WhereLike<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, string>> valueSelector, string value, char wildcard = '*')
        {
            var likeExpression = BuildLikeExpression(valueSelector, value, wildcard);

            return source.Where(likeExpression);
        }

        private static Expression<Func<TElement, bool>> BuildLikeExpression<TElement>(Expression<Func<TElement, string>> valueSelector, string value, char wildcard)
        {
            if (valueSelector == null) throw new ArgumentNullException("valueSelector");

            MethodInfo method = ResolveFilterMethod(value, wildcard);

            value = value.Trim(wildcard);

            var body = Expression.Call(valueSelector.Body, method, Expression.Constant(value));

            ParameterExpression parameter = valueSelector.Parameters.Single();

            return Expression.Lambda<Func<TElement, bool>>(body, parameter);
        }

        private static MethodInfo ResolveFilterMethod(string value, char wildcard)
        {
            var methodName = "Equals";

            var textLength = value.Length;

            value = value.TrimEnd(wildcard);

            if (textLength > value.Length)
            {
                methodName = "StartsWith";
                textLength = value.Length;
            }

            value = value.TrimStart(wildcard);

            if (textLength > value.Length)
            {
                methodName = (methodName == "StartsWith") ? "Contains" : "EndsWith";
            }

            var stringType = typeof(string);

            return stringType.GetMethod(methodName, new[] { stringType });
        }
    }
}
