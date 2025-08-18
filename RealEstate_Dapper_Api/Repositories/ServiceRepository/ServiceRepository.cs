using Dapper;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async void CreateService(CreateServiceDto createServiceDto)
        {
            string query = "INSERT INTO Service (ServiceName, ServiceStatus) VALUES (@ServiceName, @ServiceStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceName", createServiceDto.ServiceName);
            parameters.Add("@ServiceStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteService(int id)
        {
            string query = "DELETE FROM Service WHERE ServiceId = @ServiceId";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            string query = "SELECT * FROM Service";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDServiceDto> GetService(int id)
        {
            string query = "SELECT * FROM Service WHERE ServiceId = @ServiceId";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceId", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIDServiceDto>(query, parameters);
                return value;
            }
        }

        public async void UpdateService(UpdateServiceDto updateServiceDto)
        {
            var query = "UPDATE Service SET ServiceName = @ServiceName, ServiceStatus = @ServiceStatus WHERE ServiceId = @ServiceId";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceId", updateServiceDto.ServiceId);
            parameters.Add("@ServiceName", updateServiceDto.ServiceName);
            parameters.Add("@ServiceStatus", updateServiceDto.ServiceStatus);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query, parameters);
                if (result == 0)
                {
                    throw new Exception("Service not found or no changes made.");
                }

            }
        }
    }
}
