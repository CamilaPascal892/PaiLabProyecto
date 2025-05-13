using System;

namespace PaiLab.Model
{
    public class Administrador
    {
        public int IdAdministrador { get; set; }           // Clave primaria
        public string NombreUsuario { get; set; }          // Nombre de login
        public string Contrasena { get; set; }             // Contraseña (encriptada idealmente)
        public string NombreCompleto { get; set; }         // Nombre visible
        public string Email { get; set; }                  // Correo electrónico
        public DateTime FechaRegistro { get; set; }        // Fecha de alta

        public Administrador() { }

        public Administrador(int idAdministrador, string nombreUsuario, string contrasena, string nombreCompleto, string email, DateTime fechaRegistro)
        {
            IdAdministrador = idAdministrador;
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            NombreCompleto = nombreCompleto;
            Email = email;
            FechaRegistro = fechaRegistro;
        }

        public override string ToString()
        {
            return $"{NombreCompleto} ({NombreUsuario})";
        }
    }
}

