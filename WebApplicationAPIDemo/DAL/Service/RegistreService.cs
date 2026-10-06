using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using WebAplicationAPIRestDemo.DAL.Model;
using WebApplicationAPIRestDemo.Persistence;

namespace WebAplicationAPIRestDemo.DAL.Service
{
    public class RegistreService
    {
        // TOTS ELS REGISTRES
        public List<Registre> GetAll()
        {
            var result = new List<Registre>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM registres";

                using (var command = new MySqlCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Registre
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                IdPrestec = Convert.ToInt32(reader["idPrestec"]),
                                Accio = Convert.ToString(reader["accio"]),
                                NomUsuari = Convert.ToString(reader["nomUsuari"]),
                                IdUsuari = Convert.ToInt32(reader["idUsuari"]),
                                NomDispositiu = Convert.ToString(reader["nomDispositiu"]),
                                IdDispositiu = Convert.ToInt32(reader["idDispositiu"]),
                                NomGrup= Convert.ToString(reader["nomGrup"]),
                                IdGrup = Convert.ToInt32(reader["idGrup"]),
                                DataAccio = Convert.ToDateTime(reader["dataAccio"]),
                                DataRetorn= Convert.ToDateTime(reader["dataRetorn"]),
                            });
                        }
                    }
                }
            }
            return result;
        }

        // REGISTRES PER ID PRÉSTEC
        public List<Registre> GetByIdPrestec(int Id)
        {
            var result = new List<Registre>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM registres WHERE idPrestec = @idPrestec";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@idPrestec", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Registre
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                IdPrestec = Convert.ToInt32(reader["idPrestec"]),
                                Accio = Convert.ToString(reader["accio"]),
                                NomUsuari = Convert.ToString(reader["nomUsuari"]),
                                IdUsuari = Convert.ToInt32(reader["idUsuari"]),
                                NomDispositiu = Convert.ToString(reader["nomDispositiu"]),
                                IdDispositiu = Convert.ToInt32(reader["idDispositiu"]),
                                NomGrup = Convert.ToString(reader["nomGrup"]),
                                IdGrup = Convert.ToInt32(reader["idGrup"]),
                                DataAccio = Convert.ToDateTime(reader["dataAccio"]),
                                DataRetorn = Convert.ToDateTime(reader["dataRetorn"]),
                            });
                        }
                    }
                }
            }

            return result;
        }

        // REGISTRES PER ID DISPOSITIU
        public List<Registre> GetByIdDispositiu(int Id)
        {
            var result = new List<Registre>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM registres WHERE idDispositiu = @idDispositiu";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@idDispositiu", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Registre
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                IdPrestec = Convert.ToInt32(reader["idPrestec"]),
                                Accio = Convert.ToString(reader["accio"]),
                                NomUsuari = Convert.ToString(reader["nomUsuari"]),
                                IdUsuari = Convert.ToInt32(reader["idUsuari"]),
                                NomDispositiu = Convert.ToString(reader["nomDispositiu"]),
                                IdDispositiu = Convert.ToInt32(reader["idDispositiu"]),
                                NomGrup = Convert.ToString(reader["nomGrup"]),
                                IdGrup = Convert.ToInt32(reader["idGrup"]),
                                DataAccio = Convert.ToDateTime(reader["dataAccio"]),
                                DataRetorn = Convert.ToDateTime(reader["dataRetorn"]),
                            });
                        }
                    }
                }
            }

            return result;
        }

        // REGISTRES PER NOM GRUP
        public List<Registre> GetByIdGrup(int Id)
        {
            var result = new List<Registre>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM registres WHERE idGrup= @idGrup";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.AddWithValue("@idGrup", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Registre
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                IdPrestec = Convert.ToInt32(reader["idPrestec"]),
                                Accio = Convert.ToString(reader["accio"]),
                                NomUsuari = Convert.ToString(reader["nomUsuari"]),
                                IdUsuari = Convert.ToInt32(reader["idUsuari"]),
                                NomDispositiu = Convert.ToString(reader["nomDispositiu"]),
                                IdDispositiu = Convert.ToInt32(reader["idDispositiu"]),
                                NomGrup = Convert.ToString(reader["nomGrup"]),
                                IdGrup = Convert.ToInt32(reader["idGrup"]),
                                DataAccio = Convert.ToDateTime(reader["dataAccio"]),
                                DataRetorn = Convert.ToDateTime(reader["dataRetorn"]),
                            });
                        }
                    }
                }
            }

            return result;
        }

        //CREAR REGISTRE
        public Registre Add(Registre registre)
        {
            using (var ctx = DbContext.GetInstance())
            {
                string query = "INSERT INTO registres (idPrestec, accio, nomUsuari, idUsuari, nomDispositiu, idDispositiu, nomGrup, idGrup, dataAccio, dataRetorn) VALUES (@idPrestec, @accio, @nomUsuari, @idUsuari, @nomDispositiu, @idDispositiu, @nomGrup, @idGrup, @dataAccio, @dataRetorn)";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.Add(new MySqlParameter("@idPrestec", registre.IdPrestec));
                    command.Parameters.Add(new MySqlParameter("@accio", registre.Accio));
                    command.Parameters.Add(new MySqlParameter("@nomUsuari", registre.NomUsuari));
                    command.Parameters.Add(new MySqlParameter("@idUsuari", registre.IdUsuari));
                    command.Parameters.Add(new MySqlParameter("@nomDispositiu", registre.NomDispositiu));
                    command.Parameters.Add(new MySqlParameter("@idDispositiu", registre.IdDispositiu));
                    command.Parameters.Add(new MySqlParameter("@nomGrup", registre.NomGrup));
                    command.Parameters.Add(new MySqlParameter("@idGrup", registre.IdGrup));
                    command.Parameters.Add(new MySqlParameter("@dataAccio", registre.DataAccio));
                    command.Parameters.Add(new MySqlParameter("@dataRetorn", registre.DataRetorn));

                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT LAST_INSERT_ID();";
                    registre.Id = Convert.ToInt64(command.ExecuteScalar());
                }
            }
            return registre;
        }

        // ACTUALITZAR DISPOSITIU
        public int Update(Registre registre)
        {
            int rowsAffected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "UPDATE registres SET idPrestec = @idPrestec, accio = @accio, nomUsuari = @nomUsuari,  idUsuari = @idUsuari, nomDispositiu = @nomDispositiu, idDispositiu = @idDispositiu, nomGrup = @nomGrup, idGrup = @idGrup, dataAccio = @dataAccio, dataRetorn = @dataRetorn WHERE idPrestec = @idPrestec";

                using (var command = new MySqlCommand(query, ctx))
                {
                    command.Parameters.Add(new MySqlParameter("@idPrestec", registre.IdPrestec));
                    command.Parameters.Add(new MySqlParameter("@accio", registre.Accio));
                    command.Parameters.Add(new MySqlParameter("@nomUsuari", registre.NomUsuari));
                    command.Parameters.Add(new MySqlParameter("@idUsuari", registre.IdUsuari));
                    command.Parameters.Add(new MySqlParameter("@nomDispositiu", registre.NomDispositiu));
                    command.Parameters.Add(new MySqlParameter("@idDispositiu", registre.IdDispositiu));
                    command.Parameters.Add(new MySqlParameter("@nomGrup", registre.NomGrup));
                    command.Parameters.Add(new MySqlParameter("@idGrup", registre.IdGrup));
                    command.Parameters.Add(new MySqlParameter("@dataAccio", registre.DataAccio));
                    command.Parameters.Add(new MySqlParameter("@dataRetorn", registre.DataRetorn));

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
                string query = "DELETE FROM registres WHERE id = @id";

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
