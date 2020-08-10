using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerBuildService.BL.Parser.CitilinkParsers
{
    public class CitilinkParserSettings : IParserSettings
    {
        public CitilinkParserSettings(string navigate) : this(navigate, "p", 1, 1)
        {
        }

        public CitilinkParserSettings(string navigate, int start, int end) : this(navigate, "p", start, end)
        {
        }

        public CitilinkParserSettings(string navigate, string prefix) : this(navigate, prefix, 1, 1)
        {
        }

        public CitilinkParserSettings(string navigate, string prefix, int start, int end)
        {
            BaseUrl = string.Concat("https://www.citilink.ru/catalog/computers_and_notebooks/parts/", navigate);
            Prefix = prefix;
            StartPoint = start;
            EndPoint = end;
        }

        public string BaseUrl { get; private set; }

        public string Prefix { get; private set; }

        public int StartPoint { get; set; }

        public int EndPoint { get; set; }
    }
}
