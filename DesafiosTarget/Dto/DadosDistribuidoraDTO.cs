using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafiosTarget.Dto
{
    public class DadosDistribuidoraDTO
    {
        [JsonProperty("dia")]
        public int Dia { get; set; }

        [JsonProperty("valor")]
        public decimal Valor { get; set; }
    }
}
