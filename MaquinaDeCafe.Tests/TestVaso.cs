using Xunit;
using MaquinaDeCafe;

namespace MaquinaDeCafe.Tests
{
    public class TestVaso
    {
        [Fact]
        public void DeberiaDevolverVerdaderoSiExistenVasos()
        {
            // Arrange
            Vaso vasosPequenos = new Vaso(2, 10);

            // Act
            bool resultado = vasosPequenos.HasVasos(1);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void DeberiaDevolverFalsoSiNoExistenVasos()
        {
            // Arrange
            Vaso vasosPequenos = new Vaso(1, 10);

            // Act
            bool resultado = vasosPequenos.HasVasos(2);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void DeberiaRestarCantidadDeVaso()
        {
            // Arrange
            Vaso vasosPequenos = new Vaso(5, 10);

            // Act
            vasosPequenos.GiveVasos(1);

            // Assert
            Assert.Equal(4, vasosPequenos.GetCantidadVasos());
        }
    }
}
