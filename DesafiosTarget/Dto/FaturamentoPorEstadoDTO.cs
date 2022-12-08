using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafiosTarget.Dto
{
    public class FaturamentoPorEstadoDTO
    {
        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("faturamento")]
        public decimal Faturamento { get; set; }
    }
}
