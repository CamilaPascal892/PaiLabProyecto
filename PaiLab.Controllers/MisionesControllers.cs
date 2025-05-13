using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using PaiLab.Model;

namespace PaiLab.Controller
{
    public class MisionesControllers
    {
        private readonly string connectionString;

        public MisionesControllers(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Obtener todas las misiones con sus lugares asociados
        public List<Misiones> ObtenerTodas()
        {
            List<Misiones> lista = new List<Misiones>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. Obtener misiones
                string queryMisiones = "SELECT * FROM Misiones";
                using (SqlCommand cmd = new SqlCommand(queryMisiones, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Misiones
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                            Dificultad = reader.GetString(reader.GetOrdinal("Dificultad")),
                            LugaresDeReventaId = new List<int>() // se llena después
                        });
                    }
                }

                // 2. Obtener lugares asociados por misión
                string queryLugares = "SELECT MisionId, LugarDeReventaId FROM MisionesLugaresDeReventa";
                using (SqlCommand cmd = new SqlCommand(queryLugares, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int misionId = reader.GetInt32(0);
                        int lugarId = reader.GetInt32(1);

                        var mision = lista.Find(m => m.Id == misionId);
                        if (mision != null)
                        {
                            mision.LugaresDeReventaId.Add(lugarId);
                        }
                    }
                }
            }

            return lista;
        }

        // Agregar una nueva misión
        public void Agregar(Misiones mision)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. Insertar misión
                string insertMision = @"INSERT INTO Misiones (Nombre, Descripcion, Dificultad) 
                                        OUTPUT INSERTED.Id
                                        VALUES (@Nombre, @Descripcion, @Dificultad)";

                using (SqlCommand cmd = new SqlCommand(insertMision, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", mision.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", mision.Descripcion);
                    cmd.Parameters.AddWithValue("@Dificultad", mision.Dificultad);

                    mision.Id = (int)cmd.ExecuteScalar();
                }

                // 2. Insertar relaciones en MisionesLugaresDeReventa
                foreach (int lugarId in mision.LugaresDeReventaId)
                {
                    string insertRelacion = @"INSERT INTO MisionesLugaresDeReventa (MisionId, LugarDeReventaId) 
                                              VALUES (@MisionId, @LugarId)";
                    using (SqlCommand cmd = new SqlCommand(insertRelacion, conn))
                    {
                        cmd.Parameters.AddWithValue("@MisionId", mision.Id);
                        cmd.Parameters.AddWithValue("@LugarId", lugarId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Actualizar misión
        public void Actualizar(Misiones mision)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. Actualizar datos principales
                string update = @"UPDATE Misiones 
                                  SET Nombre = @Nombre, Descripcion = @Descripcion, Dificultad = @Dificultad, 
                                  WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(update, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", mision.Id);
                    cmd.Parameters.AddWithValue("@Nombre", mision.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", mision.Descripcion);
                    cmd.Parameters.AddWithValue("@Dificultad", mision.Dificultad);
                    cmd.ExecuteNonQuery();
                }

                // 2. Eliminar relaciones actuales
                string deleteRelaciones = "DELETE FROM MisionesLugaresDeReventa WHERE MisionId = @MisionId";
                using (SqlCommand cmd = new SqlCommand(deleteRelaciones, conn))
                {
                    cmd.Parameters.AddWithValue("@MisionId", mision.Id);
                    cmd.ExecuteNonQuery();
                }

                // 3. Insertar relaciones actualizadas
                foreach (int lugarId in mision.LugaresDeReventaId)
                {
                    string insertRelacion = @"INSERT INTO MisionesLugaresDeReventa (MisionId, LugarDeReventaId)
                                              VALUES (@MisionId, @LugarId)";
                    using (SqlCommand cmd = new SqlCommand(insertRelacion, conn))
                    {
                        cmd.Parameters.AddWithValue("@MisionId", mision.Id);
                        cmd.Parameters.AddWithValue("@LugarId", lugarId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Eliminar misión y sus relaciones
        public void Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. Eliminar relaciones
                string deleteRelaciones = "DELETE FROM MisionesLugaresDeReventa WHERE MisionId = @Id";
                using (SqlCommand cmd = new SqlCommand(deleteRelaciones, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }

                // 2. Eliminar misión
                string deleteMision = "DELETE FROM Misiones WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(deleteMision, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

