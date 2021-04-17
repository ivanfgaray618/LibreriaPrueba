namespace BackEnd.Repository.Clases
{
    using BackEnd.Repository.Interfaces;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class RepositorioAutor : IRepositorioAutor
    {
        #region Constantes
        const string conectionString = "Server=DESKTOP-G48D76F\\MSSQLSERVER01;Database=Libreria;User Id=usuarioLibreria;Password=123456789;";
        const string spListarAutores = "ConsultarAutores";
        const string spAgregarAutor = "AgregarAutor";
        const string spModificarAutor = "ModificarAutor";
        const string spEliminarAutor = "EliminarAutor";
        const string spListarPaises = "ConsultarPaises";
        const string spListarCiudades = "ConsultarCiudades";
        const string spListarGeneros = "ConsultarGeneros";
        #endregion

        public Respuesta ConsultarAutores()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (SqlConnection sql = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spListarAutores, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sql.Open();
                        var response = new List<Autor>();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                response.Add(
                                    new Autor
                                    {
                                        IdAutor = reader.GetInt32(reader.GetOrdinal("IdAutor")),
                                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                        Nacionalidad = reader.GetString(reader.GetOrdinal("NombrePais")),
                                        Sexo = reader.GetString(reader.GetOrdinal("Sexo")),
                                        CantidadLibros = reader.GetInt32(reader.GetOrdinal("CantidadLibros")),
                                        IdPais = reader.GetInt32(reader.GetOrdinal("IdPais")),
                                        IdCiudad = reader.GetInt32(reader.GetOrdinal("IdCiudad")),
                                        IdSexo = reader.GetString(reader.GetOrdinal("IdSexo")),
                                    }
                                );
                            }
                        }

                        respuesta.NumeroError = default(int);
                        respuesta.Resultado = response;
                        return respuesta;
                    }
                }
            }
            catch (Exception e)
            {
                respuesta.NumeroError = 1;
                return respuesta;
            }
        }

        public Respuesta CrearAutor(Autor autor)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (SqlConnection sql = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spAgregarAutor, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", autor.Nombre);
                        cmd.Parameters.AddWithValue("@Ciudad", autor.IdCiudad);
                        cmd.Parameters.AddWithValue("@Sexo", autor.IdSexo);
                        cmd.Parameters.Add("@Error", SqlDbType.Int).Direction = ParameterDirection.Output;
                        sql.Open();
                        cmd.ExecuteNonQuery();
                        respuesta.NumeroError = Convert.ToInt32(cmd.Parameters["@Error"].Value);
                        return respuesta;
                    }
                }
            }
            catch (Exception e)
            {
                respuesta.NumeroError = 1;
                return respuesta;
            }
        }

        public Respuesta ModificarAutor(Autor autor)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (SqlConnection sql = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spModificarAutor, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdAutor", autor.IdAutor);
                        cmd.Parameters.AddWithValue("@Nombre", autor.Nombre);
                        cmd.Parameters.AddWithValue("@Ciudad", autor.IdCiudad);
                        cmd.Parameters.AddWithValue("@Sexo", autor.IdSexo);
                        cmd.Parameters.Add("@Error", SqlDbType.Int).Direction = ParameterDirection.Output;
                        sql.Open();
                        cmd.ExecuteNonQuery();
                        respuesta.NumeroError = Convert.ToInt32(cmd.Parameters["@Error"].Value);
                        return respuesta;
                    }
                }
            }
            catch (Exception e)
            {
                respuesta.NumeroError = 1;
                return respuesta;
            }
        }

        public Respuesta EliminarAutor(Autor autor)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (SqlConnection sql = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spEliminarAutor, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdAutor", autor.IdAutor);
                        cmd.Parameters.Add("@Error", SqlDbType.Int).Direction = ParameterDirection.Output;
                        sql.Open();
                        cmd.ExecuteNonQuery();
                        respuesta.NumeroError = Convert.ToInt32(cmd.Parameters["@Error"].Value);
                        return respuesta;
                    }
                }
            }
            catch (Exception e)
            {
                respuesta.NumeroError = 1;
                return respuesta;
            }
        }

        public Respuesta ConsultarPaises()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (SqlConnection sql = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spListarPaises, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sql.Open();
                        var response = new List<Pais>();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                response.Add(
                                    new Pais
                                    {
                                        IdPais = reader.GetInt32(reader.GetOrdinal("IdPais")),
                                        Nombre = reader.GetString(reader.GetOrdinal("Nombre"))
                                    }
                                );
                            }
                        }

                        respuesta.NumeroError = default(int);
                        respuesta.Resultado = response;
                        return respuesta;
                    }
                }
            }
            catch (Exception e)
            {
                respuesta.NumeroError = 1;
                return respuesta;
            }
        }

        public Respuesta ConsultarCiudades()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (SqlConnection sql = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spListarCiudades, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sql.Open();
                        var response = new List<Ciudad>();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                response.Add(
                                    new Ciudad
                                    {
                                        IdCiudad = reader.GetInt32(reader.GetOrdinal("IdCiudad")),
                                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                        IdPais = reader.GetInt32(reader.GetOrdinal("IdPais")),
                                    }
                                );
                            }
                        }

                        respuesta.NumeroError = default(int);
                        respuesta.Resultado = response;
                        return respuesta;
                    }
                }
            }
            catch (Exception e)
            {
                respuesta.NumeroError = 1;
                return respuesta;
            }
        }

        public Respuesta ConsultarGeneros()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (SqlConnection sql = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spListarGeneros, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sql.Open();
                        var response = new List<Sexo>();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                response.Add(
                                    new Sexo
                                    {
                                        IdSexo = reader.GetString(reader.GetOrdinal("IdSexo")),
                                        Nombre = reader.GetString(reader.GetOrdinal("Nombre"))
                                    }
                                );
                            }
                        }

                        respuesta.NumeroError = default(int);
                        respuesta.Resultado = response;
                        return respuesta;
                    }
                }
            }
            catch (Exception e)
            {
                respuesta.NumeroError = 1;
                return respuesta;
            }
        }

    }
}
