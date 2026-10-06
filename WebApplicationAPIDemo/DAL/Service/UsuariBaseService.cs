using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using WebAplicationAPIRestDemo.DAL.Model;
using WebApplicationAPIRestDemo.Persistence;

namespace WebAplicationAPIRestDemo.DAL.Service
{
    public class UsuariBaseService
    {
        // TOTS ELS USUARIS BASE
        public List<UsuariBase> GetAll()
        {
            var result = new List<UsuariBase>();

            using (var ctx = DbContext.GetInstance())
            {
                // Utilitzem un INNER JOIN per portar el nom de la taula categories
                var query = "SELECT * FROM usuaris";

                using (var command = new MySqlCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new UsuariBase
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nom = reader["nom"].ToString(),
                                Cognom = reader["cognom"].ToString()
                            });
                        }
                    }
                }
            }

            return result;
        }

        // ESBORRAR USUARI BASE
        public int Delete(int Id)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "DELETE FROM usuaris WHERE id= @id";

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
