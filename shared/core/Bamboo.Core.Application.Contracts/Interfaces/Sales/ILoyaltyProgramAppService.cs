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
    public interface ILoyaltyProgramAppService : IGenericApplicationService<LoyaltyProgram>
    {
        Task<LoyaltyProgram> CreateFromTemplateAsync(LoyaltyProgramCreateFromTemplateRequestDto input);
        Task<LoyaltyProgram> GetProgramTemplatesAsync(Guid[] ids);
        Task<LoyaltyProgram> OpenLoyaltyCardsAsync(Guid[] ids);
        Task<LoyaltyProgram> ProgramShareAsync(Guid[] ids);
    }
}