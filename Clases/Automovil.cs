using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Automovil : Vehiculo
    {

        public Automovil() { }
        public Automovil(long Codigo, string Nombre, float CantidadCombustible, float CapacidadTanque
            , float DistanciaRecorrida, string Color, float VelocidadMaxima)
        {
            this.Codigo = Codigo;
            this.Nombre = Nombre;
            this.CantidadCombustible = CantidadCombustible;
            this.CapacidadTanque = CapacidadTanque;
            this.DistanciaRecorrida = DistanciaRecorrida;
            this.Color = Color;
            this.VelocidadMaxima = VelocidadMaxima;
            this.Precio = 100000;
            this.GenerarMejoras();
        }
        public override void HabilitarMejora(string nombre)
        {
            foreach (Mejora m in this.Mejoras)
            {
                if (m.NombreMejora.Equals(nombre))
                {
                    m.Estado = true;
                }
            }
        }

        public override void DeshabilitarMejora(string nombre)
        {
            foreach (Mejora m in this.Mejoras)
            {
                if (m.NombreMejora.Equals(nombre))
                {
                    m.Estado = false;
                }
            }
        }

        public override void GenerarMejoras()
        {
            Mejora m1 = new Mejora("Software Update", 1500, false, this);
            Mejora m2 = new Mejora("Alarma", 5000, false, this);
            Mejora m3 = new Mejora("Vidrios", 1500, false, this);
            Mejora m4 = new Mejora("Balizas", 1000, false, this);
            Mejora m5 = new Mejora("Luces", 7500, false, this);
            this.Mejoras.Add(m1);
            this.Mejoras.Add(m2);
            this.Mejoras.Add(m3);
            this.Mejoras.Add(m4);
            this.Mejoras.Add(m5);
        }
    }
}
