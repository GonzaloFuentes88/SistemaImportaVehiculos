using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Mejora
    {
        public Mejora() { }
        public Mejora(string NombreMejora, double Precio, bool Estado, Vehiculo Vehiculo) 
        {
            this.NombreMejora = NombreMejora;
            this.Precio = Precio;
            this.Estado = Estado;
            this.Vehiculo = Vehiculo;
        }

        private string _nombreMejora;

        public string NombreMejora
        {
            get { return _nombreMejora; }
            set { _nombreMejora = value; }
        }

        private double _precio;

        public double Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        private bool _estado;

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }


        private Vehiculo _vehiculo;

        public Vehiculo Vehiculo
        {
            get { return _vehiculo; }
            set { _vehiculo = value; }
        }

    }
}
