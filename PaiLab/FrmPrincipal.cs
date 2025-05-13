using System;
using System.Configuration;
using System.Windows.Forms;
using PaiLab.WinApp.UserControls;
using PaiLab.Model;
using PaiLab.Views;
using PaiLab;
using PaiLab.UserControls;

namespace PaiLab.WinApp
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();

            // Asocia los eventos a los botones de navegación
            btnRevendedores.Click += (s, e) => CargarUserControl(new UserControlRevendedores());
            btnBeneficios.Click += (s, e) => CargarUserControl(new UCBeneficios());
            btnLugaresDeReventa.Click += (s, e) => CargarUserControl(new UcLugaresDeReventa());
            btnMisiones.Click += (s, e) => CargarUserControl(new UcMisiones());
            btnConfiguracion.Click += (s, e) => MessageBox.Show("Configuración (a implementar)");
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            btnAdministradores.Click += btnAdministradores_Click;

            // NUEVO BOTÓN AGREGADO para abrir el filtro de lugares
            btnFiltrarLugares.Click += btnFiltrarLugares_Click;
        }

        // Método para cargar los UserControls en el panel de contenido
        private void CargarUserControl(UserControl control)
        {
            panelContenido.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            CargarUserControl(new UserControlRevendedores());
        }

        private void btnRevendedores_Click(object sender, EventArgs e)
        {
            CargarUserControl(new UserControlRevendedores());
        }

        private void btnBeneficios_Click(object sender, EventArgs e)
        {
            CargarUserControl(new UCBeneficios());
        }

        private void btnLugaresDeReventa_Click(object sender, EventArgs e)
        {
            CargarUserControl(new UcLugaresDeReventa());
        }

        private void btnMisiones_Click(object sender, EventArgs e)
        {
            CargarUserControl(new UcMisiones());
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Configuración (a implementar)");
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmIngreso frmIngreso = new FrmIngreso();
            frmIngreso.Show();
            this.Close();
        }

        private void btnAdministradores_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            FrmABMAdministrador frmAdmin = new FrmABMAdministrador(connectionString);
            frmAdmin.ShowDialog();
        }

        // NUEVO EVENTO PARA EL BOTÓN DE FILTRO
        private void btnFiltrarLugares_Click(object sender, EventArgs e)
        {
            FrmFiltroLugares filtroForm = new FrmFiltroLugares();
            filtroForm.Show();
        }
    }
}