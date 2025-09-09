using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IHrExpenseSheetAppService : IGenericApplicationService<HrExpenseSheet>
    {
        Task<HrExpenseSheet> ActivityUpdateAsync(Guid id);
        Task<HrExpenseSheet> ApproveExpenseSheetsAsync(Guid id);
        Task<HrExpenseSheet> OpenAccountMovesAsync(Guid id);
        Task<HrExpenseSheet> OpenExpenseViewAsync(Guid id);
        Task<HrExpenseSheet> OpenSaleOrdersAsync(Guid id);
        Task<HrExpenseSheet> RefuseExpenseSheetsAsync(Guid id);
        Task<HrExpenseSheet> RegisterPaymentAsync(Guid id);
        Task<HrExpenseSheet> ResetExpenseSheetsAsync(Guid id);
        Task<HrExpenseSheet> SetToPaidAsync(Guid id);
        Task<HrExpenseSheet> SetToPostedAsync(Guid id);
        Task<HrExpenseSheet> SheetMovePostAsync(Guid id);
        Task<HrExpenseSheet> SubmitSheetAsync(Guid id);
    }
}