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
    public interface IHrExpenseAppService : IGenericApplicationService<HrExpense>
    {
        Task<HrExpense> ApproveAsync(Guid[] ids);
        Task<HrExpense> ApproveDuplicatesAsync(Guid[] ids);
        Task<HrExpense> AttachDocumentAsync(Guid[] ids);
        Task<HrExpense> CreateExpenseFromAttachmentsAsync(HrExpenseCreateExpenseFromAttachmentsRequestDto input);
        Task<HrExpense> GetEmptyListHelpAsync(HrExpenseGetEmptyListHelpRequestDto input);
        Task<HrExpense> GetExpenseDashboardAsync(Guid[] ids);
        Task<HrExpense> MessageNewAsync(HrExpenseMessageNewRequestDto input);
        Task<HrExpense> OpenAccountMoveAsync(Guid[] ids);
        Task<HrExpense> OpenSaleOrderAsync(Guid[] ids);
        Task<HrExpense> OpenSplitExpenseAsync(Guid[] ids);
        Task<HrExpense> PayAsync(Guid[] ids);
        Task<HrExpense> PostAsync(Guid[] ids);
        Task<HrExpense> RefuseAsync(Guid[] ids);
        Task<HrExpense> ResetAsync(Guid[] ids);
        Task<HrExpense> ShowSameReceiptExpenseIdsAsync(Guid[] ids);
        Task<HrExpense> SplitWizardAsync(Guid[] ids);
        Task<HrExpense> SubmitAsync(Guid[] ids);
        Task<HrExpense> UpdateActivitiesAndMailsAsync(Guid[] ids);
    }
}