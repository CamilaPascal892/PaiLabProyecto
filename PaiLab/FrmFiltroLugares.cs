using System;
using System.Linq;
using System.Windows.Forms;
using PaiLab.Controllers;
using PaiLab.Model;
using PaiLab.UserControls;

namespace PaiLab.WinApp
{
    public partial class FrmFiltroLugares : Form
    {
        private UcLugaresDeReventa ucLugares;

        public FrmFiltroLugares()
        {
            InitializeComponent();
            InicializarControles();
        }

        private void InicializarControles()
        {
            // Crear el UserControl
            ucLugares = new UcLugaresDeReventa
            {
                Dock = DockStyle.Fill
            };
            pnlUserControl.Controls.Add(ucLugares);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string nombreBuscado = txtBuscarNombre.Text.Trim().ToLower();

            var lugares = new LugaresDeReventaControllers().ObtenerTodos();

            var filtrados = lugares
                .Where(l => l.Nombre != null && l.Nombre.ToLower().Contains(nombreBuscado))
                .ToList();

            ucLugares.FiltrarPorLista(filtrados);
        }
    }
}