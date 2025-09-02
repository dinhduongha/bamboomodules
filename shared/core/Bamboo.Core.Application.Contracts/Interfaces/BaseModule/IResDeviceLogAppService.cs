using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IResDeviceLogAppService : IApplicationService
    {
        Task<ResDeviceLog> InitAsync(Guid id);
        Task<ResDeviceLog> RevokeAsync(Guid id);
    }
}