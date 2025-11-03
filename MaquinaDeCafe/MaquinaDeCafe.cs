namespace MaquinaDeCafe
{
    public class MaquinaDeCafe
    {
        private Cafetera cafetera;
        private Vaso vasosPequenos;
        private Vaso vasosMedianos;
        private Vaso vasosGrandes;
        private Azucarero azucarero;

        public Cafetera Cafetera
        {
            get { return cafetera; }
        }

        public Vaso VasosPequenos
        {
            get { return vasosPequenos; }
        }

        public Vaso VasosMedianos
        {
            get { return vasosMedianos; }
        }

        public Vaso VasosGrandes
        {
            get { return vasosGrandes; }
        }

        public Azucarero Azucarero
        {
            get { return azucarero; }
        }

        public void SetCafetera(Cafetera cafetera)
        {
            this.cafetera = cafetera;
        }

        public void SetVasosPequeno(Vaso vasos)
        {
            this.vasosPequenos = vasos;
        }

        public void SetVasosMediano(Vaso vasos)
        {
            this.vasosMedianos = vasos;
        }

        public void SetVasosGrande(Vaso vasos)
        {
            this.vasosGrandes = vasos;
        }

        public void SetAzucarero(Azucarero azucarero)
        {
            this.azucarero = azucarero;
        }

        public Vaso GetTipoDeVaso(string tipoDeVaso)
        {
            switch (tipoDeVaso.ToLower())
            {
                case "pequeno":
                case "pequeño":
                    return vasosPequenos;
                case "mediano":
                    return vasosMedianos;
                case "grande":
                    return vasosGrandes;
                default:
                    return null;
            }
        }

        public string GetVasoDeCafe(Vaso vaso, int cantidadDeVasos, int cantidadDeAzucar)
        {
            // Verificar si hay vasos disponibles
            if (!vaso.HasVasos(cantidadDeVasos))
            {
                return "No hay Vasos";
            }

            // Verificar si hay suficiente café
            int cafeRequerido = vaso.GetContenido() * cantidadDeVasos;
            if (!cafetera.HasCafe(cafeRequerido))
            {
                return "No hay Cafe";
            }

            // Verificar si hay suficiente azúcar
            if (!azucarero.HasAzucar(cantidadDeAzucar))
            {
                return "No hay Azucar";
            }

            // Si todo está disponible, dispensar
            vaso.GiveVasos(cantidadDeVasos);
            cafetera.GiveCafe(cafeRequerido);
            azucarero.GiveAzucar(cantidadDeAzucar);

            return "Felicitaciones";
        }

        public string GetVasoDeCafe(string tipoDeVaso, int cantidadDeVasos, int cantidadDeAzucar)
        {
            Vaso vaso = GetTipoDeVaso(tipoDeVaso);
            if (vaso == null)
            {
                return "Tipo de vaso no válido";
            }
            return GetVasoDeCafe(vaso, cantidadDeVasos, cantidadDeAzucar);
        }
    }
}
