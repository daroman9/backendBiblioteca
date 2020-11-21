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
    public class ListarPrestamoGradosRepository
    {
        private readonly string _connectionString;
        public ListarPrestamoGradosRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<ListarPrestamosGrados>> GetDatos(string grado)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.listarPrestamoGrado", sql))
                {
                    cmd.Parameters.Add("@grado", SqlDbType.VarChar).Value = (object)grado ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<ListarPrestamosGrados>();
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
        private ListarPrestamosGrados MapToValue(SqlDataReader reader)
        {
            return new ListarPrestamosGrados()
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