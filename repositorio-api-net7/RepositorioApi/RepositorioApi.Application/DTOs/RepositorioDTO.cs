using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioApi.Application.DTOs
{
    public class RepositorioDTO
    {
        public string Nome { get; set; }
        public string Url { get; set; }
        public int Stars { get; set; }
        public int Forks { get; set; }
        public int Watchers { get; set; }
        public double Relevancia { get; set; }
    }
}
