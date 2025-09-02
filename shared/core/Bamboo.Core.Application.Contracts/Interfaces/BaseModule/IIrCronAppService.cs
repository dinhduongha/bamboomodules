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
    public interface IIrCronAppService : IGenericApplicationService<IrCron>
    {
        Task<IrCron> MethodDirectTriggerAsync(Guid id);
        Task<IrCron> ToggleAsync(Guid id, IrCronToggleRequestDto input);
        Task<IrCron> TryWriteAsync(Guid id, IrCronTryWriteRequestDto input);
    }
}