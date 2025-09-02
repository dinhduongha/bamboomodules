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
    public interface ILoyaltyProgramAppService : IGenericApplicationService<LoyaltyProgram>
    {
        Task<LoyaltyProgram> CreateFromTemplateAsync(Guid id, LoyaltyProgramCreateFromTemplateRequestDto input);
        Task<LoyaltyProgram> GetProgramTemplatesAsync(Guid id);
        Task<LoyaltyProgram> OpenLoyaltyCardsAsync(Guid id);
        Task<LoyaltyProgram> ProgramShareAsync(Guid id);
        Task<LoyaltyProgram> ToggleActiveAsync(Guid id);
    }
}