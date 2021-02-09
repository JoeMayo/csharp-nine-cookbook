using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Section_04_09
{
    public static class CookbookExtensions
    {
        public static IEnumerable<TParameter> WhereOr<TParameter>(
            this IEnumerable<TParameter> query, 
            Dictionary<string, string> criteria)
        {
            const string ParamName = "person";

            ParameterExpression paramExpr = 
                Expression.Parameter(typeof(TParameter), ParamName);

            Expression accumulatorExpr = null;

            foreach (var criterion in criteria)
            {
                MemberExpression paramMbr = 
                    LambdaExpression.PropertyOrField(paramExpr, criterion.Key);

                MemberExpression leftExpr =
                    Expression.Property(
                        paramExpr,
                        typeof(TParameter).GetProperty(criterion.Key));  
                Expression rightExpr =
                    Expression.Constant(criterion.Value, typeof(string));  
                Expression equalExpr =
                    Expression.Equal(leftExpr, rightExpr);

                accumulatorExpr = accumulatorExpr == null
                    ? equalExpr
                    : Expression.Or(accumulatorExpr, equalExpr);
            }            

            Expression<Func<TParameter, bool>> allClauses =
                Expression.Lambda<Func<TParameter, bool>>(
                    accumulatorExpr, paramExpr);

            Func<TParameter, bool> compiledClause = allClauses.Compile();

            return query.Where(compiledClause);
        }
    }
}