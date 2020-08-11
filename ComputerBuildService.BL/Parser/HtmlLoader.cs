using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ComputerBuildService.BL.Parser
{
    public class HtmlLoader
    {
        readonly HttpClient httpClient;

        public HtmlLoader() : this(string.Empty)
        {
        }

        public HtmlLoader(string uri)
        {
            this.Uri = uri;

            httpClient = new HttpClient();
        }

        public string Uri { get; set; }

        public async Task<string> GetSource()
        {
            if (string.IsNullOrEmpty(Uri))
                throw new ArgumentNullException(nameof(Uri));

            var response = await httpClient.GetAsync(this.Uri);

            string source = null;

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Loading error: {response.StatusCode}");

            if (response != null)
                source = await response.Content.ReadAsStringAsync();

            return source;
        }
    }
}
