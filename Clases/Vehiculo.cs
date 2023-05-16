using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public abstract class Vehiculo
    {
        private long _codigo;

        public long Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }


        private double _precio;

        public double Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private float _velocidadMaxima;

        public float VelocidadMaxima
        {
            get { return _velocidadMaxima; }
            set { _velocidadMaxima = value; }
        }

        private float _cantidadCombustible;

        public float CantidadCombustible
        {
            get { return _cantidadCombustible; }
            set { _cantidadCombustible = value; }
        }

        private float _distanciaRecorrida;

        public float DistanciaRecorrida
        {
            get { return _distanciaRecorrida; }
            set { _distanciaRecorrida = value; }
        }


        private string _color;

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        private float _capacidadTanque;

        public float CapacidadTanque
        {
            get { return _capacidadTanque; }
            set { _capacidadTanque = value; }
        }

        private List<Mejora> _mejoras = new List<Mejora>();

        public List<Mejora> Mejoras
        {
            get { return _mejoras; }
            set { _mejoras = value; }
        }

        private Sistema _sistema;

        public Sistema Sistema
        {
            get { return _sistema; }
            set { _sistema = value; }
        }

        public double TotalMejoras()
        {
            double resultado = 0;
            foreach (Mejora m in this.Mejoras)
            {
                if (m.Estado)
                {
                    resultado += m.Precio;
                }
            }
            return resultado;
        }

        public double TotalFinal()
        {
            return this.Precio + this.TotalMejoras();
        }

        public abstract void GenerarMejoras();
        public abstract void HabilitarMejora(string nombre);
        public abstract void DeshabilitarMejora(string nombre);

        

    }
}
