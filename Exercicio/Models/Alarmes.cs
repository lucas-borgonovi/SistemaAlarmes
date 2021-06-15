using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio.Models
{
    public class Alarmes
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public string Classificacao { get; set; }

        public int EquipRelacionado { get; set; }

        public int Status{ get; set; }

        public string Data { get; set; }
    }
}
