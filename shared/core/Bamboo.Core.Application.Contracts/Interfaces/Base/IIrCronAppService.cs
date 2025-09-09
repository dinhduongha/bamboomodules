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
    public interface IIrCronAppService : IGenericApplicationService<IrCron>
    {
        Task<IrCron> MethodDirectTriggerAsync(Guid id);
        Task<IrCron> ToggleAsync(Guid id, IrCronToggleRequestDto input);
        Task<IrCron> TryWriteAsync(Guid id, IrCronTryWriteRequestDto input);
    }
}