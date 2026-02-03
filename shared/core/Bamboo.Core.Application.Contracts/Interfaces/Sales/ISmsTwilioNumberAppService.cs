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
    public interface ISmsTwilioNumberAppService : IGenericAppService<SmsTwilioNumber>
    {
        Task<SmsTwilioNumber> UnlinkAsync(Guid[] ids);
    }
}