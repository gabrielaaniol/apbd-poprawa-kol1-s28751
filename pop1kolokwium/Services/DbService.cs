using Microsoft.Data.SqlClient;
using pop1kolokwium.Controllers;
using pop1kolokwium.ModelsDTOs;

namespace pop1kolokwium.Services;

public class DbService : IDbService
{
private readonly IConfiguration _configuration;

    public DbService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    // GET 
    
    public async Task<PreservationProjectDTO?> GetVisitByIdAsync(int visitId)
    {
        var query = @"
            SELECT v.date, 
                   c.staffid, c.projectid, c.role,
                   m.staff_id, m.first_name, m.last_name, m.hiredate
            FROM Visit v
            INNER JOIN Client c ON c.client_id = v.client_id
            INNER JOIN Mechanic m ON m.mechanic_id = v.mechanic_id
            WHERE v.visit_id = @id;
           ";

        await using var connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        await using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", visitId);

        await connection.OpenAsync();
        var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync()) return null;

        var visit = new ResponseDTO
        {
            Staffs = [new StaffDTO
            {
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                HireDate = reader.GetDateTime(3)
            }],
             //Institution = new InstitutionDTO()
            
            //    Name = reader.GetString(4),
            //    FoundedYear = reader.int(5)
            
            //Satffs = new List<StaffAssignmentsDTO>()
        };

        await reader.NextResultAsync();
        while (await reader.ReadAsync())
        {
            visit.Staffs.Add(new StaffDTO
            {
                FirstName = reader.GetString(0),
                LastName = reader.GetString(1)
            });
        }

        PreservationProjectDTO? preservationProjectDTO = null;
        return preservationProjectDTO;
    }

    public Task<object> GetPreservationProject(int id)
    {
        throw new NotImplementedException();
    }
}