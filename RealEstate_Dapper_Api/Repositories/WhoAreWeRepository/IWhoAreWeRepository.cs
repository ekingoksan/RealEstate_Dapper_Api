using RealEstate_Dapper_Api.Dtos.WhoAreWeDetailsDtos;

namespace RealEstate_Dapper_Api.Repositories.WhoAreWeRepository
{
    public interface IWhoAreWeRepository
    {
        Task<List<ResultWhoAreWeDetailsDto>> GetAllWhoAreWeDetailsAsync();
        void CreateWhoAreWeDetails(CreateWhoAreWeDetailsDto createWhoAreWeDetailsDto);
        void DeleteWhoAreWeDetails(int id);
        void UpdateWhoAreWeDetails(UpdateWhoAreWeDetailsDto updateWhoAreWeDetailsDto);
        Task<GetByIDWhoAreWeDetailsDto> GetWhoAreWeDetails(int id);
    }
}
