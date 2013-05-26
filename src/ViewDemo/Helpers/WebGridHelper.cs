using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Reflection;
using System.ComponentModel;
using System.Web.Mvc.Html;

namespace ViewDemo.Helpers
{
    public static class WebGridHelper
    {
        public static IHtmlString CustomGrid<TModel>(this HtmlHelper<IEnumerable<TModel>> helper)
        {
            var grid = new WebGrid((dynamic)helper.ViewData.Model,
                                    rowsPerPage: 5,
                                    ajaxUpdateContainerId: "Grid");

            List<WebGridColumn> columns = new List<WebGridColumn>();

            var props = typeof(TModel).GetProperties(BindingFlags.Public|BindingFlags.Instance);

            foreach (var item in props)
            {
                var displayNameAttr = item.GetCustomAttributes(typeof(DisplayNameAttribute), true).FirstOrDefault() as DisplayNameAttribute;
                columns.Add(grid.Column(item.Name, displayNameAttr == null ? "" : displayNameAttr.DisplayName));
            }

            columns.Add(grid.Column(format: item => helper.ActionLink("Edit", "Edit", new { id = item.Id })));
            
            var html = grid.GetHtml(columns: columns);

            return html;
        }
    }
}