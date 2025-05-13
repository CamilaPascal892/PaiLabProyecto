using PaiLab.Controllers;
using PaiLab.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PaiLab.UserControls
{
    public partial class UcLugaresDeReventa : UserControl
    {
        private LugaresDeReventaControllers controller = new LugaresDeReventaControllers();
        private int? idSeleccionado = null;

        public UcLugaresDeReventa()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            dgvLugares.DataSource = null;
            dgvLugares.DataSource = controller.ObtenerTodos();
            dgvLugares.ClearSelection();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtUbicacion.Text = "";
            txtTipo.Text = "";
            txtDescripcion.Text = "";
            idSeleccionado = null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            LugaresDeReventa lugar = new LugaresDeReventa
            {
                Nombre = txtNombre.Text,
                Ubicacion = txtUbicacion.Text,
                TipoMasVendido = txtTipo.Text,
                Descripcion = txtDescripcion.Text
            };

            controller.Agregar(lugar);
            CargarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null)
            {
                MessageBox.Show("Seleccioná un lugar para modificar.");
                return;
            }

            LugaresDeReventa lugar = new LugaresDeReventa
            {
                Id = idSeleccionado.Value,
                Nombre = txtNombre.Text,
                Ubicacion = txtUbicacion.Text,
                TipoMasVendido = txtTipo.Text,
                Descripcion = txtDescripcion.Text
            };

            controller.Modificar(lugar);
            CargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null)
            {
                MessageBox.Show("Seleccioná un lugar para eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Estás seguro de eliminar este lugar?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                controller.Eliminar(idSeleccionado.Value);
                CargarDatos();
            }
        }

        private void dgvLugares_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLugares.SelectedRows.Count > 0)
            {
                var fila = dgvLugares.SelectedRows[0].DataBoundItem as LugaresDeReventa;
                if (fila != null)
                {
                    idSeleccionado = fila.Id;
                    txtNombre.Text = fila.Nombre;
                    txtUbicacion.Text = fila.Ubicacion;
                    txtTipo.Text = fila.TipoMasVendido;
                    txtDescripcion.Text = fila.Descripcion;
                }
            }
        }
        // NUEVO MÉTODO PÚBLICO PARA FILTRAR DATOS EXTERNAMENTE
        public void FiltrarPorLista(List<LugaresDeReventa> lista)
        {
            dgvLugares.DataSource = null;
            dgvLugares.DataSource = lista;
            dgvLugares.ClearSelection();
            idSeleccionado = null;
            txtNombre.Clear();
            txtUbicacion.Clear();
            txtTipo.Clear();
            txtDescripcion.Clear();
        }
    }
}
    


