using Application.Requests;
using Application.Responses;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public List<StaffResponse> GetAllStaff()
        {
            return _staffService.GetAllStaff();
        }

        [HttpGet("{id}")]
        public StaffResponse GetStaffById([FromRoute] int id)
        {
            return _staffService.GetStaffById(id);
        }

        [HttpGet("email/{email}")]
        public StaffResponse GetStaffByEmail([FromRoute] string email)
        {
            return _staffService.GetStaffByEmail(email);
        }

        [HttpGet("city/{city}")]
        public List<StaffResponse> GetStaffByCity([FromRoute] string city)
        {
            return _staffService.GetStaffByCity(city);
        }

        [HttpPost]
        public void CreateStaff([FromBody] CreateStaffRequest request)
        {
            _staffService.CreateStaff(request);
        }

        [HttpPut("{id}")]
        public void UpdateStaff([FromRoute] int id, [FromBody] UpdateStaffRequest request)
        {
            _staffService.UpdateStaff(id, request);
        }

        [HttpDelete("{id}")]
        public void DeleteStaff([FromRoute] int id)
        {
            _staffService.DeleteStaff(id);
        }
    }
}
