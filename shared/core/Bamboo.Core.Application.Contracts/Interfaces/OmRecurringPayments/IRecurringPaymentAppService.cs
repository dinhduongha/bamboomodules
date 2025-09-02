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
    public interface IRecurringPaymentAppService : IGenericApplicationService<RecurringPayment>
    {
        Task<RecurringPayment> ComputeNextDateAsync(Guid id, RecurringPaymentComputeNextDateRequestDto input);
        Task<RecurringPayment> CreateLinesAsync(Guid id, RecurringPaymentCreateLinesRequestDto input);
        Task<RecurringPayment> DoneAsync(Guid id);
        Task<RecurringPayment> DraftAsync(Guid id);
        Task<RecurringPayment> GeneratePaymentAsync(Guid id);
    }
}