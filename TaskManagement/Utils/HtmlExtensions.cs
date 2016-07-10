using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace TaskManagement.Utils
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString DescriptionFor<TModel, TValue>(this HtmlHelper<TModel> self, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, self.ViewData);
            var description = metadata.Description;

            if(description == null)
                description = metadata.SimpleDisplayText;

            return MvcHtmlString.Create(string.Format(@"<span>{0}</span>", description));
        }
    }
}