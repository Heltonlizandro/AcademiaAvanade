using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteApi
{
    class VooRepositorio
    {
        HttpClient voo = new HttpClient();

        public VooRepositorio()
        {
            voo.BaseAddress = new Uri("http://localhost:5000/");

            voo.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("Application/json"));
        }
        public async Task<List<Voo>> GetVooAsync()
        {
            HttpResponseMessage response = await voo.GetAsync("voos/todos");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.readAsStringAsync();
                return JsonConvert.DeserializeObject<List<Voo>>(dados);
            }
            return new List<Voo>();
        }   
    }
}