using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace eApi.Infrastructure.HTML
{
    public static class BootstrapHtml
    {
        public static MvcHtmlString BS_Dropdown(this HtmlHelper _, string id, List<SelectListItem> selectListItems, string label)
        {
            var button = new TagBuilder("button")
            {
                Attributes =
                {
                    {"id", id},
                    {"type", "button" },
                    {"data-toggle", "dropdown" }
                }
            };

            button.AddCssClass("btn");
            button.AddCssClass("btn-default");
            button.AddCssClass("dropdown-toggle");

            button.SetInnerText(label + " " + _buildCaret());

            var wrapper = new TagBuilder("div");
            wrapper.AddCssClass("dropdown");

            wrapper.InnerHtml += button;
            wrapper.InnerHtml += _buildDropdown(id, selectListItems);


            return new MvcHtmlString(wrapper.ToString());
        }

        static string _buildCaret()
        {
            var caret = new TagBuilder("span");
            caret.AddCssClass("caret");

            return caret.ToString();
        }

        static string _buildDropdown(string id, IEnumerable<SelectListItem> items)
        {
            var list = new TagBuilder("ul")
            {
                Attributes =
                {
                    { "class", "dropdown-menu" },
                    { "role", "menu" },
                    { "aria-labelledby", id }
                }
            };

            var listItem = new TagBuilder("li");
            listItem.Attributes.Add("role", "presentation");

            foreach(SelectListItem item in items)
            {
                list.InnerHtml += "<li role=\"presentation\">" + _buildListRow(item) + "</li>";
            }

            return list.ToString();
        }

        static string _buildListRow(SelectListItem item)
        {
            var anchor = new TagBuilder("a")
            {
                Attributes =
                {
                    {"role", "menuitem"},
                    {"tabindex", "-1" },
                    {"href", item.Value }
                }
            };

            anchor.SetInnerText(item.Text);

            return anchor.ToString();
        }
    }
}