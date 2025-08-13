using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.WhoAreWeDetailsDtos;
using RealEstate_Dapper_Api.Repositories.WhoAreWeRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoAreWeDetailsController : ControllerBase
    {
        private readonly IWhoAreWeRepository _whoAreWeRepository;
        public WhoAreWeDetailsController(IWhoAreWeRepository whoAreWeRepository)
        {
            _whoAreWeRepository = whoAreWeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> WhoAreWeDetailsList()
        {
            var values = await _whoAreWeRepository.GetAllWhoAreWeDetailsAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhoAreWeDetails(CreateWhoAreWeDetailsDto createWhoAreWeDetailsDto)
        {
            _whoAreWeRepository.CreateWhoAreWeDetails(createWhoAreWeDetailsDto);
            return Ok("Who Are We Details successfully added");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWhoAreWeDetails(int id)
        {
            _whoAreWeRepository.DeleteWhoAreWeDetails(id);
            return Ok("Who Are We Details successfully deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWhoAreWeDetails(UpdateWhoAreWeDetailsDto updateWhoAreWeDetailsDto)
        {
            _whoAreWeRepository.UpdateWhoAreWeDetails(updateWhoAreWeDetailsDto);
            return Ok("Who Are We Details successfully updated");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoAreWeDetails(int id)
        {
            var value = await _whoAreWeRepository.GetWhoAreWeDetails(id);
            if (value == null)
            {
                return NotFound("Who Are We Details not found");
            }
            return Ok(value);
        }
    }
}
