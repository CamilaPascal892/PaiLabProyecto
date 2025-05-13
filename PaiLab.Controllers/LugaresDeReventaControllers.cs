using PaiLab.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PaiLab.Controllers
{
    public class LugaresDeReventaControllers
    {
        private string connectionString;

        public LugaresDeReventaControllers()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        }

        public List<LugaresDeReventa> ObtenerTodos()
        {
            List<LugaresDeReventa> lista = new List<LugaresDeReventa>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM LugaresDeReventa";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LugaresDeReventa lugar = new LugaresDeReventa
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Ubicacion = reader["Ubicacion"].ToString(),
                        TipoMasVendido = reader["TipoMasVendido"].ToString(),
                        Descripcion = reader["Descripcion"].ToString()
                    };
                    lista.Add(lugar);
                }
            }

            return lista;
        }

        public void Agregar(LugaresDeReventa lugar)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO LugaresDeReventa (Nombre, Ubicacion, TipoMasVendido, Descripcion) VALUES (@Nombre, @Ubicacion, @TipoMasVendido, @Descripcion)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", lugar.Nombre);
                cmd.Parameters.AddWithValue("@Ubicacion", lugar.Ubicacion);
                cmd.Parameters.AddWithValue("@TipoMasVendido", lugar.TipoMasVendido);
                cmd.Parameters.AddWithValue("@Descripcion", lugar.Descripcion);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(LugaresDeReventa lugar)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE LugaresDeReventa SET Nombre=@Nombre, Ubicacion=@Ubicacion, TipoMasVendido=@TipoMasVendido, Descripcion=@Descripcion WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", lugar.Nombre);
                cmd.Parameters.AddWithValue("@Ubicacion", lugar.Ubicacion);
                cmd.Parameters.AddWithValue("@TipoMasVendido", lugar.TipoMasVendido);
                cmd.Parameters.AddWithValue("@Descripcion", lugar.Descripcion);
                cmd.Parameters.AddWithValue("@Id", lugar.Id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM LugaresDeReventa WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}