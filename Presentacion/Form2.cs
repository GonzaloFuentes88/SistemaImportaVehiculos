using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;

namespace Presentacion
{
    public partial class Form2 : Form
    {
        private Sistema sistema;

        private long _dolar;

        public long Dolar
        {
            get { return _dolar; }
            set { _dolar = value; }
        }


        private long _codigo;
        
        public long Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public Form2()
        {
            InitializeComponent();
            sistema = Sistema.GetSistema;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Vehiculo vehiculo = sistema.obtenerVehiculo(Codigo);
            this.textBoxVehiculo.Text = vehiculo.GetType().Name + " - "+ vehiculo.Nombre;
            this.textBoxCodigo.Text = vehiculo.Codigo.ToString();
            this.textBoxColor.Text = vehiculo.Color;
            this.textBoxCapacidad.Text = vehiculo.CapacidadTanque.ToString();
            this.textBoxCantidad.Text = vehiculo.CantidadCombustible.ToString();
            this.textBoxDistancia.Text = vehiculo.DistanciaRecorrida.ToString();
            this.textBoxVelocidad.Text = vehiculo.VelocidadMaxima.ToString();
            this.textBoxSubTotal.Text = vehiculo.Precio.ToString() + " PESOS";
            this.textBoxTotal.Text = vehiculo.Precio.ToString() +" PESOS";
            this.textBoxDolar.Text = "$"+ this.Dolar.ToString();
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void buttonPresupuestar_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = sistema.obtenerVehiculo(Codigo);

            if (checkBoxSwUpdate.Checked)
            {
                vehiculo.HabilitarMejora("Software Update");
            }
            else
            {
                vehiculo.DeshabilitarMejora("Software Update");
            }
            if (checkBoxAlarma.Checked)
            {
                vehiculo.HabilitarMejora("Alarma");
            }
            else
            {
                vehiculo.DeshabilitarMejora("Alarma");
            }
            if(checkBoxVidrios.Checked)
            {
                vehiculo.HabilitarMejora("Vidrios");
            }
            else
            {
                vehiculo.DeshabilitarMejora("Vidrios");
            }
            if (checkBoxBalizas.Checked)
            {
                vehiculo.HabilitarMejora("Balizas");
            }
            else
            {
                vehiculo.DeshabilitarMejora("Balizas");
            }
            if (checkBoxLuces.Checked)
            {
                vehiculo.HabilitarMejora("Luces");
            }
            else
            {
                vehiculo.DeshabilitarMejora("Luces");
            }
            textBoxMejoras.Text = vehiculo.TotalMejoras().ToString() + "PESOS";
            textBoxTotal.Text = vehiculo.TotalFinal().ToString() +" PESOS";
        }
    }
}
