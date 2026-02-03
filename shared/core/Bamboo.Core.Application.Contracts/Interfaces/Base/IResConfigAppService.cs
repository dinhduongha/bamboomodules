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
        Task<ResConfig> CancelAsync(Guid[] ids);
        Task<ResConfig> CancelActionAsync(Guid[] ids);
        Task<ResConfig> ExecuteAsync(Guid[] ids);
        Task<ResConfig> NextAsync(Guid[] ids);
        Task<ResConfig> NextActionAsync(Guid[] ids);
        Task<ResConfig> SkipAsync(Guid[] ids);
        Task<ResConfig> StartAsync(Guid[] ids);
    }
}