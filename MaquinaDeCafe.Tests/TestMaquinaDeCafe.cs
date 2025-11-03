using Xunit;
using MaquinaDeCafe;

namespace MaquinaDeCafe.Tests
{
    public class TestMaquinaDeCafe
    {
        private Cafetera cafetera;
        private Vaso vasosPequeno;
        private Vaso vasosMediano;
        private Vaso vasosGrande;
        private Azucarero azucarero;
        private MaquinaDeCafe maquinaDeCafe;

        public TestMaquinaDeCafe()
        {
            cafetera = new Cafetera(50);
            vasosPequeno = new Vaso(5, 10);
            vasosMediano = new Vaso(5, 20);
            vasosGrande = new Vaso(5, 30);
            azucarero = new Azucarero(20);

            maquinaDeCafe = new MaquinaDeCafe();
            maquinaDeCafe.SetCafetera(cafetera);
            maquinaDeCafe.SetVasosPequeno(vasosPequeno);
            maquinaDeCafe.SetVasosMediano(vasosMediano);
            maquinaDeCafe.SetVasosGrande(vasosGrande);
            maquinaDeCafe.SetAzucarero(azucarero);
        }

        [Fact]
        public void DeberiaDevolverUnVasoPequeno()
        {
            // Act
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

            // Assert
            Assert.Equal(maquinaDeCafe.VasosPequenos, vaso);
        }

        [Fact]
        public void DeberiaDevolverUnVasoMediano()
        {
            // Arrange
            MaquinaDeCafe maquinaDeCafe = new MaquinaDeCafe();

            // Act
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("mediano");

            // Assert
            Assert.Equal(maquinaDeCafe.VasosMedianos, vaso);
        }

        [Fact]
        public void DeberiaDevolverUnVasoGrande()
        {
            // Act
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("grande");

            // Assert
            Assert.Equal(maquinaDeCafe.VasosGrandes, vaso);
        }

        [Fact]
        public void DeberiaDevolverNoHayVasos()
        {
            // Arrange
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

            // Act
            string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 10, 2);

            // Assert
            Assert.Equal("No hay Vasos", resultado);
        }

        [Fact]
        public void DeberiaDevolverNoHayCafe()
        {
            // Arrange
            cafetera = new Cafetera(5);
            maquinaDeCafe.SetCafetera(cafetera);

            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

            // Act
            string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 1, 2);

            // Assert
            Assert.Equal("No hay Cafe", resultado);
        }

        [Fact]
        public void DeberiaDevolverNoHayAzucar()
        {
            // Arrange
            azucarero = new Azucarero(2);
            maquinaDeCafe.SetAzucarero(azucarero);

            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

            // Act
            string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

            // Assert
            Assert.Equal("No hay Azucar", resultado);
        }

        [Fact]
        public void DeberiaRestarCafe()
        {
            // Arrange
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

            // Act
            maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

            // Assert
            int resultado = maquinaDeCafe.Cafetera.GetCantidadDeCafe();
            Assert.Equal(40, resultado);
        }

        [Fact]
        public void DeberiaRestarVaso()
        {
            // Arrange
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

            // Act
            maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

            // Assert
            int resultado = maquinaDeCafe.VasosPequenos.GetCantidadVasos();
            Assert.Equal(4, resultado);
        }

        [Fact]
        public void DeberiaRestarAzucar()
        {
            // Arrange
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

            // Act
            maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

            // Assert
            int resultado = maquinaDeCafe.Azucarero.GetCantidadDeAzucar();
            Assert.Equal(17, resultado);
        }

        [Fact]
        public void DeberiaDevolverFelicitaciones()
        {
            // Arrange
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

            // Act
            string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

            // Assert
            Assert.Equal("Felicitaciones", resultado);
        }
    }
}
