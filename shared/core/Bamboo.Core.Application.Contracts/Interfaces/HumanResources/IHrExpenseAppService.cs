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
        Task<HrExpense> ApproveAsync(Guid id);
        Task<HrExpense> ApproveDuplicatesAsync(Guid id);
        Task<HrExpense> AttachDocumentAsync(Guid id);
        Task<HrExpense> CreateExpenseFromAttachmentsAsync(Guid id, HrExpenseCreateExpenseFromAttachmentsRequestDto input);
        Task<HrExpense> GetEmptyListHelpAsync(Guid id, HrExpenseGetEmptyListHelpRequestDto input);
        Task<HrExpense> GetExpenseDashboardAsync(Guid id);
        Task<HrExpense> MessageNewAsync(Guid id, HrExpenseMessageNewRequestDto input);
        Task<HrExpense> OpenAccountMoveAsync(Guid id);
        Task<HrExpense> OpenSaleOrderAsync(Guid id);
        Task<HrExpense> OpenSplitExpenseAsync(Guid id);
        Task<HrExpense> PayAsync(Guid id);
        Task<HrExpense> PostAsync(Guid id);
        Task<HrExpense> RefuseAsync(Guid id);
        Task<HrExpense> ResetAsync(Guid id);
        Task<HrExpense> ShowSameReceiptExpenseIdsAsync(Guid id);
        Task<HrExpense> SplitWizardAsync(Guid id);
        Task<HrExpense> SubmitAsync(Guid id);
        Task<HrExpense> UpdateActivitiesAndMailsAsync(Guid id);
    }
}