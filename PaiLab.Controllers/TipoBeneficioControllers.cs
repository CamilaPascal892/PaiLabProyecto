using PaiLab.Model;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace PaiLab.Controllers
{
    public class TipoBeneficioControllers
    {
        private string connectionString;

        public TipoBeneficioControllers()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        }

        public List<TipoBeneficio> ObtenerTodos()
        {
            List<TipoBeneficio> lista = new List<TipoBeneficio>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nombre FROM TipoBeneficio";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new TipoBeneficio
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString()
                    });
                }
            }

            return lista;
        }
    }
}

