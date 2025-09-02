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
    public interface IHrSkillTypeAppService : IGenericApplicationService<HrSkillType>
    {
        Task<HrSkillType> CopyDataAsync(Guid id, HrSkillTypeCopyDataRequestDto input);
    }
}