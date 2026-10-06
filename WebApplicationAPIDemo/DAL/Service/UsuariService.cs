using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using WebAplicationAPIRestDemo.DAL.Model;
using WebApplicationAPIRestDemo.Persistence;

namespace WebAplicationAPIRestDemo.DAL.Service
{
    public class UsuariService
    {
        // TOTS ELS USUARIS
        public List<Usuari> GetAll()
        {
            var result = new List<Usuari>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = @"
                            SELECT 
                            u.id,
                            u.nom,
                            u.cognom,
                            CASE 
                            WHEN a.idCurs IS NOT NULL THEN 'Alumne'
                            WHEN p.idDepartament IS NOT NULL THEN 'Professor'
                            END AS tipus,
                            COALESCE(c.nom, d.nom) AS grup,
                            COALESCE(a.idCurs, p.idDepartament) AS idGrup
                            FROM usuaris u
                            LEFT JOIN alumnes a ON a.idUsuari = u.id
                            LEFT JOIN cursos c ON c.id = a.idCurs
                            LEFT JOIN professors p ON p.idUsuari = u.id
                            LEFT JOIN departaments d ON d.id = p.idDepartament";

                using (var command = new MySqlCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var usuari = new Usuari
                            {
                                Id = Convert.ToInt64(reader["id"]),
                                Nom = reader["nom"]?.ToString(),
                                Cognom = reader["cognom"]?.ToString(),
                                Tipus = reader["tipus"] == DBNull.Value ? null : reader["tipus"].ToString(),
                                Grup = reader["grup"] == DBNull.Value ? null : reader["grup"].ToString(),
                                IdGrup = reader["idGrup"] == DBNull.Value ? (long?)null : Convert.ToInt64(reader["idGrup"])
                            };

                            result.Add(usuari);
                        }
                    }
                }
            }

            return result;
        }

        // USUARI PER ID
        public Usuari GetById(int Id)
        {
            Usuari usuari = null;

            using (var ctx = DbContext.GetInstance())
            {
                var query = @"
                            SELECT 
                            u.id,
                            u.nom,
                            u.cognom,
                            CASE 
                            WHEN a.idCurs IS NOT NULL THEN 'Alumne'
                            WHEN p.idDepartament IS NOT NULL THEN 'Professor'
                            END AS tipus,
                            COALESCE(c.nom, d.nom) AS grup,
                            COALESCE(a.idCurs, p.idDepartament) AS idGrup
                            FROM usuaris u
                            LEFT JOIN alumnes a ON a.idUsuari = u.id
                            LEFT JOIN cursos c ON c.id = a.idCurs
                            LEFT JOIN professors p ON p.idUsuari = u.id
                            LEFT JOIN departaments d ON d.id = p.idDepartament
                            WHERE u.id = @id";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@id", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuari = new Usuari
                            {
                                Id = Convert.ToInt64(reader["id"]),
                                Nom = reader["nom"]?.ToString(),
                                Cognom = reader["cognom"]?.ToString(),
                                Tipus = reader["tipus"] == DBNull.Value ? null : reader["tipus"].ToString(),
                                Grup = reader["grup"] == DBNull.Value ? null : reader["grup"].ToString(),
                                IdGrup = reader["idGrup"] == DBNull.Value ? (long?)null : Convert.ToInt64(reader["idGrup"])
                            };
                        }
                    }
                }
            }

            return usuari;
        }

        // USUARI PER CURS
        public List<Usuari> GetByIdCurs(int Id)
        {
            var result = new List<Usuari>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = @"
                            SELECT 
                            u.id,
                            u.nom,
                            u.cognom,
                            'Alumne' AS tipus,
                            c.nom AS grup,
                            a.idCurs AS idGrup
                            FROM usuaris u
                            JOIN alumnes a ON a.idUsuari = u.id
                            JOIN cursos c ON c.id = a.idCurs
                            WHERE a.idCurs = @idCurs";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@idCurs", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Usuari
                            {
                                Id = Convert.ToInt64(reader["id"]),
                                Nom = reader["nom"]?.ToString(),
                                Cognom = reader["cognom"]?.ToString(),
                                Tipus = reader["tipus"] == DBNull.Value ? null : reader["tipus"].ToString(),
                                Grup = reader["grup"] == DBNull.Value ? null : reader["grup"].ToString(),
                                IdGrup = reader["idGrup"] == DBNull.Value ? (long?)null : Convert.ToInt64(reader["idGrup"])
                            });
                        }
                    }
                }
            }

            return result;
        }

        // USUARI PER DEPARTAMENT
        public List<Usuari> GetByIdDepartament(int Id)
        {
            var result = new List<Usuari>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = @"
                            SELECT 
                            u.id,
                            u.nom,
                            u.cognom,
                            'Departament' AS tipus,
                            c.nom AS grup,
                            a.idDepartament AS idGrup
                            FROM usuaris u
                            JOIN professors a ON a.idUsuari = u.id
                            JOIN departaments c ON c.id = a.idDepartament
                            WHERE a.idDepartament = @idDepartament";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@idDepartament", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Usuari
                            {
                                Id = Convert.ToInt64(reader["id"]),
                                Nom = reader["nom"]?.ToString(),
                                Cognom = reader["cognom"]?.ToString(),
                                Tipus = reader["tipus"] == DBNull.Value ? null : reader["tipus"].ToString(),
                                Grup = reader["grup"] == DBNull.Value ? null : reader["grup"].ToString(),
                                IdGrup = reader["idGrup"] == DBNull.Value ? (long?)null : Convert.ToInt64(reader["idGrup"])
                            });
                        }
                    }
                }
            }

            return result;
        }

        // CREAR USUARI
        public Usuari Add(Usuari usuari)
        {
            using (var ctx = DbContext.GetInstance())
            {
                string query = "INSERT INTO usuaris (nom, cognom) VALUES (@nom, @cognom)";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@nom", usuari.Nom);
                    command.Parameters.AddWithValue("@cognom", usuari.Cognom);

                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT LAST_INSERT_ID();";

                    usuari.Id = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return usuari;
        }

        // ACTUALITZAR USUARI
        public int Update(Usuari usuari)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "UPDATE usuaris SET nom = @nom, cognom = @cognom WHERE id = @id";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.Add(new MySqlParameter("@id", usuari.Id));
                    command.Parameters.Add(new MySqlParameter("@nom", usuari.Nom));
                    command.Parameters.Add(new MySqlParameter("@cognom", usuari.Cognom));

                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        // ESBORRAR USUARI
        public int Delete(int Id)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "DELETE FROM usuaris WHERE id = @id";

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
