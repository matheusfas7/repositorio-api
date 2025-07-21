using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioApi.Domain.Entities
{
    public class Repositorio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Url { get; set; }
        public int Stars { get; set; }
        public int Forks { get; set; }
        public int Watchers { get; set; }

        public double CalcularRelevancia()
        {
            return (Stars * 3) + (Forks * 2) + (Watchers * 1);
        }
    }
}
