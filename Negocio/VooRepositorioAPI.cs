using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Negocio

{
    public class VooRepositorioAPI
    {
        HttpClient vooCia = new HttpClient();

        public VooRepositorioAPI()
        {
            vooCia.BaseAddress = new Uri("http://localhost:5000/");
            vooCia.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("Application/json"));
        }

        public async Task<List<VooAPI>> GetVooAsync()
        {
            HttpResponseMessage response = await vooCia.GetAsync("voos/todos");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<VooAPI>>(dados);
            }            
            return new List<VooAPI>(); 
        }

        public async Task<VooAPI> GetVooAsyncById(string id)
        {
            HttpResponseMessage response = await vooCia.GetAsync("voos/recuperar/{id}");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<VooAPI>(dados);
            }
            return new VooAPI();
        }

        public async Task<List<CiaAPI>> GetCiaAsync()
        {
            HttpResponseMessage response = await vooCia.GetAsync("cias/todas");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CiaAPI>>(dados);
            }
            return new List<CiaAPI>();
        }

        public async Task<List<VooAPI>> PutVooAsyncById(string id)
        {
            HttpResponseMessage response = await vooCia.GetAsync("voos/atualizar/{id}");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<VooAPI>>(dados);
            }
            return new List<VooAPI>();
        }


    }
}