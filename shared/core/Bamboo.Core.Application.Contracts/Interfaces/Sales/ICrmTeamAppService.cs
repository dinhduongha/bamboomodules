using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface ICrmTeamAppService : IGenericApplicationService<CrmTeam>
    {
        Task<CrmTeam> AssignLeadsAsync(Guid id);
        Task<CrmTeam> GetAbandonedCartsAsync(Guid id);
        Task<CrmTeam> OpportunityForecastAsync(Guid id);
        Task<CrmTeam> PrimaryChannelButtonAsync(Guid id);
        Task<CrmTeam> UpdateInvoicedTargetAsync(Guid id, CrmTeamUpdateInvoicedTargetRequestDto input);
        Task<CrmTeam> YourPipelineAsync(Guid id);
    }
}