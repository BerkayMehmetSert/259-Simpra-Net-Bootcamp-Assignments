using Application.Requests;
using Application.Responses;

namespace Application.Services
{
    public interface IStaffService
    {
        void CreateStaff(CreateStaffRequest request);
        void UpdateStaff(int id, UpdateStaffRequest request);
        void DeleteStaff(int id);
        StaffResponse GetStaffById(int id);
        StaffResponse GetStaffByEmail(string email);
        List<StaffResponse> GetStaffByCity(string city);
        List<StaffResponse> GetAllStaff();
    }
}
