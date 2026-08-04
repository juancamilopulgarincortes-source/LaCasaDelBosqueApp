using System.Collections.Generic;

namespace LaCasaDelBosqueApp.Modelos
{
    public class Juego
    {
        public string Ubicacion = "Entrada";

        public List<string> Inventario = new List<string>();

        public bool PuertaHabitacionAbierta = false;

        public bool RadioTomada = false;

        public bool LlaveTomada = false;

        public bool SombraVista = false;

        public bool CombustibleTomado = false;

        public bool AutoConCombustible = false;

        // ===== Movimiento =====

        public bool Entrar()
        {
            if (Ubicacion != "Entrada")
                return false;

            Ubicacion = "Pasillo";
            return true;
        }

        public bool IrCocina()
        {
            if (Ubicacion == "Pasillo" || Ubicacion == "Patio")
            {
                Ubicacion = "Cocina";
                return true;
            }

            return false;
        }
        public bool IrBaño()
        {
            if (Ubicacion != "Pasillo")
                return false;

            Ubicacion = "Baño";
            return true;
        }
        public bool IrEntrada()
        {
            if (Ubicacion == "Pasillo" || Ubicacion == "Auto")
            {
                Ubicacion = "Entrada";
                return true;
            }

            return false;
        }
        public bool IrPasillo()
        {
            if (Ubicacion == "Cocina" ||
                Ubicacion == "Baño" ||
                Ubicacion == "Habitacion" ||
                Ubicacion == "Entrada")
            {
                Ubicacion = "Pasillo";
                return true;
            }

            return false;
        }
        public bool IrHabitacion()
        {
            if (Ubicacion != "Pasillo")
                return false;

            if (!PuertaHabitacionAbierta)
                return false;

            Ubicacion = "Habitacion";
            return true;
        }
        public bool IrPatio()
        {
            if (Ubicacion == "Cocina" || Ubicacion == "Sotano")
            {
                Ubicacion = "Patio";
                return true;
            }

            return false;
        }
        public bool IrSotano()
        {
            if (Ubicacion != "Patio")
                return false;

            Ubicacion = "Sotano";
            return true;
        }
        public bool IrAuto()
        {
            if (Ubicacion != "Entrada")
                return false;

            Ubicacion = "Auto";
            return true;
        }
        // ===== Inventario =====

        public bool TomarLlave()
        {
            if (Ubicacion != "Cocina")
                return false;

            if (Inventario.Contains("llave"))
                return false;

            Inventario.Add("llave");
            LlaveTomada = true;

            return true;
        }
        public bool TomarRadio()
        {
            if (Ubicacion != "Baño")
                return false;

            if (Inventario.Contains("radio"))
                return false;

            Inventario.Add("radio");
            RadioTomada = true;

            return true;
        }
        public bool TomarCombustible()
        {
            if (Ubicacion != "Sotano")
                return false;

            if (Inventario.Contains("combustible"))
                return false;

            Inventario.Add("combustible");
            CombustibleTomado = true;

            return true;
        }

        // ===== Interacciones =====
        public bool UsarLlave()
        {
            if (Ubicacion != "Pasillo")
                return false;

            if (!Inventario.Contains("llave"))
                return false;

            if (PuertaHabitacionAbierta)
                return false;

            Inventario.Remove("llave");
            PuertaHabitacionAbierta = true;

            return true;
        }
        public bool UsarCombustible()
        {
            if (Ubicacion != "Auto")
                return false;

            if (!Inventario.Contains("combustible"))
                return false;

            Inventario.Remove("combustible");
            AutoConCombustible = true;

            return true;
        }
        public bool UsarRadio()
        {
            return Inventario.Contains("radio");
        }
        public bool PuedeArrancar()
        {
            if (Ubicacion != "Auto")
                return false;

            if (!AutoConCombustible)
                return false;

            return true;
        }
    }
}