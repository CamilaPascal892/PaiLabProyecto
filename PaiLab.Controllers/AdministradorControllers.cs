using PaiLab.Model;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace PaiLab.Controllers
{
    public class AdministradorControllers
    {
        private readonly string connectionString;

        public AdministradorControllers(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Administrador> ObtenerTodos()
        {
            var lista = new List<Administrador>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Administrador";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Administrador
                            {
                                IdAdministrador = Convert.ToInt32(reader["IdAdministrador"]),
                                NombreUsuario = reader["NombreUsuario"].ToString(),
                                Contrasena = reader["Contrasena"].ToString(),
                                NombreCompleto = reader["NombreCompleto"].ToString(),
                                Email = reader["Email"].ToString(),
                                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public Administrador ObtenerPorId(int id)
        {
            Administrador admin = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Administrador WHERE IdAdministrador = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            admin = new Administrador
                            {
                                IdAdministrador = Convert.ToInt32(reader["IdAdministrador"]),
                                NombreUsuario = reader["NombreUsuario"].ToString(),
                                Contrasena = reader["Contrasena"].ToString(),
                                NombreCompleto = reader["NombreCompleto"].ToString(),
                                Email = reader["Email"].ToString(),
                                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
                            };
                        }
                    }
                }
            }

            return admin;
        }

        public void CrearAdministrador(Administrador admin)
        {
            if (admin == null) throw new ArgumentNullException(nameof(admin));

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Administrador 
                                 (NombreUsuario, Contrasena, NombreCompleto, Email, FechaRegistro)
                                 VALUES (@NombreUsuario, @Contrasena, @NombreCompleto, @Email, @FechaRegistro)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombreUsuario", admin.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Contrasena", admin.Contrasena);
                    cmd.Parameters.AddWithValue("@NombreCompleto", admin.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Email", admin.Email);
                    cmd.Parameters.AddWithValue("@FechaRegistro", admin.FechaRegistro);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarAdministrador(Administrador admin)
        {
            if (admin == null) throw new ArgumentNullException(nameof(admin));

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Administrador
                                 SET NombreUsuario = @NombreUsuario,
                                     Contrasena = @Contrasena,
                                     NombreCompleto = @NombreCompleto,
                                     Email = @Email
                                 WHERE IdAdministrador = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombreUsuario", admin.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Contrasena", admin.Contrasena);
                    cmd.Parameters.AddWithValue("@NombreCompleto", admin.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Email", admin.Email);
                    cmd.Parameters.AddWithValue("@Id", admin.IdAdministrador);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool VerificarCredenciales(string nombreUsuario, string contraseña)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT COUNT(*) 
                                 FROM Administrador 
                                 WHERE NombreUsuario = @NombreUsuario 
                                 AND Contrasena = @Contrasena";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@Contrasena", contraseña);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public void EliminarAdministrador(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Administrador WHERE IdAdministrador = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
