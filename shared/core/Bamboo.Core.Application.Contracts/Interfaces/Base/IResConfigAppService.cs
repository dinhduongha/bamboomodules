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