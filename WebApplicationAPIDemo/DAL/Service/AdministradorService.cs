using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using WebAplicationAPIRestDemo.DAL.Model;
using WebApplicationAPIRestDemo.Persistence;

namespace WebAplicationAPIRestDemo.DAL.Service
{
    public class AdministradorService
    {
        // TOTS ELS ADMINISTRADORS
        public List<Administrador> GetAll()
        {
            var result = new List<Administrador>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM administradors";

                using (var command = new MySqlCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Administrador
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nom = Convert.ToString(reader["nom"]),
                                Contrasenya = Convert.ToString(reader["contrasenya"]),
                                Permisos = Convert.ToString(reader["permisos"]),
                            });
                        }
                    }
                }
            }
            return result;
        }

        // AFEGIR ADMINISTRADORS
        public Administrador Add(Administrador administrador)
        {
            using (var ctx = DbContext.GetInstance())
            {
                string query = "INSERT INTO administradors (nom, contrasenya, permisos) VALUES (@nom, @contrasenya, @permisos)";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@nom", administrador.Nom);
                    command.Parameters.AddWithValue("@contrasenya", administrador.Contrasenya);
                    command.Parameters.AddWithValue("@permisos", administrador.Permisos);

                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT LAST_INSERT_ID();";

                    administrador.Id = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return administrador;
        }

        // ACTUALITZAR ADMINISTRADOR
        public int Update(Administrador administrador)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "UPDATE administradors SET nom = @nom, permisos = @permisos WHERE id = @id";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.Add(new MySqlParameter("@id", administrador.Id));
                    command.Parameters.Add(new MySqlParameter("@nom", administrador.Nom));
                    command.Parameters.Add(new MySqlParameter("@permisos", administrador.Permisos));

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        // ESBORRAR ADMINISTRADOR
        public int Delete(int Id)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "DELETE FROM administradors WHERE id= @id";

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
