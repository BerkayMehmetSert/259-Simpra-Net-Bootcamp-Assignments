using Application.Requests;
using Application.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class StaffMapper : Profile
    {
        public StaffMapper()
        {
            CreateMap<CreateStaffRequest,Staff>();
            CreateMap<UpdateStaffRequest,Staff>();
            CreateMap<Staff,StaffResponse>();
        }
    }
}
