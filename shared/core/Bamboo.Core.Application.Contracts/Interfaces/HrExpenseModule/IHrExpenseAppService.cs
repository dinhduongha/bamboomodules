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
    public interface IHrExpenseAppService : IGenericApplicationService<HrExpense>
    {
        Task<HrExpense> ApproveDuplicatesAsync(Guid id);
        Task<HrExpense> AttachDocumentAsync(Guid id);
        Task<HrExpense> CheckAmountNotZeroAsync(Guid id, HrExpenseCheckAmountNotZeroRequestDto input);
        Task<HrExpense> CreateExpenseFromAttachmentsAsync(Guid id, HrExpenseCreateExpenseFromAttachmentsRequestDto input);
        Task<HrExpense> GetAttachmentViewAsync(Guid id);
        Task<HrExpense> GetEmptyListHelpAsync(Guid id, HrExpenseGetEmptyListHelpRequestDto input);
        Task<HrExpense> GetExpenseAttachmentsAsync(Guid id);
        Task<HrExpense> GetExpenseDashboardAsync(Guid id);
        Task<HrExpense> GetExpensesToSubmitAsync(Guid id);
        Task<HrExpense> MessageNewAsync(Guid id, HrExpenseMessageNewRequestDto input);
        Task<HrExpense> ShowSameReceiptExpenseIdsAsync(Guid id);
        Task<HrExpense> SplitWizardAsync(Guid id);
        Task<HrExpense> SubmitExpensesAsync(Guid id);
        Task<HrExpense> ViewSheetAsync(Guid id);
    }
}