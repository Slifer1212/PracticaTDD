using Xunit;
using MaquinaDeCafe;

namespace MaquinaDeCafe.Tests
{
    public class TestCafetera
    {
        [Fact]
        public void DeberiaDevolverVerdaderoSiExisteCafe()
        {
            // Arrange
            Cafetera cafetera = new Cafetera(10);

            // Act
            bool resultado = cafetera.HasCafe(5);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void DeberiaDevolverFalsoSiNoExisteCafe()
        {
            // Arrange
            Cafetera cafetera = new Cafetera(10);

            // Act
            bool resultado = cafetera.HasCafe(11);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void DeberiaRestarcafeALaCafetera()
        {
            // Arrange
            Cafetera cafetera = new Cafetera(10);

            // Act
            cafetera.GiveCafe(7);

            // Assert
            Assert.Equal(3, cafetera.GetCantidadDeCafe());
        }
    }
}
