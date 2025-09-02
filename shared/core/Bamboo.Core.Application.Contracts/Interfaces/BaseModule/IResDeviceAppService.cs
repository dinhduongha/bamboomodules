using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IResDeviceAppService : IApplicationService
    {
        Task<ResDevice> InitAsync(Guid id);
        Task<ResDevice> RevokeAsync(Guid id);
    }
}