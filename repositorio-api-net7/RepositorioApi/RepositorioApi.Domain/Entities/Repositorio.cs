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

        /// <summary>
        /// Calcula a relevância do repositório com base em três fatores principais:
        /// - Estrelas (Stars): possuem peso 3, pois representam diretamente o interesse da comunidade pelo repositório.
        /// - Forks: possuem peso 2, pois indica que outras pessoas consideram o repositório uma base interessante para seus próprios projetos.
        /// - Watchers: possuem peso 1, pois possuem um menor engajamento que os forks e stars.
        ///
        /// Essa ponderação visa priorizar repositórios que geram maior impacto e engajamento na comunidade.
        ///
        /// </summary>
        public double CalcularRelevancia()
        {
            return (Stars * 3) + (Forks * 2) + (Watchers * 1);
        }
    }
}
