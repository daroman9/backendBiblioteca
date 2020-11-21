using BackendBiblioteca.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BackendBiblioteca.DataConsultas
{
    public class ListarPrestamoUsuarioRepository
    {
        private readonly string _connectionString;
        public ListarPrestamoUsuarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<ListarPrestamoUsuarios>> GetDatos(string documento)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.listarPrestamoUsuario", sql))
                {
                    cmd.Parameters.Add("@documento", SqlDbType.VarChar).Value = (object)documento ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<ListarPrestamoUsuarios>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {

                        while (await reader.ReadAsync())
                        {

                            response.Add(MapToValue(reader));

                        }
                    }

                    return response;
                }
            }
        }
        private ListarPrestamoUsuarios MapToValue(SqlDataReader reader)
        {
            return new ListarPrestamoUsuarios()
            {
                nombreAlumno = (string)reader["nombreAlumno"],
                apellidoAlumno = (string)reader["apellidoAlumno"],
                documentoAlumno = (string)reader["documentoAlumno"],
                idPrestamo = (int)reader["idPrestamo"],
                idMaterial = (int)reader["idMaterial"],
                nombreMaterial = (string)reader["nombreMaterial"],
                fechaInicial = (DateTime)reader["fechaInicial"],
                fechaFinal = (DateTime)reader["fechaFinal"]
            };
        }

    }
}
