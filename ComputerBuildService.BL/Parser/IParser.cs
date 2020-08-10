using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ComputerBuildService.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuildService.BL.Parser
{
    public interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
