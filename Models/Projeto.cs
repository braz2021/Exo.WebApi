using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exo.WebApi.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public required string NomeDoProjeto { get; set; }
        public required string Area { get; set; }
        public bool Status { get; set; }
    }
}
