using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace XamaRing.Core.Helpers
{
    public static class General
    {
        public static String GetPropertyName<T>(Expression<Func<T>> propertyLambda)
        {
            return (propertyLambda.Body as MemberExpression).Member.Name;
        }
    }
}
