using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using WebAplicationAPIRestDemo.DAL.Model;
using WebApplicationAPIRestDemo.Persistence;

namespace WebAplicationAPIRestDemo.DAL.Service
{
    public class AlumneService
    {
        // TOTS ELS ALUMNES
        public List<Alumne> GetAll()
        {
            var result = new List<Alumne>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM alumnes";

                using (var command = new MySqlCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Alumne
                            {
                                IdUsuari = Convert.ToInt32(reader["idUsuari"]),
                                IdCurs = Convert.ToInt32(reader["idCurs"]),
                            });
                        }
                    }
                }
            }

            return result;
        }

        // ALUMNE PER ID
        public Alumne GetById(int Id)
        {
            Alumne alumne = null;

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM alumnes WHERE idUsuari = @idUsuari";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@idUsuari", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            alumne = new Alumne()
                            {
                                IdUsuari = Convert.ToInt32(reader["idUsuari"]),
                                IdCurs = Convert.ToInt32(reader["idCurs"]),
                            };
                        }
                    }
                }
            }

            return alumne;
        }

        // AFEGIR ALUMNE
        public Alumne Add(Alumne alumne)
        {
            using (var ctx = DbContext.GetInstance())
            {
                string query = "INSERT INTO alumnes (idUsuari, idCurs) VALUES (@idUsuari, @idCurs)";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@idUsuari", alumne.IdUsuari);
                    command.Parameters.AddWithValue("@idCurs", alumne.IdCurs);

                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT LAST_INSERT_ID();";

                    alumne.IdUsuari = Convert.ToInt32(command.ExecuteScalar());
                    alumne.IdCurs = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return alumne;
        }

        // ACTUALITZAR ALUMNE
        public int Update(Alumne alumne)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "UPDATE alumnes SET IdCurs = @IdCurs WHERE IdUsuari = @IdUsuari";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.Add(new MySqlParameter("@IdUsuari", alumne.IdUsuari));
                    command.Parameters.Add(new MySqlParameter("@IdCurs", alumne.IdCurs));

                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        // ESBORRAR ALUMNE
        public int Delete(int IdUsuari)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "DELETE FROM alumnes WHERE idUsuari = @idUsuari";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.Add(new MySqlParameter("@idUsuari", IdUsuari));
                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }
    }
}
