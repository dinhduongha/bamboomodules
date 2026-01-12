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
        Task<LoyaltyProgram> CreateFromTemplateAsync(Guid id, LoyaltyProgramCreateFromTemplateRequestDto input);
        Task<LoyaltyProgram> GetProgramTemplatesAsync(Guid id);
        Task<LoyaltyProgram> OpenLoyaltyCardsAsync(Guid id);
        Task<LoyaltyProgram> ProgramShareAsync(Guid id);
    }
}