using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AbstractFactoryAutomovil.mundo.interfaces;
using AbstractFactoryAutomovil.mundo.clases;
using AbstractFactoryAutomovil.mundo.fabricas;

namespace AbstractFactoryAutomovil
{
    public partial class Cliente : Form
    {
        private IFabricaDePartes fabrica;
        private IAuto auto;
        private IMotor motor;
        private ICarroceria carroceria;

        public Cliente()
        {
            InitializeComponent();
            lstPartes.SelectedIndex = 0;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (radMazda.Checked)
                fabrica = new FabricaMazda();
            else if (radRenault.Checked)
                fabrica = new FabricaRenault();
            else fabrica = new FabricaChevrolet();
            auto = fabrica.crearAuto();
            motor = fabrica.crearMotor();
            carroceria = fabrica.crearCarroceria();
            if (lstPartes.SelectedIndex == 0)
                MessageBox.Show(auto.darNombre());
            else if (lstPartes.SelectedIndex == 1)
                MessageBox.Show(motor.darNombre());
            else if (lstPartes.SelectedIndex == 2)
                MessageBox.Show(carroceria.darNombre());
        }
    }
}
