using System;
using System.Configuration;
using System.Windows.Forms;
using System.Data;
using PaiLab.Controllers;  // Asegúrate de importar el controlador

namespace PaiLab.WinApp
{
    public partial class FrmIngreso : Form
    {
        public FrmIngreso()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string NombreUsuario = txtNombreUsuario.Text.Trim();
            string contraseña = txtContraseña.Text;

            // Verificamos que los campos no estén vacíos
            if (string.IsNullOrEmpty(NombreUsuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Leer la cadena de conexión desde el archivo app.config
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

            // Crear una instancia del controlador de administrador
            AdministradorControllers adminControllers = new AdministradorControllers(connectionString);

            // Verificar las credenciales llamando al método del controlador
            bool accesoConcedido = adminControllers.VerificarCredenciales(NombreUsuario, contraseña);

            if (accesoConcedido)
            {
                MessageBox.Show("¡Bienvenido al sistema, Administrador!", "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Crear y mostrar el formulario principal después de iniciar sesión con éxito
                FrmPrincipal frmPrincipal = new FrmPrincipal();
                frmPrincipal.Show();  // Mostrar el formulario principal

                // Ocultar el formulario de ingreso
                this.Hide();  // El formulario de ingreso ahora está oculto, no cerrado, solo escondido
            }
            else
            {
                MessageBox.Show("Nombre del usuario o contraseña incorrectos. Por favor, inténtelo de nuevo.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
