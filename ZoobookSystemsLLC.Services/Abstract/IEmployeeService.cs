using ZoobookSystemsLLC.Entities.Concrete;
using ZoobookSystemsLLC.Entities.Dtos;
using ZoobookSystemsLLC.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoobookSystemsLLC.Services.Abstract
{
    public interface IEmployeeService
    {
        Task<IDataResult<EmployeeDto>> GetAsync(int employeeId);
        Task<IDataResult<EmployeeListDto>> GetAllAsync();
        Task<IResult> AddAsync(EmployeeAddDto employeeAddDto);
        Task<IResult> UpdateAsync(EmployeeUpdateDto employeeUpdateDto);
        Task<IResult> DeleteAsync(int employeeId);
    }
}
