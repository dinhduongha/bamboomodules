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
    public interface IIrActionsTodoAppService : IGenericApplicationService<IrActionsTodo>
    {
        Task<IrActionsTodo> EnsureOneOpenTodoAsync(Guid id);
        Task<IrActionsTodo> LaunchAsync(Guid id);
        Task<IrActionsTodo> OpenAsync(Guid id);
    }
}