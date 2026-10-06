using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using WebAplicationAPIRestDemo.DAL.Model;
using WebApplicationAPIRestDemo.Persistence;

namespace WebAplicationAPIRestDemo.DAL.Service
{
    public class CursService
    {
        // TOTES ELS CURSOS
        public List<Curs> GetAll()
        {
            var result = new List<Curs>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM cursos";

                using (var command = new MySqlCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Curs
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nom = reader["nom"].ToString(),
                            });
                        }
                    }
                }
            }

            return result;
        }

        // CURS PER ID
        public Curs GetById(int Id)
        {
            Curs curs = null;

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM cursos WHERE id = @id";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@id", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            curs = new Curs()
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nom = reader["nom"].ToString(),
                            };
                        }
                    }
                }
            }

            return curs;
        }

        // CREAR CURS
        public Curs Add(Curs curs)
        {
            using (var ctx = DbContext.GetInstance())
            {
                string query = "INSERT INTO cursos (nom) VALUES (@nom)";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@nom", curs.Nom);

                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT LAST_INSERT_ID();";

                    curs.Id = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return curs;
        }

        // ACTUALITZAR CURS
        public int Update(Curs curs)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "UPDATE cursos SET nom = @nom WHERE id = @id";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.Add(new MySqlParameter("@id", curs.Id));
                    command.Parameters.Add(new MySqlParameter("@nom", curs.Nom));

                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        // ESBORRAR CURS
        public int Delete(int Id)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "DELETE FROM cursos WHERE id = @id";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.Add(new MySqlParameter("@id", Id));
                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }
    }
}
