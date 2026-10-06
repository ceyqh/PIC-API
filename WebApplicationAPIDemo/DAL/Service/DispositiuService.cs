using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using WebAplicationAPIRestDemo.DAL.Model;
using WebApplicationAPIRestDemo.Persistence;

namespace WebAplicationAPIRestDemo.DAL.Service
{
    public class DispositiuService
    {
        // TOTS ELS DISPOSITIUS
        public List<Dispositiu> GetAll()
        {
            var result = new List<Dispositiu>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = @"
                SELECT d.id, d.nom, d.idCategoria, d.estat, c.nom AS nomCategoria 
                FROM dispositius d
                INNER JOIN categories c ON d.idCategoria = c.id";

                using (var command = new MySqlCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Dispositiu
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nom = reader["nom"].ToString(),
                                IdCategoria = Convert.ToInt32(reader["idCategoria"]),
                                Categoria = reader["nomCategoria"].ToString(),
                                Estat = Convert.ToString(reader["estat"]),
                            });
                        }
                    }
                }
            }

            return result;
        }

        // DISPOSITIU PER ID
        public Dispositiu GetById(int Id)
        {
            Dispositiu dispositiu = null;

            using (var ctx = DbContext.GetInstance())
            {
                var query = @"
                    SELECT d.id, d.nom, d.idCategoria, d.estat, c.nom AS nomCategoria 
                    FROM dispositius d
                    INNER JOIN categories c ON d.idCategoria = c.id
                    WHERE d.id = @id";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@id", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            dispositiu = new Dispositiu()
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nom = reader["nom"].ToString(),
                                IdCategoria = Convert.ToInt32(reader["idCategoria"]),
                                Categoria = reader["nomCategoria"].ToString(),
                                Estat = Convert.ToString(reader["estat"]),
                            };
                        }
                    }
                }
            }

            return dispositiu;
        }

        // DISPOSITIUS PER CATEGORIA
        public List<Dispositiu> GetByIdCategoria(int Id)
        {
            var result = new List<Dispositiu>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = @"
                    SELECT d.id, d.nom, d.idCategoria, d.estat, c.nom AS nomCategoria 
                    FROM dispositius d
                    INNER JOIN categories c ON d.idCategoria = c.id
                    WHERE d.idCategoria = @idCategoria";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@idCategoria", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Dispositiu
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nom = reader["nom"].ToString(),
                                IdCategoria = Convert.ToInt32(reader["idCategoria"]),
                                Categoria = reader["nomCategoria"].ToString(),
                                Estat = Convert.ToString(reader["estat"]),
                            });
                        }
                    }
                }
            }

            return result;
        }

        // DISPOSITIUS DISPONIBLES
        public List<Dispositiu> GetAvailable()
        {
            var result = new List<Dispositiu>();

            using (var ctx = DbContext.GetInstance())
            {
                // Query amb JOIN per obtenir la descripció de la categoria
                var query = @"
                    SELECT d.id, d.nom, d.idCategoria, d.estat, c.nom AS nomCategoria 
                    FROM dispositius d
                    INNER JOIN categories c ON d.idCategoria = c.id
                    WHERE d.estat = 'Disponible'";

                using (var command = new MySqlCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Dispositiu
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nom = reader["nom"].ToString(),
                                IdCategoria = Convert.ToInt32(reader["idCategoria"]),
                                // Assignem el nom de la categoria
                                Categoria = reader["nomCategoria"].ToString(),
                                Estat = Convert.ToString(reader["estat"]),
                            });
                        }
                    }
                }
            }

            return result;
        }

        // DISPOSITIUS NO DISPONIBLES
        public List<Dispositiu> GetNotAvailable()
        {
            var result = new List<Dispositiu>();

            using (var ctx = DbContext.GetInstance())
            {
                // Query amb INNER JOIN i filtre per disponible = 0
                var query = @"
                    SELECT d.id, d.nom, d.idCategoria, d.estat, c.nom AS nomCategoria 
                    FROM dispositius d
                    INNER JOIN categories c ON d.idCategoria = c.id
                    WHERE d.estat = 'No disponible'";

                using (var command = new MySqlCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Dispositiu
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nom = reader["nom"].ToString(),
                                IdCategoria = Convert.ToInt32(reader["idCategoria"]),
                                // Assignem el nom de la categoria obtingut del JOIN
                                Categoria = reader["nomCategoria"].ToString(),
                                Estat = Convert.ToString(reader["estat"]),
                            });
                        }
                    }
                }
            }

            return result;
        }

        // DISPOSITIUS NO DISPONIBLES
        public List<Dispositiu> GetEnPrestec()
        {
            var result = new List<Dispositiu>();

            using (var ctx = DbContext.GetInstance())
            {
                // Query amb INNER JOIN i filtre per disponible = 0
                var query = @"
                    SELECT d.id, d.nom, d.idCategoria, d.estat, c.nom AS nomCategoria 
                    FROM dispositius d
                    INNER JOIN categories c ON d.idCategoria = c.id
                    WHERE d.estat = 'En prestec'";

                using (var command = new MySqlCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Dispositiu
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nom = reader["nom"].ToString(),
                                IdCategoria = Convert.ToInt32(reader["idCategoria"]),
                                // Assignem el nom de la categoria obtingut del JOIN
                                Categoria = reader["nomCategoria"].ToString(),
                                Estat = Convert.ToString(reader["estat"]),
                            });
                        }
                    }
                }
            }

            return result;
        }

        // CREAR DISPOSITIU
        public Dispositiu Add(Dispositiu dispositiu)
        {
            using (var ctx = DbContext.GetInstance())
            {
                string query = "INSERT INTO dispositius (nom, idCategoria, estat) VALUES (@nom, @idCategoria, @estat)";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@nom", dispositiu.Nom);
                    command.Parameters.AddWithValue("@idCategoria", dispositiu.IdCategoria);
                    command.Parameters.AddWithValue("@estat", dispositiu.Estat);

                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT LAST_INSERT_ID();";
                    dispositiu.Id = Convert.ToInt64(command.ExecuteScalar());
                }
            }
            return dispositiu;
        }

        // ACTUALITZAR DISPOSITIU
        public int Update(Dispositiu dispositius)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "UPDATE dispositius SET nom = @nom, idCategoria = @idCategoria, estat = @estat WHERE id = @id";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.Add(new MySqlParameter("@id", dispositius.Id));
                    command.Parameters.Add(new MySqlParameter("@nom", dispositius.Nom));
                    command.Parameters.Add(new MySqlParameter("@idCategoria", dispositius.IdCategoria));
                    command.Parameters.Add(new MySqlParameter("@estat", dispositius.Estat));

                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        // ESBORRAR DISPOSITIU
        public int Delete(int Id)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "DELETE FROM dispositius WHERE id = @id";

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
