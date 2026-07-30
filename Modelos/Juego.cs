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
    }
}