using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Components.Forms
{
    public static class FormExtensions
    {
        public static PropertyInfo GetPropertyInfoFromExpression(this Expression<Func<object>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            var unaryExpression = expression.Body as UnaryExpression;
            var member = memberExpression ?? unaryExpression?.Operand as MemberExpression;
            if (member is null)
                throw new NullReferenceException();
            var propertyInfo = (PropertyInfo)member.Member;
            return propertyInfo;
        }
    }
}
