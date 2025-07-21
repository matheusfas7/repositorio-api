using RepositorioApi.Domain.Entities;

namespace RepositorioApi.Tests
{
    public class RepositorioTests
    {
        [Fact]
        public void CalcularRelevancia_DeveRetornarValorEsperado()
        {
            // Arrange
            var repositorio = new Repositorio
            {
                Stars = 10,
                Forks = 5,
                Watchers = 2
            };

            // Act
            var relevancia = repositorio.CalcularRelevancia();

            // Assert
            var esperado = (10 * 3) + (5 * 2) + (2 * 1); // 30 + 10 + 2 = 42
            Assert.Equal(esperado, relevancia);
        }

        [Fact]
        public void CalcularRelevancia_ValoresZerados_DeveRetornarZero()
        {
            // Arrange
            var repositorio = new Repositorio
            {
                Stars = 0,
                Forks = 0,
                Watchers = 0
            };

            // Act
            var relevancia = repositorio.CalcularRelevancia();

            // Assert
            Assert.Equal(0, relevancia);
        }
    }
}