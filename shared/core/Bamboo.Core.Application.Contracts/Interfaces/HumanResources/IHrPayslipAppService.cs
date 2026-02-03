using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IHrPayslipAppService : IGenericApplicationService<HrPayslip>
    {
        Task<HrPayslip> CheckDoneAsync(Guid[] ids);
        Task<HrPayslip> ComputeSheetAsync(Guid[] ids);
        Task<HrPayslip> GetContractAsync(HrPayslipGetContractRequestDto input);
        Task<HrPayslip> GetInputsAsync(HrPayslipGetInputsRequestDto input);
        Task<HrPayslip> GetSalaryLineTotalAsync(HrPayslipGetSalaryLineTotalRequestDto input);
        Task<HrPayslip> GetWorkedDayLinesAsync(HrPayslipGetWorkedDayLinesRequestDto input);
        Task<HrPayslip> OnchangeContractAsync(Guid[] ids);
        Task<HrPayslip> OnchangeEmployeeAsync(Guid[] ids);
        Task<HrPayslip> OnchangeEmployeeIdAsync(HrPayslipOnchangeEmployeeIdRequestDto input);
        Task<HrPayslip> PayslipCancelAsync(Guid[] ids);
        Task<HrPayslip> PayslipDoneAsync(Guid[] ids);
        Task<HrPayslip> PayslipDraftAsync(Guid[] ids);
        Task<HrPayslip> RefundSheetAsync(Guid[] ids);
        Task<HrPayslip> SendEmailAsync(Guid[] ids);
    }
}