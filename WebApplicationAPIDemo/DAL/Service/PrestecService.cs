using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using WebAplicationAPIRestDemo.DAL.Model;
using WebApplicationAPIRestDemo.Persistence;

namespace WebAplicationAPIRestDemo.DAL.Service
{
    public class PrestecService
    {
        // TOTS ELS PRESTECS
        public List<Prestec> GetAll()
        {
            var result = new List<Prestec>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = @"
                SELECT 
                    p.id AS PrestecId,
                    p.idUsuari,
                    p.idDispositiu,
                    p.dataEntrega,
                    p.dataRetorn,
                    u.nom AS NomUsuari,
                    u.cognom AS CognomUsuari,
                    d.nom AS NomDispositiu
                FROM prestecs p
                JOIN usuaris u ON u.id = p.idUsuari
                JOIN dispositius d ON d.id = p.idDispositiu";

                using (var command = new MySqlCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Prestec
                            {
                                Id = Convert.ToInt32(reader["PrestecId"]),
                                IdUsuari = Convert.ToInt32(reader["idUsuari"]),
                                IdDispositiu = Convert.ToInt32(reader["idDispositiu"]),
                                DataEntrega = Convert.ToDateTime(reader["dataEntrega"]),
                                DataRetorn = Convert.ToDateTime(reader["dataRetorn"]),
                                NomUsuari = reader["NomUsuari"].ToString() + " " + reader["CognomUsuari"].ToString(),
                                NomDispositiu = reader["NomDispositiu"].ToString()
                            });
                        }
                    }
                }
            }

            return result;
        }

        // PRESTECINFO PER ID
        public Prestec GetById(int Id)
        {
            Prestec prestec = null;

            using (var ctx = DbContext.GetInstance())
            {
                var query = @"
            SELECT 
                p.id AS PrestecId,
                p.idUsuari,
                p.idDispositiu,
                p.dataEntrega,
                p.dataRetorn,
                u.nom,
                u.cognom,
                d.nom AS NomDispositiu
            FROM prestecs p
            JOIN usuaris u ON u.id = p.idUsuari
            JOIN dispositius d ON d.id = p.idDispositiu
            WHERE p.id = @id";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@id", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            prestec = new Prestec
                            {
                                Id = Convert.ToInt32(reader["PrestecId"]),
                                IdUsuari = Convert.ToInt32(reader["idUsuari"]),
                                IdDispositiu = Convert.ToInt32(reader["idDispositiu"]),
                                DataEntrega = Convert.ToDateTime(reader["dataEntrega"]),
                                DataRetorn = Convert.ToDateTime(reader["dataRetorn"]),
                                NomUsuari = reader["nom"] + " " + reader["cognom"],
                                NomDispositiu = reader["NomDispositiu"].ToString()
                            };
                        }
                    }
                }
            }

            return prestec;
        }

        // PRESTECSINFO PER ID DISPOSITIU
        public List<Prestec> GetByIdDispositiu(int Id)
        {
            var result = new List<Prestec>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = @"
            SELECT 
                p.id AS PrestecId,
                p.idUsuari,
                p.idDispositiu,
                p.dataEntrega,
                p.dataRetorn,
                u.nom,
                u.cognom,
                d.nom AS NomDispositiu
            FROM prestecs p
            JOIN usuaris u ON u.id = p.idUsuari
            JOIN dispositius d ON d.id = p.idDispositiu
            WHERE p.idDispositiu = @idDispositiu";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@idDispositiu", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Prestec
                            {
                                Id = Convert.ToInt32(reader["PrestecId"]),
                                IdUsuari = Convert.ToInt32(reader["idUsuari"]),
                                IdDispositiu = Convert.ToInt32(reader["idDispositiu"]),
                                DataEntrega = Convert.ToDateTime(reader["dataEntrega"]),
                                DataRetorn = Convert.ToDateTime(reader["dataRetorn"]),
                                NomUsuari = reader["nom"].ToString() + " " + reader["cognom"].ToString(),
                                NomDispositiu = reader["NomDispositiu"].ToString()
                            });
                        }
                    }
                }
            }

            return result;
        }

        // PRESTECSINFO PER ID USUARI
        public List<Prestec> GetByIdUsuari(int Id)
        {
            var result = new List<Prestec>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = @"
            SELECT 
                p.id AS PrestecId,
                p.idUsuari,
                p.idDispositiu,
                p.dataEntrega,
                p.dataRetorn,
                u.nom,
                u.cognom,
                d.nom AS NomDispositiu
            FROM prestecs p
            JOIN usuaris u ON u.id = p.idUsuari
            JOIN dispositius d ON d.id = p.idDispositiu
            WHERE p.idUsuari = @idUsuari";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@idUsuari", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Prestec
                            {
                                Id = Convert.ToInt32(reader["PrestecId"]),
                                IdUsuari = Convert.ToInt32(reader["idUsuari"]),
                                IdDispositiu = Convert.ToInt32(reader["idDispositiu"]),
                                DataEntrega = Convert.ToDateTime(reader["dataEntrega"]),
                                DataRetorn = Convert.ToDateTime(reader["dataRetorn"]),
                                NomUsuari = reader["nom"].ToString() + " " + reader["cognom"].ToString(),
                                NomDispositiu = reader["NomDispositiu"].ToString()
                            });
                        }
                    }
                }
            }

            return result;
        }

        // CREAR PRESTECS
        public Prestec Add(Prestec prestec)
        {
            using (var ctx = DbContext.GetInstance())
            {
                string query = "INSERT INTO prestecs (idUsuari, idDispositiu, dataEntrega, dataRetorn) VALUES (@idUsuari, @idDispositiu, @dataEntrega, @dataRetorn)";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@idUsuari", prestec.IdUsuari);
                    command.Parameters.AddWithValue("@idDispositiu", prestec.IdDispositiu);
                    command.Parameters.AddWithValue("@dataEntrega", prestec.DataEntrega);
                    command.Parameters.AddWithValue("@dataRetorn", prestec.DataRetorn);

                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT LAST_INSERT_ID();";
                    prestec.Id = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return prestec;
        }

        // ACTUALITZAR PRESTEC
        public int Update(Prestec prestec)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "UPDATE prestecs SET idDispositiu = @idDispositiu, idUsuari = @idUsuari, dataEntrega = @dataEntrega, dataRetorn= @dataRetorn WHERE id = @id";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.Add(new MySqlParameter("@id", prestec.Id));
                    command.Parameters.Add(new MySqlParameter("@idUsuari", prestec.IdUsuari));
                    command.Parameters.Add(new MySqlParameter("@idDispositiu", prestec.IdDispositiu));
                    command.Parameters.Add(new MySqlParameter("@dataEntrega", prestec.DataEntrega));
                    command.Parameters.Add(new MySqlParameter("@dataRetorn", prestec.DataRetorn));

                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        // ESBORRAR PRESTEC
        public int Delete(int Id)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "DELETE FROM prestecs WHERE id = @id";

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
