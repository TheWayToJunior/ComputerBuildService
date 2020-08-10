using AngleSharp.Html.Dom;
using ComputerBuildService.BL.Models.Requests;
using System.Collections.Generic;
using System.Linq;

namespace ComputerBuildService.BL.Parser.CitilinkParser
{
    public class CitilinkParserItem : IParser<HardwareItemRequest>
    {
        public HardwareItemRequest Parse(IHtmlDocument document)
        {
            var item = new HardwareItemRequest();

            item.Name = ParseAttribute(document, "div.product_details div.not_display span[itemprop=name]", "content");
            item.Manufacturer = ParseAttribute(document, "div.product_details div.not_display span[itemprop=brand]", "content");
            //item.Description = ParseAttribute(document, "div.product_details div.not_display span[itemprop=description]", "content");

            var price = ParseTextContent(document, "div.price ins.num");
            item.Price = decimal.Parse(price);

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

            foreach (var tr in elements)
            {
                result.Add(new CompatibilityPropertyRequest
                {
                    PropertyType = tr.QuerySelector("th span.property_name").TextContent,
                    PropertyName = tr.QuerySelector("td").TextContent
                });
            }

            return result.Take(22).ToArray();
        }
    }
}
