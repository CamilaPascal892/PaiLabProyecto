using System;
using System.Windows.Forms;
using PaiLab.Controllers;
using PaiLab.Model;
using System.Collections.Generic;

namespace PaiLab.Views
{
    public partial class UserControlRevendedores : UserControl
    {
        private RevendedoresControllers controlador = new RevendedoresControllers();

        public UserControlRevendedores()
        {
            InitializeComponent();
            CargarDatos();
            btnAgregar.Click += BtnAgregar_Click;
            btnModificar.Click += BtnModificar_Click;
            dgvRevendedores.SelectionChanged += DgvRevendedores_SelectionChanged;
        }

        private void CargarDatos()
        {
            dgvRevendedores.DataSource = controlador.ListarRevendedores();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            var nuevo = new Revendedores
            {
                Nombre = txtNombre.Text,
                Especialidad = txtEspecialidad.Text,
                VentasRealizadas = (int)numVentas.Value
            };

            if (controlador.AgregarRevendedores(nuevo))
                CargarDatos();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvRevendedores.CurrentRow != null)
            {
                var rev = (Revendedores)dgvRevendedores.CurrentRow.DataBoundItem;
                rev.Nombre = txtNombre.Text;
                rev.Especialidad = txtEspecialidad.Text;
                rev.VentasRealizadas = (int)numVentas.Value;

                if (controlador.ModificarRevendedor(rev))
                    CargarDatos();
            }
        }

      

        private void DgvRevendedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRevendedores.CurrentRow != null)
            {
                var rev = (Revendedores)dgvRevendedores.CurrentRow.DataBoundItem;
                txtNombre.Text = rev.Nombre;
                txtEspecialidad.Text = rev.Especialidad;
                numVentas.Value = rev.VentasRealizadas;
            }
        }
    }
}