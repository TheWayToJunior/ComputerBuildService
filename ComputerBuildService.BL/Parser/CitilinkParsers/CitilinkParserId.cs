using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerBuildService.BL.Parser.CitilinkParser
{
    public class CitilinkParserId : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("div.product_category_list div")
                .Where(item => item.ClassName != null && item.ClassName.Contains("ddl_product"));

            foreach (var item in items)
            {
                list.Add(item.GetAttribute("data-product-id"));
            }

            return list.ToArray();
        }
    }
}
