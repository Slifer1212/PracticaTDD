namespace MaquinaDeCafe
{
    public class Azucarero
    {
        private int cantidadDeAzucar;

        public Azucarero(int cantidadDeAzucar)
        {
            this.cantidadDeAzucar = cantidadDeAzucar;
        }

        public void SetCantidadDeAzucar(int cantidad)
        {
            this.cantidadDeAzucar = cantidad;
        }

        public int GetCantidadDeAzucar()
        {
            return cantidadDeAzucar;
        }

        public bool HasAzucar(int cantidadRequerida)
        {
            return cantidadDeAzucar >= cantidadRequerida;
        }

        public void GiveAzucar(int cantidad)
        {
            if (HasAzucar(cantidad))
            {
                cantidadDeAzucar -= cantidad;
            }
        }
    }
}
