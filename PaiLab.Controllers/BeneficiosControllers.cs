using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.Data.SqlClient;
using PaiLab.Model;

namespace PaiLab.Controllers
{
    public class BeneficiosController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        private static List<Beneficios> beneficios = new List<Beneficios>();
        private static int proximoId = 1;

        public List<Beneficios> ObtenerTodos()
        {
            List<Beneficios> beneficios = new List<Beneficios>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT b.Id, b.Nombre, b.RevendedoresId, b.TipoBeneficioId, b.LugaresDeReventaId, tb.Id AS TipoBeneficioId, tb.Nombre AS TipoBeneficioNombre FROM Beneficios b JOIN TipoBeneficio tb ON b.TipoBeneficioId = tb.Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Beneficios beneficio = new Beneficios
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                    LugaresDeReventaId = reader.IsDBNull(reader.GetOrdinal("LugaresDeReventaId"))
                                                        ? 0
                                                        : reader.GetInt32(reader.GetOrdinal("LugaresDeReventaId")),
                                    TipoBeneficioId = reader.GetInt32(reader.GetOrdinal("TipoBeneficioId")),
                                    RevendedoresId = reader.IsDBNull(reader.GetOrdinal("RevendedoresId"))
                                                        ? 0
                                                        : reader.GetInt32(reader.GetOrdinal("RevendedoresId"))
                                };
                                beneficios.Add(beneficio);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
                // Aquí puedes también registrar el error en algún log si es necesario.
            }

            return beneficios;
        }

        public void Agregar(Beneficios beneficio)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Beneficios (Nombre, RevendedoresId, TipoBeneficioId, LugaresDeReventaId) VALUES (@Nombre, @RevendedoresId, @TipoBeneficioId, @LugaresDeReventaId)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", beneficio.Nombre ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@RevendedoresId", beneficio.RevendedoresId ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoBeneficioId", beneficio.TipoBeneficioId);
                cmd.Parameters.AddWithValue("@LugaresDeReventaId", beneficio.LugaresDeReventaId ?? (object)DBNull.Value);


                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public bool ModificarBeneficio(Beneficios beneficio)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Beneficios SET [Nombre] = @Nombre, RevendedoresId = @RevendedoresId, TipoBeneficioId = @TipoBeneficioId, LugaresDeReventaId = @LugaresDeReventaId WHERE Id = @Id";
                    SqlCommand comando = new SqlCommand(query, conexion);

                    comando.Parameters.AddWithValue("@Nombre", string.IsNullOrEmpty(beneficio.Nombre) ? DBNull.Value : (object)beneficio.Nombre);
                    comando.Parameters.AddWithValue("@RevendedoresId", beneficio.RevendedoresId.HasValue ? (object)beneficio.RevendedoresId.Value : DBNull.Value);
                    comando.Parameters.AddWithValue("@TipoBeneficioId", beneficio.TipoBeneficioId);
                    comando.Parameters.AddWithValue("@LugaresDeReventaId", beneficio.LugaresDeReventaId > 0 ? (object)beneficio.LugaresDeReventaId : DBNull.Value);
                    comando.Parameters.AddWithValue("@Id", beneficio.Id);

                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    resultado = filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el beneficio: " + ex.Message);
            }

            return resultado;
        }

        public void Eliminar(Beneficios beneficio)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string eliminarRelaciones = "DELETE FROM BeneficiosLugaresDeReventa WHERE BeneficioId = @Id";

                using (SqlCommand cmdRelaciones = new SqlCommand(eliminarRelaciones, conn))
                {
                    cmdRelaciones.Parameters.AddWithValue("@Id", beneficio.Id);
                    cmdRelaciones.ExecuteNonQuery();
                }

                string desasociarQuery = "UPDATE Beneficios SET RevendedoresId = NULL, LugaresDeReventaId = NULL WHERE Id = @Id";

                using (SqlCommand cmdDesasociar = new SqlCommand(desasociarQuery, conn))
                {
                    cmdDesasociar.Parameters.AddWithValue("@Id", beneficio.Id);
                    cmdDesasociar.ExecuteNonQuery();
                }

                string eliminarQuery = "DELETE FROM Beneficios WHERE Id = @Id";

                using (SqlCommand cmdEliminar = new SqlCommand(eliminarQuery, conn))
                {
                    cmdEliminar.Parameters.AddWithValue("@Id", beneficio.Id);
                    cmdEliminar.ExecuteNonQuery();
                }
            }
        }

        public List<TipoBeneficio> ListarTipoBenefecios()
        {
            List<TipoBeneficio> lista = new List<TipoBeneficio>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id FROM TipoBeneficio";
                    SqlCommand comando = new SqlCommand(query, conexion);

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        TipoBeneficio tipoBeneficio = new TipoBeneficio
                        {
                            Id = Convert.ToInt32(reader["Id"])
                        };

                        lista.Add(tipoBeneficio);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los tipoBeneficios: " + ex.Message);
            }

            return lista;
        }

        public List<Revendedores> ListarRevendedores()
        {
            List<Revendedores> lista = new List<Revendedores>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id FROM Revendedores";
                    SqlCommand comando = new SqlCommand(query, conexion);

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Revendedores revendedor = new Revendedores
                        {
                            Id = Convert.ToInt32(reader["Id"])
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

        public List<LugaresDeReventa> ListarLugaresDeReventa()
        {
            List<LugaresDeReventa> lista = new List<LugaresDeReventa>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id FROM LugaresDeReventa";
                    SqlCommand comando = new SqlCommand(query, conexion);

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        LugaresDeReventa lugar = new LugaresDeReventa
                        {
                            Id = Convert.ToInt32(reader["Id"])
                        };

                        lista.Add(lugar);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los lugares de reventa: " + ex.Message);
            }

            return lista;
        }
    }
}
