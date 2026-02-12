using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("OmHrPayroll", Category = "HumanResources", Depends = new[] { "mail", "hr_contract", "hr_holidays" })]
    public partial class HrPayslipAppService : GenericAppService<HrPayslip>, IHrPayslipAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public HrPayslipAppService(IRepository<HrPayslip, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<HrPayslip> CheckDoneAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: check_done) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrPayslip> ComputeSheetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: compute_sheet) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<HrPayslip> CreateAsync(CreateRequestDto<HrPayslip> input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll_account, FILE: hr_payroll_account.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public async Task<HrPayslip> GetContractAsync(HrPayslipGetContractRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: get_contract) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrPayslip> GetInputsAsync(HrPayslipGetInputsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: get_inputs) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrPayslip> GetSalaryLineTotalAsync(HrPayslipGetSalaryLineTotalRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: get_salary_line_total) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrPayslip> GetWorkedDayLinesAsync(HrPayslipGetWorkedDayLinesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: get_worked_day_lines) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrPayslip> OnchangeContractAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: onchange_contract) ---
            --- METHOD SOURCE (MODULE: om_hr_payroll_account, FILE: hr_payroll_account.py, METHOD: onchange_contract) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrPayslip> OnchangeEmployeeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: onchange_employee) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrPayslip> OnchangeEmployeeIdAsync(HrPayslipOnchangeEmployeeIdRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: onchange_employee_id) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrPayslip> PayslipCancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: action_payslip_cancel) ---
            --- METHOD SOURCE (MODULE: om_hr_payroll_account, FILE: hr_payroll_account.py, METHOD: action_payslip_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrPayslip> PayslipDoneAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: action_payslip_done) ---
            --- METHOD SOURCE (MODULE: om_hr_payroll_account, FILE: hr_payroll_account.py, METHOD: action_payslip_done) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrPayslip> PayslipDraftAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: action_payslip_draft) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrPayslip> RefundSheetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: refund_sheet) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrPayslip> SendEmailAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_payslip.py, METHOD: action_send_email) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}