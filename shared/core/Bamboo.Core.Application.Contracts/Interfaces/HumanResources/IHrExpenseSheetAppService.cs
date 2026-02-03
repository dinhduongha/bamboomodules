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
    public interface IHrExpenseSheetAppService : IGenericApplicationService<HrExpenseSheet>
    {
        Task<HrExpenseSheet> ActivityUpdateAsync(Guid[] ids);
        Task<HrExpenseSheet> ApproveExpenseSheetsAsync(Guid[] ids);
        Task<HrExpenseSheet> OpenAccountMovesAsync(Guid[] ids);
        Task<HrExpenseSheet> OpenExpenseViewAsync(Guid[] ids);
        Task<HrExpenseSheet> OpenSaleOrdersAsync(Guid[] ids);
        Task<HrExpenseSheet> RefuseExpenseSheetsAsync(Guid[] ids);
        Task<HrExpenseSheet> RegisterPaymentAsync(Guid[] ids);
        Task<HrExpenseSheet> ResetExpenseSheetsAsync(Guid[] ids);
        Task<HrExpenseSheet> SetToPaidAsync(Guid[] ids);
        Task<HrExpenseSheet> SetToPostedAsync(Guid[] ids);
        Task<HrExpenseSheet> SheetMovePostAsync(Guid[] ids);
        Task<HrExpenseSheet> SubmitSheetAsync(Guid[] ids);
    }
}