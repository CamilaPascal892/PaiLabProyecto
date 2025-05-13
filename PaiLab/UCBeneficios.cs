using PaiLab.Model;
using PaiLab.Controllers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PaiLab
{
    public partial class UCBeneficios : UserControl
    {
        private readonly BeneficiosController _beneficiosController;
        private List<Beneficios> _beneficiosList;

        public UCBeneficios()
        {
            InitializeComponent();
            _beneficiosController = new BeneficiosController();
            CargarBeneficios();
            CargarCombos();
        }

        // Cargar la lista de beneficios en el DataGridView
        private void CargarBeneficios()
        {
            _beneficiosList = _beneficiosController.ObtenerTodos();
            dgvBeneficios.DataSource = _beneficiosList;
            dgvBeneficios.Columns["TipoBeneficio"].Visible = false;
        }


        private void CargarCombos()
        {
            try
            {
                if (cmbTipoBeneficioId == null || cmbLugaresDeReventaId == null || cmbRevendedores == null)
                {
                    MessageBox.Show("Alguno de los combos no está inicializado.");
                    return;
                }

                var tiposBeneficio = _beneficiosController.ListarTipoBenefecios();
                var lugaresDeReventaId = _beneficiosController.ListarLugaresDeReventa();
                var revendedores = _beneficiosController.ListarRevendedores();
                
                cmbTipoBeneficioId.DataSource = tiposBeneficio ?? new List<TipoBeneficio>();
                cmbTipoBeneficioId.DisplayMember = "Id";
                cmbTipoBeneficioId.ValueMember = "Id";

                cmbLugaresDeReventaId.DataSource = lugaresDeReventaId ?? new List<LugaresDeReventa>();
                cmbLugaresDeReventaId.DisplayMember = "Id";
                cmbLugaresDeReventaId.ValueMember = "Id";

                cmbRevendedores.DataSource = revendedores ?? new List<Revendedores>();
                cmbRevendedores.DisplayMember = "Id";
                cmbRevendedores.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar combos: " + ex.Message);
            }
        }

        // Limpiar los campos de entrada
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            cmbTipoBeneficioId.SelectedIndex = -1;
            cmbLugaresDeReventaId.SelectedIndex = -1;
            cmbRevendedores.SelectedIndex = -1;
        }

        // Método para agregar un beneficio
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevoBeneficio = new Beneficios
                {
                    Nombre = txtNombre.Text,
                    TipoBeneficioId = (int)cmbTipoBeneficioId.SelectedValue,
                    LugaresDeReventaId = (int)cmbLugaresDeReventaId.SelectedValue,
                    RevendedoresId = cmbRevendedores.SelectedValue == null ? (int?)null : (int)cmbRevendedores.SelectedValue
                };

                _beneficiosController.Agregar(nuevoBeneficio);
                CargarBeneficios();
                LimpiarCampos();
                MessageBox.Show("Beneficio agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el beneficio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para modificar un beneficio
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBeneficios.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un beneficio para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var beneficioSeleccionado = (Beneficios)dgvBeneficios.SelectedRows[0].DataBoundItem;
                beneficioSeleccionado.Nombre = txtNombre.Text;
                beneficioSeleccionado.TipoBeneficioId = cmbTipoBeneficioId.SelectedValue is null ? 0 : (int)cmbTipoBeneficioId.SelectedValue;
                beneficioSeleccionado.LugaresDeReventaId = cmbLugaresDeReventaId.SelectedValue is null ? 0 : (int)cmbLugaresDeReventaId.SelectedValue;
                beneficioSeleccionado.RevendedoresId = cmbRevendedores.SelectedValue == null ? (int?)null : (int)cmbRevendedores.SelectedValue;

                _beneficiosController.ModificarBeneficio(beneficioSeleccionado);
                CargarBeneficios();
                LimpiarCampos();
                MessageBox.Show("Beneficio modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el beneficio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Evento cuando se selecciona una fila en el DataGridView
        private void dgvBeneficios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBeneficios.SelectedRows.Count > 0)
            {
                var beneficioSeleccionado = (Beneficios)dgvBeneficios.SelectedRows[0].DataBoundItem;
                txtNombre.Text = beneficioSeleccionado.Nombre;
                cmbTipoBeneficioId.SelectedValue = beneficioSeleccionado.TipoBeneficioId;
                cmbLugaresDeReventaId.SelectedValue = beneficioSeleccionado.LugaresDeReventaId;
                cmbRevendedores.SelectedValue = beneficioSeleccionado.RevendedoresId;
            }
        }
    }
}