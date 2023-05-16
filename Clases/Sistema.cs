using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Sistema
    {
        private static Sistema instance = null;

        public static Sistema GetSistema
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if (instance == null)
                {
                    instance = new Sistema();
                }
                return instance;
            }
        }
        private Sistema() {
            this.vehiculos = new List<Vehiculo>();
        }

        private List<Vehiculo> vehiculos;
        public  List<Vehiculo> Vehiculos
        {
            get { return vehiculos; }
            set { vehiculos = value; }
        }


        public float ConvertCombustible(float combustible, bool isGalon)
        {
            if (isGalon)
            {
                return combustible * 3.78F;
            }
            return combustible / 3.78F;
        }
        private float ConvertPunto(float distancia, bool isMilla)
        {
            if (isMilla)
            {
                return distancia / 1.609F;
            }
            return distancia * 1.609F;

        }

        public Vehiculo obtenerVehiculo(long codigo) 
        {
            Vehiculo vehiculo = null;
            foreach(Vehiculo v in vehiculos)
            {
                if(v.Codigo == codigo)
                {
                    vehiculo = v;
                }
            }
            return vehiculo;
        }

        public void DataVehiculosEnLocal(float dolar)
        {
            foreach(Vehiculo v in vehiculos)
            {
                v.Precio = v.Precio * dolar;
                v.CantidadCombustible = this.ConvertCombustible(v.CantidadCombustible, true);
                v.CapacidadTanque = this.ConvertCombustible(v.CapacidadTanque,true);
                v.VelocidadMaxima = this.ConvertPunto(v.VelocidadMaxima,true);
                v.DistanciaRecorrida = this.ConvertPunto(v.DistanciaRecorrida,true);
            }
        }
        public void DataVehiculosEnEuropa(float dolar)
        {
            foreach (Vehiculo v in vehiculos)
            {
                v.Precio = v.Precio / dolar;
                v.CantidadCombustible = this.ConvertCombustible(v.CantidadCombustible,false);
                v.CapacidadTanque = this.ConvertCombustible(v.CapacidadTanque,false);
                v.VelocidadMaxima = this.ConvertPunto(v.VelocidadMaxima, false);
                v.DistanciaRecorrida = this.ConvertPunto(v.DistanciaRecorrida, false);
            }
        }

        public void ActualizarSoftwareLocal(long dolar)
        {
            foreach(Vehiculo v in vehiculos)
            {
                foreach(Mejora m in v.Mejoras)
                {
                    if(m.NombreMejora.Equals("Software Update"))
                    {
                        m.Precio *= dolar;
                    }
                }
            }
        }
        public void ActualizarSoftwareDolar(long dolar)
        {
            foreach (Vehiculo v in vehiculos)
            {
                foreach (Mejora m in v.Mejoras)
                {
                    if (m.NombreMejora.Equals("Software Update"))
                    {
                        m.Precio /= dolar;
                    }
                }
            }
        }
    }
}
