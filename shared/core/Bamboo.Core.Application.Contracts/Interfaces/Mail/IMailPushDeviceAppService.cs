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
    public interface IMailPushDeviceAppService : IGenericApplicationService<MailPushDevice>
    {
        Task<MailPushDevice> GetWebPushVapidPublicKeyAsync(Guid id);
        Task<MailPushDevice> RegisterDevicesAsync(Guid id);
        Task<MailPushDevice> UnregisterDevicesAsync(Guid id);
    }
}