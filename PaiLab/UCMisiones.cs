using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PaiLab.Controller;
using PaiLab.Controllers;
using PaiLab.Model;

namespace PaiLab.WinApp.UserControls
{
    public partial class UcMisiones : UserControl
    {

        private MisionesControllers controller;
        private List<Misiones> listaMisiones;

        public UcMisiones()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            controller = new MisionesControllers(connectionString);

            AplicarEstilo();
            CargarDificultades();
            CargarLugares();
            CargarMisiones();
        }

        private void AplicarEstilo()
        {
            this.BackColor = Color.FromArgb(255, 245, 235);

            foreach (Control ctrl in this.Controls)
            {
                switch (ctrl)
                {
                    case Button btn:
                        btn.BackColor = Color.FromArgb(255, 192, 203);
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                        break;
                    case Label lbl:
                        lbl.ForeColor = Color.FromArgb(100, 50, 50);
                        break;
                    case TextBox txt:
                        txt.BackColor = Color.WhiteSmoke;
                        break;
                    case ComboBox cmb:
                        cmb.BackColor = Color.WhiteSmoke;
                        break;
                }
            }

            dgvMisiones.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 192, 203);
        }

        private void CargarDificultades()
        {
            comboDificultad.Items.Clear();
            comboDificultad.Items.AddRange(new[] { "Fácil", "Media", "Difícil" });
        }

        private void CargarLugares()
        {
            var lugares = new LugaresDeReventaControllers().ObtenerTodos();
            comboLugar.DataSource = lugares;
            comboLugar.DisplayMember = "Nombre";
            comboLugar.ValueMember = "Id";
            comboLugar.SelectedIndex = -1;
        }

        private void CargarMisiones()
        {
            listaMisiones = controller.ObtenerTodas();
            dgvMisiones.Rows.Clear();

            var lugares = new LugaresDeReventaControllers().ObtenerTodos();

            foreach (var m in listaMisiones)
            {
                string nombreLugar = "Desconocido";
                if (m.LugaresDeReventaId.Any())
                {
                    int lugarId = m.LugaresDeReventaId.First();
                    var lugar = lugares.FirstOrDefault(l => l.Id == lugarId);
                    if (lugar != null)
                        nombreLugar = lugar.Nombre;
                }

                dgvMisiones.Rows.Add(
                    m.Id,
                    m.Nombre,
                    m.Descripcion,
                    m.Dificultad,
                    nombreLugar
                );
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            var m = new Misiones
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Dificultad = comboDificultad.SelectedItem.ToString(),
                LugaresDeReventaId = new List<int> { (int)comboLugar.SelectedValue }
            };

            controller.Agregar(m);
            CargarMisiones();
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMisiones.CurrentRow == null || !ValidarCampos()) return;

            int id = Convert.ToInt32(dgvMisiones.CurrentRow.Cells[0].Value);

            var m = new Misiones
            {
                Id = id,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Dificultad = comboDificultad.SelectedItem.ToString(),
                LugaresDeReventaId = new List<int> { (int)comboLugar.SelectedValue }
            };

            controller.Actualizar(m);
            CargarMisiones();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMisiones.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvMisiones.CurrentRow.Cells[0].Value);
            controller.Eliminar(id);
            CargarMisiones();
            LimpiarCampos();
        }

        private void dgvMisiones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMisiones.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvMisiones.CurrentRow.Cells[0].Value);
            var mision = listaMisiones.FirstOrDefault(m => m.Id == id);
            if (mision == null) return;

            txtNombre.Text = mision.Nombre;
            txtDescripcion.Text = mision.Descripcion;
            comboDificultad.SelectedItem = mision.Dificultad;


            if (mision.LugaresDeReventaId.Any())
                comboLugar.SelectedValue = mision.LugaresDeReventaId.First();
            else
                comboLugar.SelectedIndex = -1;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            comboDificultad.SelectedIndex = -1;
            comboLugar.SelectedIndex = -1;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                comboDificultad.SelectedIndex == -1 ||
                comboLugar.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
