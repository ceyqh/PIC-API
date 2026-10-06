using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using WebAplicationAPIRestDemo.DAL.Model;
using WebApplicationAPIRestDemo.Persistence;

namespace WebAplicationAPIRestDemo.DAL.Service
{
    public class ProfessorService
    {
        // TOTS ELS PROFESSORS
        public List<Professor> GetAll()
        {
            var result = new List<Professor>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM professors";

                using (var command = new MySqlCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Professor
                            {
                                IdUsuari = Convert.ToInt32(reader["idUsuari"]),
                                IdDepartament = Convert.ToInt32(reader["idDepartament"]),
                            });
                        }
                    }
                }
            }

            return result;
        }

        // PROFESSOR PER ID
        public Professor GetById(int Id)
        {
            Professor professor = null;

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM professors WHERE idUsuari = @idUsuari";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@idUsuari", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            professor = new Professor()
                            {
                                IdUsuari = Convert.ToInt32(reader["idUsuari"]),
                                IdDepartament = Convert.ToInt32(reader["idDepartament"]),
                            };
                        }
                    }
                }
            }

            return professor;
        }

        // AFEGIR PROFESSOR
        public Professor Add(Professor professor)
        {
            using (var ctx = DbContext.GetInstance())
            {
                string query = "INSERT INTO professors (idUsuari, idDepartament) VALUES (@idUsuari, @idDepartament)";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@idUsuari", professor.IdUsuari);
                    command.Parameters.AddWithValue("@idDepartament", professor.IdDepartament);

                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT LAST_INSERT_ID();";

                    professor.IdUsuari = Convert.ToInt32(command.ExecuteScalar());
                    professor.IdDepartament = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return professor;
        }

        // ACTUALITZAR PROFESSOR
        public int Update(Professor professor)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "UPDATE professors SET IdDepartament = @IdDepartament WHERE IdUsuari = @IdUsuari";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.Add(new MySqlParameter("@IdUsuari", professor.IdUsuari));
                    command.Parameters.Add(new MySqlParameter("@IdDepartament", professor.IdDepartament));

                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        // ESBORRAR PROFESSOR
        public int Delete(int IdUsuari)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "DELETE FROM professors WHERE idUsuari = @idUsuari";

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
