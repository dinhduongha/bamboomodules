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
    public interface ICrmTeamAppService : IGenericAppService<CrmTeam>
    {
        Task<CrmTeam> AssignLeadsAsync(Guid[] ids);
        Task<CrmTeam> GetAbandonedCartsAsync(Guid[] ids);
        Task<CrmTeam> OpenLeadsAsync(Guid[] ids);
        Task<CrmTeam> OpenUnassignedLeadsAsync(Guid[] ids);
        Task<CrmTeam> OpportunityForecastAsync(Guid[] ids);
        Task<CrmTeam> PrimaryChannelButtonAsync(Guid[] ids);
        Task<CrmTeam> UpdateInvoicedTargetAsync(CrmTeamUpdateInvoicedTargetRequestDto input);
        Task<CrmTeam> YourPipelineAsync(Guid[] ids);
    }
}