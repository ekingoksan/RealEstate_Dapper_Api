using Dapper;
using RealEstate_Dapper_Api.Dtos.WhoAreWeDetailsDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoAreWeRepository
{
    public class WhoAreWeRepository : IWhoAreWeRepository
    {
        private readonly Context _context;
        public WhoAreWeRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoAreWeDetails(CreateWhoAreWeDetailsDto createWhoAreWeDetailsDto)
        {
            string query = "INSERT INTO WhoAreWeDetails (Title, Subtitle, Description1, Description2) " +
                           "VALUES (@Title, @Subtitle, @Description1, @Description2)";
            var parameters = new DynamicParameters();
            parameters.Add("Title", createWhoAreWeDetailsDto.Title);
            parameters.Add("Subtitle", createWhoAreWeDetailsDto.Subtitle);
            parameters.Add("Description1", createWhoAreWeDetailsDto.Description1);
            parameters.Add("Description2", createWhoAreWeDetailsDto.Description2);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoAreWeDetails(int id)
        {
            string query = "DELETE FROM WhoAreWeDetails WHERE WhoAreWeID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoAreWeDetailsDto>> GetAllWhoAreWeDetailsAsync()
        {
            var query = "SELECT * FROM WhoAreWeDetails";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoAreWeDetailsDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDWhoAreWeDetailsDto> GetWhoAreWeDetails(int id)
        {
            var query = "SELECT * FROM WhoAreWeDetails WHERE WhoAreWeID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIDWhoAreWeDetailsDto>(query, parameters);
                return value;
            }
        }

        public async void UpdateWhoAreWeDetails(UpdateWhoAreWeDetailsDto updateWhoAreWeDetailsDto)
        {
            var query = "UPDATE WhoAreWeDetails SET Title = @Title, Subtitle = @Subtitle, " +
                        "Description1 = @Description1, Description2 = @Description2 WHERE WhoAreWeID = @WhoAreWeID";
            var parameters = new DynamicParameters();
            parameters.Add("WhoAreWeID", updateWhoAreWeDetailsDto.WhoAreWeID);
            parameters.Add("Title", updateWhoAreWeDetailsDto.Title);
            parameters.Add("Subtitle", updateWhoAreWeDetailsDto.Subtitle);
            parameters.Add("Description1", updateWhoAreWeDetailsDto.Description1);
            parameters.Add("Description2", updateWhoAreWeDetailsDto.Description2);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
