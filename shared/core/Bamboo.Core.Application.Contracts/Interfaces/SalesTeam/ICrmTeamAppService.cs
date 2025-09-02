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