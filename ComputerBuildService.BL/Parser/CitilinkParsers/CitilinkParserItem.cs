using AngleSharp.Html.Dom;
using ComputerBuildService.BL.Models.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ComputerBuildService.BL.Parser.CitilinkParser
{
    public class CitilinkParserItem : IParser<HardwareItemRequest>
    {
        public HardwareItemRequest Parse(IHtmlDocument document)
        {
            var item = new HardwareItemRequest();

            var price = ParseTextContent(document, "div.price ins.num");
            item.Price = decimal.Parse(price);

            var name = ParseAttribute(document, "div.product_details div.not_display span[itemprop=name]", "content");
            item.Name = Regex.Replace(name, @"[А-я]+\S+\s", string.Empty);

            item.Manufacturer = ParseAttribute(document, "div.product_details div.not_display span[itemprop=brand]", "content");
            item.Description = ParseAttribute(document, "div.product_details div.not_display span[itemprop=description]", "content");

            item.PropertysItems = ParseProperties(document);

            return item;
        }

        public string ParseTextContent(IHtmlDocument document, string selector)
        {
            return document.QuerySelector(selector).TextContent;
        }

        public string ParseAttribute(IHtmlDocument document, string selector, string attrebure)
        {
            return document.QuerySelector(selector).GetAttribute(attrebure);
        }

        public CompatibilityPropertyRequest[] ParseProperties(IHtmlDocument document)
        {
            var result = new List<CompatibilityPropertyRequest>();

            var elements = document.QuerySelectorAll("table.product_features tbody tr").Where(e => e.ClassName == null);

            var str = new (string replace, string replacement)[] 
            { 
                //("Максимальный объем памяти", "Максимальный объем оперативной памяти") 
            };

            foreach (var tr in elements)
            {
                var title = tr.QuerySelector("th span.property_name").TextContent;
                var replaceTitle = str.SingleOrDefault(r => r.replace.ToLower() == title.ToLower());

                result.Add(new CompatibilityPropertyRequest
                {
                    PropertyType = replaceTitle == default ? title : replaceTitle.replacement,
                    PropertyName = tr.QuerySelector("td").TextContent
                });
            }

            return result.ToArray();
        }
    }
}
