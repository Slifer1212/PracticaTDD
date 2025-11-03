namespace MaquinaDeCafe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔═══════════════════════════════════════╗");
            Console.WriteLine("║   MÁQUINA DISPENSADORA DE CAFÉ        ║");
            Console.WriteLine("╚═══════════════════════════════════════╝");
            Console.WriteLine();

            // Inicializar la máquina de café
            var cafetera = new Cafetera(100);
            var vasosPequenos = new Vaso(10, 3);
            var vasosMedianos = new Vaso(10, 5);
            var vasosGrandes = new Vaso(10, 7);
            var azucarero = new Azucarero(50);

            var maquina = new MaquinaDeCafe();
            maquina.SetCafetera(cafetera);
            maquina.SetVasosPequeno(vasosPequenos);
            maquina.SetVasosMediano(vasosMedianos);
            maquina.SetVasosGrande(vasosGrandes);
            maquina.SetAzucarero(azucarero);

            Console.WriteLine("📊 Estado Inicial:");
            MostrarInventario(maquina);
            Console.WriteLine();

            // Ejemplo 1: Solicitar un café pequeño
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("☕ Ejemplo 1: Café Pequeño (3 Oz)");
            Console.WriteLine("═══════════════════════════════════════");
            EjecutarPedido(maquina, "pequeno", 1, 2);

            // Ejemplo 2: Solicitar un café mediano
            Console.WriteLine("\n═══════════════════════════════════════");
            Console.WriteLine("☕ Ejemplo 2: Café Mediano (5 Oz)");
            Console.WriteLine("═══════════════════════════════════════");
            EjecutarPedido(maquina, "mediano", 1, 3);

            // Ejemplo 3: Solicitar un café grande
            Console.WriteLine("\n═══════════════════════════════════════");
            Console.WriteLine("☕ Ejemplo 3: Café Grande (7 Oz)");
            Console.WriteLine("═══════════════════════════════════════");
            EjecutarPedido(maquina, "grande", 1, 1);

            // Ejemplo 4: Solicitar múltiples cafés
            Console.WriteLine("\n═══════════════════════════════════════");
            Console.WriteLine("☕ Ejemplo 4: 3 Cafés Pequeños");
            Console.WriteLine("═══════════════════════════════════════");
            EjecutarPedido(maquina, "pequeno", 3, 5);

            // Mostrar estado final
            Console.WriteLine("\n📊 Estado Final:");
            MostrarInventario(maquina);

            Console.WriteLine("\n╔═══════════════════════════════════════╗");
            Console.WriteLine("║   Gracias por usar nuestra máquina    ║");
            Console.WriteLine("╚═══════════════════════════════════════╝");
        }

        static void EjecutarPedido(MaquinaDeCafe maquina, string tipoVaso, int cantidad, int azucar)
        {
            Console.WriteLine($"📝 Pedido: {cantidad} vaso(s) de tipo '{tipoVaso}' con {azucar} cucharada(s) de azúcar");
            
            Vaso vaso = maquina.GetTipoDeVaso(tipoVaso);
            if (vaso != null)
            {
                string resultado = maquina.GetVasoDeCafe(vaso, cantidad, azucar);
                
                if (resultado == "Felicitaciones")
                {
                    Console.WriteLine("✅ " + resultado + " - Su café está listo!");
                }
                else
                {
                    Console.WriteLine("❌ " + resultado);
                }
            }
            else
            {
                Console.WriteLine("❌ Tipo de vaso no válido");
            }
        }

        static void MostrarInventario(MaquinaDeCafe maquina)
        {
            Console.WriteLine($"   ☕ Café disponible: {maquina.Cafetera.GetCantidadDeCafe()} Oz");
            Console.WriteLine($"   🥤 Vasos pequeños: {maquina.VasosPequenos.GetCantidadVasos()} unidades ({maquina.VasosPequenos.GetContenido()} Oz c/u)");
            Console.WriteLine($"   🥤 Vasos medianos: {maquina.VasosMedianos.GetCantidadVasos()} unidades ({maquina.VasosMedianos.GetContenido()} Oz c/u)");
            Console.WriteLine($"   🥤 Vasos grandes: {maquina.VasosGrandes.GetCantidadVasos()} unidades ({maquina.VasosGrandes.GetContenido()} Oz c/u)");
            Console.WriteLine($"   🍬 Azúcar disponible: {maquina.Azucarero.GetCantidadDeAzucar()} cucharadas");
        }
    }
}
