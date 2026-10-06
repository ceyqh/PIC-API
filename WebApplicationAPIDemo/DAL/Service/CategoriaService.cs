using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using WebAplicationAPIRestDemo.DAL.Model;
using WebApplicationAPIRestDemo.Persistence;

namespace WebAplicationAPIRestDemo.DAL.Service
{
    public class CategoriaService
    {
        // TOTES LES CATEGORIES
        public List<Categoria> GetAll()
        {
            var result = new List<Categoria>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM categories";

                using (var command = new MySqlCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Categoria
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

        // CATEGORIA PER ID
        public Categoria GetById(int Id)
        {
            Categoria categoria = null;

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM categories WHERE id = @id";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@id", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            categoria = new Categoria()
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nom = reader["nom"].ToString(),
                            };
                        }
                    }
                }
            }

            return categoria;
        }

        // CREAR CATEGORIA
        public Categoria Add(Categoria categoria)
        {
            using (var ctx = DbContext.GetInstance())
            {
                string query = "INSERT INTO categories (nom) VALUES (@nom)";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@nom", categoria.Nom);

                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT LAST_INSERT_ID();";

                    categoria.Id = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return categoria;
        }

        // ACTUALITZAR CATEGORIA
        public int Update(Categoria categoria)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "UPDATE categories SET nom = @nom WHERE id = @id";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.Add(new MySqlParameter("@id", categoria.Id));
                    command.Parameters.Add(new MySqlParameter("@nom", categoria.Nom));

                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        // ESBORRAR CATEGORIA
        public int Delete(int Id)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "DELETE FROM categories WHERE id = @id";

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
