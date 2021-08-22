using CNPJ.Domain.DTO;
using CNPJ.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CNPJ.Domain.Services
{
    public class SearchCnpjWsAPIService : ISearchCnpjWsAPIService
    {
        private readonly HttpClient _httpClient;

        public SearchCnpjWsAPIService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://www.receitaws.com.br/v1/cnpj/{0}")
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<ResponseApiWsDTO>> GetCnpjApiAsync(List<CnpjApiDTO> model)
        {
            List<ResponseApiWsDTO> result = new List<ResponseApiWsDTO>();

            for (int i = 0; i < model.Count; i++)
            {
                
                result.Add(new ResponseApiWsDTO(model[i].IdCnpjSearch));

                HttpResponseMessage response = await _httpClient.GetAsync(model[i].CnpjSearch.ToString());

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized
                    || response.StatusCode == System.Net.HttpStatusCode.NoContent
                    || response.StatusCode == System.Net.HttpStatusCode.NotFound
                    || (response.StatusCode != System.Net.HttpStatusCode.OK
                    && response.StatusCode != System.Net.HttpStatusCode.BadRequest))
                {
                    result[i].MsgErro = "Falha de Comunicação com API.";
                }
                else
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    result[i] = JsonConvert.DeserializeObject<ResponseApiWsDTO>(stringResponse);
                }
            }

            return result;
        }
    }
}
