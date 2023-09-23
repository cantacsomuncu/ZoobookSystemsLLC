using AutoMapper;
using ZoobookSystemsLLC.Entities.Concrete;
using ZoobookSystemsLLC.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoobookSystemsLLC.Services.AutoMapper.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeAddDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();
        }
    }
}
