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
    public class DatosPrestamoRepository
    {
        private readonly string _connectionString;
        public DatosPrestamoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<DatosPrestamos>> GetDatos()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.datosPrestamo", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<DatosPrestamos>();
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
        private DatosPrestamos MapToValue(SqlDataReader reader)
        {
            return new DatosPrestamos()
            {
                id = (int)reader["id"],
                idMaterial = (int)reader["idMaterial"],
                nombreMaterial = (string)reader["nombreMaterial"],
                idUsuario = (int)reader["idUsuario"],
                nombreUsuario = (string)reader["nombreUsuario"],
                apellidoUsuario = (string)reader["apellidoUsuario"],
                fechaInicial = (DateTime)reader["fechaInicial"],
                fechaFinal = (DateTime)reader["fechaFinal"]
            };
        }

    }
}