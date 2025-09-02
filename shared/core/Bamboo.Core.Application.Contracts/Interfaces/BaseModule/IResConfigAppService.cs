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
    public interface IResConfigAppService : IGenericApplicationService<ResConfig>
    {
        Task<ResConfig> CancelAsync(Guid id);
        Task<ResConfig> ActionCancelAsync(Guid id);
        Task<ResConfig> ExecuteAsync(Guid id);
        Task<ResConfig> NextAsync(Guid id);
        Task<ResConfig> ActionNextAsync(Guid id);
        Task<ResConfig> SkipAsync(Guid id);
        Task<ResConfig> StartAsync(Guid id);
    }
}