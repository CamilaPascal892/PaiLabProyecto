using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PaiLab.Model;
using PaiLab.Controllers;
using System.Drawing;

namespace PaiLab
{
    public partial class FrmABMAdministrador : Form
    {
        private readonly AdministradorControllers controlador;

        public FrmABMAdministrador(string connectionString)
        {
            InitializeComponent();
            controlador = new AdministradorControllers(connectionString);
        }

        private void FrmABMAdministrador_Load(object sender, EventArgs e)
        {
            CargarAdministradores();
            dgvAdministradores.ClearSelection();
        }

        private void CargarAdministradores()
        {
            var lista = controlador.ObtenerTodos();
            dgvAdministradores.DataSource = lista;
            dgvAdministradores.ClearSelection();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                string.IsNullOrWhiteSpace(txtNombreCompleto.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var admin = new Administrador
            {
                NombreUsuario = txtUsuario.Text,
                Contrasena = txtContrasena.Text,
                NombreCompleto = txtNombreCompleto.Text,
                Email = txtEmail.Text,
                FechaRegistro = DateTime.Now
            };

            try
            {
                controlador.CrearAdministrador(admin);
                MessageBox.Show("Administrador agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarAdministradores();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el administrador: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvAdministradores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un administrador para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                string.IsNullOrWhiteSpace(txtNombreCompleto.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var admin = new Administrador
            {
                IdAdministrador = Convert.ToInt32(txtId.Text),
                NombreUsuario = txtUsuario.Text,
                Contrasena = txtContrasena.Text,
                NombreCompleto = txtNombreCompleto.Text,
                Email = txtEmail.Text,
                FechaRegistro = DateTime.Now // O mantener la fecha original si se desea
            };

            try
            {
                controlador.ActualizarAdministrador(admin);
                MessageBox.Show("Administrador modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarAdministradores();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el administrador: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAdministradores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un administrador para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(txtId.Text);

            var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar este administrador?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    controlador.EliminarAdministrador(id);
                    MessageBox.Show("Administrador eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarAdministradores();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el administrador: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvAdministradores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAdministradores.SelectedRows.Count > 0)
            {
                var fila = dgvAdministradores.SelectedRows[0];
                txtId.Text = fila.Cells["IdAdministrador"].Value.ToString();
                txtUsuario.Text = fila.Cells["NombreUsuario"].Value.ToString();
                txtContrasena.Text = fila.Cells["Contrasena"].Value.ToString();
                txtNombreCompleto.Text = fila.Cells["NombreCompleto"].Value.ToString();
                txtEmail.Text = fila.Cells["Email"].Value.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtUsuario.Clear();
            txtContrasena.Clear();
            txtNombreCompleto.Clear();
            txtEmail.Clear();
            dgvAdministradores.ClearSelection();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}