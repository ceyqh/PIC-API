using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using WebAplicationAPIRestDemo.DAL.Model;
using WebApplicationAPIRestDemo.Persistence;

namespace WebAplicationAPIRestDemo.DAL.Service
{
    public class DepartamentService
    {
        // TOTES ELS DEPARTAMENTS
        public List<Departament> GetAll()
        {
            var result = new List<Departament>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM departaments";

                using (var command = new MySqlCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Departament
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

        // DEPARTAMENTS PER ID
        public Departament GetById(int Id)
        {
            Departament curs = null;

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM departaments WHERE id = @id";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@id", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            curs = new Departament()
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

        // CREAR DEPARTAMENT
        public Departament Add(Departament departament)
        {
            using (var ctx = DbContext.GetInstance())
            {
                string query = "INSERT INTO departaments (nom) VALUES (@nom)";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@nom", departament.Nom);

                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT LAST_INSERT_ID();";

                    departament.Id = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return departament;
        }

        // ACTUALITZAR DEPARTAMENT
        public int Update(Departament departament)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "UPDATE departaments SET nom = @nom WHERE id = @id";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.Add(new MySqlParameter("@id", departament.Id));
                    command.Parameters.Add(new MySqlParameter("@nom", departament.Nom));

                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        // ESBORRAR DEPARTAMENT
        public int Delete(int Id)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "DELETE FROM departaments WHERE id = @id";

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
