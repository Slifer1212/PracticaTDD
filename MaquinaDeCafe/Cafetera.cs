namespace MaquinaDeCafe
{
    public class Cafetera
    {
        private int cantidadCafe;

        public Cafetera(int cantidadCafe)
        {
            this.cantidadCafe = cantidadCafe;
        }

        public void SetCantidadDeCafe(int cantidad)
        {
            this.cantidadCafe = cantidad;
        }

        public int GetCantidadDeCafe()
        {
            return cantidadCafe;
        }

        public bool HasCafe(int cantidadRequerida)
        {
            return cantidadCafe >= cantidadRequerida;
        }

        public void GiveCafe(int cantidad)
        {
            if (HasCafe(cantidad))
            {
                cantidadCafe -= cantidad;
            }
        }
    }
}
