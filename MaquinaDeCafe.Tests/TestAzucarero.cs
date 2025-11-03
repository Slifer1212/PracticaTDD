using Xunit;
using MaquinaDeCafe;

namespace MaquinaDeCafe.Tests
{
    public class TestAzucarero
    {
        private Azucarero azuquero;

        public TestAzucarero()
        {
            azuquero = new Azucarero(10);
        }

        [Fact]
        public void DeberiaDevolverVerdaderoSiHaySuficienteAzucarEnElAzuquero()
        {
            // Act
            bool resultado = azuquero.HasAzucar(5);

            // Assert
            Assert.True(resultado);

            // Act
            resultado = azuquero.HasAzucar(10);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void DeberiaDevolverFalsoPorqueNoHaySuficienteAzucarEnElAzuquero()
        {
            // Act
            bool resultado = azuquero.HasAzucar(15);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void DeberiaRestarAzucarAlAzuquero()
        {
            // Act
            azuquero.GiveAzucar(5);

            // Assert
            Assert.Equal(5, azuquero.GetCantidadDeAzucar());

            // Act
            azuquero.GiveAzucar(2);

            // Assert
            Assert.Equal(3, azuquero.GetCantidadDeAzucar());
        }
    }
}
