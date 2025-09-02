using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IHrPayslipAppService : IGenericApplicationService<HrPayslip>
    {
        Task<HrPayslip> CheckDoneAsync(Guid id);
        Task<HrPayslip> ComputeSheetAsync(Guid id);
        Task<HrPayslip> GetContractAsync(Guid id, HrPayslipGetContractRequestDto input);
        Task<HrPayslip> GetInputsAsync(Guid id, HrPayslipGetInputsRequestDto input);
        Task<HrPayslip> GetSalaryLineTotalAsync(Guid id, HrPayslipGetSalaryLineTotalRequestDto input);
        Task<HrPayslip> GetWorkedDayLinesAsync(Guid id, HrPayslipGetWorkedDayLinesRequestDto input);
        Task<HrPayslip> OnchangeContractAsync(Guid id);
        Task<HrPayslip> OnchangeEmployeeAsync(Guid id);
        Task<HrPayslip> OnchangeEmployeeIdAsync(Guid id, HrPayslipOnchangeEmployeeIdRequestDto input);
        Task<HrPayslip> PayslipCancelAsync(Guid id);
        Task<HrPayslip> PayslipDoneAsync(Guid id);
        Task<HrPayslip> PayslipDraftAsync(Guid id);
        Task<HrPayslip> RefundSheetAsync(Guid id);
        Task<HrPayslip> SendEmailAsync(Guid id);
    }
}