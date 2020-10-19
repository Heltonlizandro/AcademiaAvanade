using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClienteApi
{
    public class VooRepositorioAPI
    {
        HttpClient voo = new HttpClient();

        public VooRepositorioAPI()
        {
            voo.BaseAddress = new Uri("http://localhost:5000/");

            voo.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("Application/json"));
        }
        public async Task<List<VooAPI>> GetVooAsync()
        {
            HttpResponseMessage response = await voo.GetAsync("voos/todos");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<VooAPI>>(dados);
            }
            return new List<VooAPI>(); 
        }   
    }
}