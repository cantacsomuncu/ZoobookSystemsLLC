using AutoMapper;
using System.Threading.Tasks;
using ZoobookSystemsLLC.Data.Abstract;
using ZoobookSystemsLLC.Entities.Concrete;
using ZoobookSystemsLLC.Entities.Dtos;
using ZoobookSystemsLLC.Services.Abstract;
using ZoobookSystemsLLC.Services.Utilities;
using ZoobookSystemsLLC.Shared.Utilities.Results.Abstract;
using ZoobookSystemsLLC.Shared.Utilities.Results.ComplexTypes;
using ZoobookSystemsLLC.Shared.Utilities.Results.Concrete;
using static ZoobookSystemsLLC.Services.Utilities.Messages;

namespace ZoobookSystemsLLC.Services.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<EmployeeDto>> GetAsync(int employeeId)
        {
            var employee = await _unitOfWork.Employees.GetAsync(a => a.Id == employeeId);
            if (employee != null)
            {
                return new DataResult<EmployeeDto>(ResultStatus.Success, new EmployeeDto
                {
                    Employee = employee,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<EmployeeDto>(ResultStatus.Error, Messages.EmployeeStatusMsg.NotFound(isPlural: false), null);
        }

        public async Task<IDataResult<EmployeeListDto>> GetAllAsync()
        {
            var employees = await _unitOfWork.Employees.GetAllAsync(null);
            if (employees.Count > 0)
            {
                return new DataResult<EmployeeListDto>(ResultStatus.Success, new EmployeeListDto
                {
                    Employees = employees,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<EmployeeListDto>(ResultStatus.Error, Messages.EmployeeStatusMsg.NotFound(isPlural: true), null);
        }      

        public async Task<IResult> AddAsync(EmployeeAddDto employeeAddDto)
        {
            var employee = _mapper.Map<Employee>(employeeAddDto);
            await _unitOfWork.Employees.AddAsync(employee);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.EmployeeStatusMsg.Add(employee.FirstName));
        }

        public async Task<IResult> UpdateAsync(EmployeeUpdateDto employeeUpdateDto)
        {
            var result = await _unitOfWork.Employees.AnyAsync(a => a.Id == employeeUpdateDto.Id);
            if (result)
            {
                var employee = _mapper.Map<Employee>(employeeUpdateDto);
                await _unitOfWork.Employees.UpdateAsync(employee);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.EmployeeStatusMsg.Update(employeeUpdateDto.FirstName));
            }
            return new Result(ResultStatus.Error, Messages.EmployeeStatusMsg.NotFound(isPlural: false));
        }

        public async Task<IResult> DeleteAsync(int employeeId)
        {
            var result = await _unitOfWork.Employees.AnyAsync(a => a.Id == employeeId);
            if (result)
            {
                var employee = await _unitOfWork.Employees.GetAsync(a => a.Id == employeeId);
                await _unitOfWork.Employees.DeleteAsync(employee);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.EmployeeStatusMsg.Delete(employee.FirstName));
            }
            return new Result(ResultStatus.Error, Messages.EmployeeStatusMsg.NotFound(isPlural: false));
        }
    }
}
