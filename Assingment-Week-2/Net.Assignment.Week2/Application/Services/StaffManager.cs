using Application.Repositories;
using Application.Requests;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using static Application.Constants.StaffMessage;

namespace Application.Services
{
    public class StaffManager : IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StaffManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateStaff(CreateStaffRequest request)
        {
            CheckIfStaffExistsByEmail(request.Email);

            var staff = _mapper.Map<Staff>(request);
            _unitOfWork.StaffRepository.Create(staff);
            _unitOfWork.SaveChanges();
        }

        public void UpdateStaff(int id, UpdateStaffRequest request)
        {
            var staff = GetStaff(id);

            if(staff.Email.ToLower() != request.Email.ToLower())
            {
                CheckIfStaffExistsByEmail(request.Email);
            }

            _mapper.Map(request, staff);
            _unitOfWork.StaffRepository.Update(staff);
            _unitOfWork.SaveChanges();
        }

        public void DeleteStaff(int id)
        {
            var staff = GetStaff(id);
            _unitOfWork.StaffRepository.Delete(staff);
            _unitOfWork.SaveChanges();
        }

        public StaffResponse GetStaffById(int id)
        {
            var staff = GetStaff(id);
            var response = _mapper.Map<StaffResponse>(staff);
            return response;
        }

        public StaffResponse GetStaffByEmail(string email)
        {
            var staff = _unitOfWork.StaffRepository.Get(x => x.Email == email);
            var response = _mapper.Map<StaffResponse>(staff);
            return response;
        }

        public List<StaffResponse> GetStaffByCity(string city)
        {
            var staffList = _unitOfWork.StaffRepository.GetAll(x => x.City == city);

            if(staffList.Count == 0) throw new Exception(StaffNotFoundByCity);

            var response = _mapper.Map<List<StaffResponse>>(staffList);
            return response;
        }

        public List<StaffResponse> GetAllStaff()
        {
            var staffList = _unitOfWork.StaffRepository.GetAll();

            if(staffList.Count == 0) throw new Exception(StaffListIsEmpty);

            var response = _mapper.Map<List<StaffResponse>>(staffList);
            return response;
        }

        private Staff GetStaff(int id)
        {
            var staff = _unitOfWork.StaffRepository.Get(x => x.Id == id);
            return staff ?? throw new Exception(StaffNotFoundById);
        }

        private void CheckIfStaffExistsByEmail(string email)
        {
            var staff = _unitOfWork.StaffRepository.Get(x => x.Email == email);
            if(staff is not null) throw new Exception(StaffExistsByEmail);
        }
    }
}
