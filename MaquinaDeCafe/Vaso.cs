namespace MaquinaDeCafe
{
    public class Vaso
    {
        private int cantidadVasos;
        private int contenido;

        public Vaso(int cantidadVasos, int contenido)
        {
            this.cantidadVasos = cantidadVasos;
            this.contenido = contenido;
        }

        public void SetCantidadVasos(int cantidad)
        {
            this.cantidadVasos = cantidad;
        }

        public int GetCantidadVasos()
        {
            return cantidadVasos;
        }

        public void SetContenido(int contenido)
        {
            this.contenido = contenido;
        }

        public int GetContenido()
        {
            return contenido;
        }

        public bool HasVasos(int cantidad)
        {
            return cantidadVasos >= cantidad;
        }

        public void GiveVasos(int cantidad)
        {
            if (HasVasos(cantidad))
            {
                cantidadVasos -= cantidad;
            }
        }
    }
}
