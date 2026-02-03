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
    public interface IRecurringPaymentAppService : IGenericAppService<RecurringPayment>
    {
        Task<RecurringPayment> ComputeNextDateAsync(RecurringPaymentComputeNextDateRequestDto input);
        Task<RecurringPayment> CreateLinesAsync(RecurringPaymentCreateLinesRequestDto input);
        Task<RecurringPayment> DoneAsync(Guid[] ids);
        Task<RecurringPayment> DraftAsync(Guid[] ids);
        Task<RecurringPayment> GeneratePaymentAsync(Guid[] ids);
    }
}