using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figaro.Models;
using Plugin.RestClient;

namespace Figaro.Services
{
    class TipoCocinaServices
    {
        public async Task<List<TipoCocina>> GetTipoCocinaAsync()
        {
            RestClient<TipoCocina> restClient = new RestClient<TipoCocina>("TipoCocina");

            var listaTipoCocina = await restClient.GetAsync();

            foreach (var tipoCocina in listaTipoCocina)
            {
                tipoCocina.NoActual = true;
            }

            return listaTipoCocina;
        }
    }
}
