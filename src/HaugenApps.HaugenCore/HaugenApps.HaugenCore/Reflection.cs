using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace HaugenApps.HaugenCore
{
    public static class Reflection
    {
        public static PropertyInfo GetPropertyInfo<TIn, TOut>(Expression<Func<TIn, TOut>> PropertyExpression)
        {
            MemberExpression memberExpr;
            switch (PropertyExpression.Body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    memberExpr = (MemberExpression)PropertyExpression.Body;
                    break;
                case ExpressionType.Convert:
                    memberExpr = (MemberExpression)((UnaryExpression)PropertyExpression.Body).Operand;
                    break;
                default:
                    throw new NotSupportedException();
            }

            var property = (PropertyInfo)memberExpr.Member;
            return property;
        }
    }
}
