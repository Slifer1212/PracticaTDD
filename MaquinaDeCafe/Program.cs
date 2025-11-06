using System;

namespace MaquinaDeCafe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Encabezado
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

            // Bucle interactivo
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("☕ NUEVO PEDIDO");
                Console.WriteLine("═══════════════════════════════════════");

                string tipoVaso = PedirTamano();
                int cantidad = PedirEntero("¿Cuántos cafés desea? (ingrese un número entero mayor que 0): ", minValue: 1);
                int azucar = PedirEntero("¿Cuántas cucharadas de azúcar por vaso? (0 o más): ", minValue: 0);

                Console.WriteLine();
                EjecutarPedidoInteractivo(maquina, tipoVaso, cantidad, azucar);

                Console.WriteLine();
                MostrarInventario(maquina);

                // Preguntar si desea otro pedido
                Console.Write("\n¿Desea realizar otro pedido? (s/n): ");
                string resp = Console.ReadLine()?.Trim().ToLower() ?? "n";
                continuar = resp == "s" || resp == "si";
            }

            Console.WriteLine("\n📊 Estado Final:");
            MostrarInventario(maquina);

            Console.WriteLine("\n╔═══════════════════════════════════════╗");
            Console.WriteLine("║   Gracias por usar nuestra máquina    ║");
            Console.WriteLine("╚═══════════════════════════════════════╝");
        }

        // Pide al usuario que elija un tamaño y devuelve "pequeno", "mediano" o "grande"
        static string PedirTamano()
        {
            while (true)
            {
                Console.WriteLine("Seleccione el tamaño del café:");
                Console.WriteLine("1. Pequeño (3 Oz)");
                Console.WriteLine("2. Mediano  (5 Oz)");
                Console.WriteLine("3. Grande   (7 Oz)");
                Console.Write("👉 Opción (1-3): ");

                string opcion = Console.ReadLine()?.Trim();
                switch (opcion)
                {
                    case "1":
                    case "pequeno":
                    case "pequeño":
                        return "pequeno";
                    case "2":
                    case "mediano":
                        return "mediano";
                    case "3":
                    case "grande":
                        return "grande";
                    default:
                        Console.WriteLine("⚠️ Opción inválida. Intente de nuevo.\n");
                        break;
                }
            }
        }

        // Lee un entero validado por el usuario (con mensaje, opcionalmente con un minimo)
        static int PedirEntero(string mensaje, int? minValue = null, int? maxValue = null)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                if (int.TryParse(entrada, out int valor))
                {
                    if (minValue.HasValue && valor < minValue.Value)
                    {
                        Console.WriteLine($"⚠️ Debe ser al menos {minValue.Value}. Intente de nuevo.");
                        continue;
                    }
                    if (maxValue.HasValue && valor > maxValue.Value)
                    {
                        Console.WriteLine($"⚠️ No puede ser mayor que {maxValue.Value}. Intente de nuevo.");
                        continue;
                    }
                    return valor;
                }
                Console.WriteLine("⚠️ Entrada no válida. Ingrese un número entero.");
            }
        }

        // Ejecuta el pedido (usa la lógica existente que tenías)
        static void EjecutarPedidoInteractivo(MaquinaDeCafe maquina, string tipoVaso, int cantidad, int azucar)
        {
            Console.WriteLine($"📝 Pedido: {cantidad} vaso(s) de tipo '{tipoVaso}' con {azucar} cucharada(s) de azúcar por vaso.");

            Vaso vaso = maquina.GetTipoDeVaso(tipoVaso);
            if (vaso == null)
            {
                Console.WriteLine("❌ Tipo de vaso no válido.");
                return;
            }

            string resultado = maquina.GetVasoDeCafe(vaso, cantidad, azucar);

            if (resultado == "Felicitaciones")
            {
                Console.WriteLine("✅ " + resultado + " - Su(s) café(s) está(n) listo(s)!");
            }
            else
            {
                Console.WriteLine("❌ " + resultado);
            }
        }

        // Muestra el inventario (mismo formato que tenías)
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
