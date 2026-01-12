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
    public interface IResConfigAppService : IGenericApplicationService<ResConfig>
    {
        Task<ResConfig> CancelAsync(Guid id);
        Task<ResConfig> CancelActionAsync(Guid id);
        Task<ResConfig> ExecuteAsync(Guid id);
        Task<ResConfig> NextAsync(Guid id);
        Task<ResConfig> NextActionAsync(Guid id);
        Task<ResConfig> SkipAsync(Guid id);
        Task<ResConfig> StartAsync(Guid id);
    }
}