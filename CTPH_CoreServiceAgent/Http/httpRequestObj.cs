using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CTPH_CoreBusiness.Common;
using CTPH_CoreServiceAgent.Request;

namespace CTPH_CoreServiceAgent.Http
{
    public class httpRequestObj
    {
        private readonly HttpClient client = new HttpClient();

        public async Task<string> GetRequest(HttpMuestrasRequest request, string url)
        {
            string result;

            try
            {
                HttpResponseMessage response = await client.GetAsync(request.getUrl(url)).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                result = await response.Content.ReadAsStringAsync();
            }
            catch
            {
                result = "";
            }

            return result;
        }

        public async Task<IResultDTO> PutRequest(HttpMuestrasRequest request, string url, string body)
        {
            IResultDTO result = new ResultDTO();

            try
            {
                var httpContent = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(request.putUrl(url), httpContent).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    result.OK = true;
                }
            }
            catch (Exception ex)
            {
                result.OK = false;
                result.Mensaje = ex.Message;
            }

            return result;
        }
    }
}
