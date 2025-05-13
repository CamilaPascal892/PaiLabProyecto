using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using PaiLab.Model;

namespace PaiLab.Controllers
{
    public class RevendedoresControllers
    {
        private string connectionString;

        public RevendedoresControllers()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        }

        public bool AgregarRevendedores(Revendedores nuevoRevendedor)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Revendedores (Nombre, Especialidad, VentasRealizadas, Nivel, Experiencia) " +
                                   "VALUES (@Nombre, @Especialidad, @VentasRealizadas, @Nivel, @Experiencia)";
                    SqlCommand comando = new SqlCommand(query, conexion);

                    comando.Parameters.AddWithValue("@Nombre", nuevoRevendedor.Nombre);
                    comando.Parameters.AddWithValue("@Especialidad", nuevoRevendedor.Especialidad);
                    comando.Parameters.AddWithValue("@VentasRealizadas", nuevoRevendedor.VentasRealizadas);
                    comando.Parameters.AddWithValue("@Nivel", nuevoRevendedor.Nivel);
                    comando.Parameters.AddWithValue("@Experiencia", nuevoRevendedor.Experiencia);

                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    resultado = filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el revendedor: " + ex.Message);
            }

            return resultado;
        }

        public bool ModificarRevendedor(Revendedores revendedor)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Revendedores SET Nombre = @Nombre, Especialidad = @Especialidad, " +
                                   "VentasRealizadas = @VentasRealizadas, Nivel = @Nivel, Experiencia = @Experiencia WHERE Id = @Id";
                    SqlCommand comando = new SqlCommand(query, conexion);

                    comando.Parameters.AddWithValue("@Nombre", revendedor.Nombre);
                    comando.Parameters.AddWithValue("@Especialidad", revendedor.Especialidad);
                    comando.Parameters.AddWithValue("@VentasRealizadas", revendedor.VentasRealizadas);
                    comando.Parameters.AddWithValue("@Nivel", revendedor.Nivel);
                    comando.Parameters.AddWithValue("@Experiencia", revendedor.Experiencia);
                    comando.Parameters.AddWithValue("@Id", revendedor.Id);

                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    resultado = filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el revendedor: " + ex.Message);
            }

            return resultado;
        }

        public List<Revendedores> ListarRevendedores()
        {
            List<Revendedores> lista = new List<Revendedores>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Revendedores";
                    SqlCommand comando = new SqlCommand(query, conexion);

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Revendedores revendedor = new Revendedores
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Especialidad = reader["Especialidad"].ToString(),
                            VentasRealizadas = Convert.ToInt32(reader["VentasRealizadas"]),
                            Nivel = Convert.ToInt32(reader["Nivel"]),
                            Experiencia = Convert.ToInt32(reader["Experiencia"])
                        };

                        lista.Add(revendedor);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los revendedores: " + ex.Message);
            }

            return lista;
        }

        public List<Revendedores> BuscarPorEspecialidad(string especialidad)
        {
            List<Revendedores> lista = new List<Revendedores>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Revendedores WHERE Especialidad LIKE @Especialidad";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@Especialidad", "%" + especialidad + "%");

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Revendedores revendedor = new Revendedores
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Especialidad = reader["Especialidad"].ToString(),
                            VentasRealizadas = Convert.ToInt32(reader["VentasRealizadas"]),
                            Nivel = Convert.ToInt32(reader["Nivel"]),
                            Experiencia = Convert.ToInt32(reader["Experiencia"])
                        };

                        lista.Add(revendedor);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar revendedores por especialidad: " + ex.Message);
            }

            return lista;
        }

        public List<Revendedores> BuscarPorVentasRealizadas(int minVentasRealizadas)
        {
            List<Revendedores> lista = new List<Revendedores>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Revendedores WHERE VentasRealizadas >= @MinVentasRealizadas";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@MinVentasRealizadas", minVentasRealizadas);

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Revendedores revendedor = new Revendedores
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Especialidad = reader["Especialidad"].ToString(),
                            VentasRealizadas = Convert.ToInt32(reader["VentasRealizadas"]),
                            Nivel = Convert.ToInt32(reader["Nivel"]),
                            Experiencia = Convert.ToInt32(reader["Experiencia"])
                        };

                        lista.Add(revendedor);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar revendedores por ventas realizadas: " + ex.Message);
            }

            return lista;
        }

        // NUEVO: Obtener revendedores por nivel
        public List<Revendedores> ObtenerRevendedoresPorNivel(int numeroNivel)
        {
            List<Revendedores> lista = new List<Revendedores>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Revendedores WHERE Nivel = @Nivel";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@Nivel", numeroNivel);

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Revendedores revendedor = new Revendedores
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Especialidad = reader["Especialidad"].ToString(),
                            VentasRealizadas = Convert.ToInt32(reader["VentasRealizadas"]),
                            Nivel = Convert.ToInt32(reader["Nivel"]),
                            Experiencia = Convert.ToInt32(reader["Experiencia"])
                        };

                        lista.Add(revendedor);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener revendedores por nivel: " + ex.Message);
            }

            return lista;
        }
    }
}
