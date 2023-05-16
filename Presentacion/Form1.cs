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
    public partial class Form1 : Form
    {
        private Form2 form2;

        private Sistema sistema;
        public Form1()
        {
            InitializeComponent();
            sistema = Sistema.GetSistema;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vehiculo v;
            try
            {
                if (DatosLocales.Checked)
                {
                    v = sistema.obtenerVehiculo(long.Parse(textBox1.Text));
                    if (v !=null) {
                        form2 = new Form2();
                        form2.Codigo = v.Codigo;
                        form2.Dolar = long.Parse(textBoxDolar.Text);
                        form2.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("EL CODIGO DE VEHICULO INGRESADO NO EXISTE");
                    }
                }
                else
                {
                    MessageBox.Show("ANTES DE AVANZAR DEBE ACTUALIZAR LOS DATOS A LOCAL");
                }
                
                
            }
            catch (FormatException)
            {
                MessageBox.Show("POR FAVOR INGRESE VALORES NUMERICOS");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //VEHICULO INGRESADO CON VALORES EN EUROPEO
            Vehiculo v1 = new Automovil(1231,"AUTO EUROPEO", 7.5295F, 14.5295F, 3106.856F, "Negro", 207);
            Vehiculo v2 = new Automovil(1345, "AUTO EUROPEO", 7.5295F, 14.5295F, 3106.856F, "Negro", 207);
            Vehiculo v3 = new Automovil(5135, "AUTO EUROPEO", 7.5295F, 14.5295F, 3106.856F, "Negro", 207);
            Vehiculo c1 = new Camioneta(1241, "CAMIONETA EUROPEA", 7.5295F, 14.5295F, 3106.856F, "Negro", 207, this.sistema);
            Vehiculo c2 = new Camioneta(4535, "CAMIONETA EUROPEA", 7.5295F, 14.5295F, 3106.856F, "Negro", 207, this.sistema);
            Vehiculo c3 = new Camioneta(7675, "CAMIONETA EUROPEA", 7.5295F, 14.5295F, 3106.856F, "Negro", 207, this.sistema);
            sistema.Vehiculos.Add(v1);
            sistema.Vehiculos.Add(v2);
            sistema.Vehiculos.Add(v3);
            sistema.Vehiculos.Add(c1);
            sistema.Vehiculos.Add(c2);
            sistema.Vehiculos.Add(c3);

            dgv.DataSource = null;
            dgv.DataSource = sistema.Vehiculos;
            dgv.Columns["Sistema"].Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (DatosLocales.Checked)
                {
                    textBoxDolar.ReadOnly = true;
                    sistema.DataVehiculosEnLocal(long.Parse(textBoxDolar.Text));
                    sistema.ActualizarSoftwareLocal(long.Parse(textBoxDolar.Text));

                    dgv.DataSource = null;
                    dgv.DataSource = sistema.Vehiculos;
                    dgv.Columns["Sistema"].Visible = false;
                }
                else
                {
                    textBoxDolar.ReadOnly = false;
                    sistema.DataVehiculosEnEuropa(long.Parse(textBoxDolar.Text));
                    sistema.ActualizarSoftwareDolar(long.Parse(textBoxDolar.Text));

                    dgv.DataSource = null;
                    dgv.DataSource = sistema.Vehiculos;
                    dgv.Columns["Sistema"].Visible = false;
                }
            }
            catch (FormatException)
            {
                DatosLocales.CheckState = CheckState.Unchecked;
                MessageBox.Show("INGRESE EL VALOR DEL DOLAR");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
